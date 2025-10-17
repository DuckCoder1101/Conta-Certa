using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;
using Conta_Certa.Models;

namespace Conta_Certa.Utils;

public class WhatsAppService : IAsyncDisposable, IDisposable
{
    private IPlaywright? _playwright;
    private IBrowserContext? _browserContext;
    private IPage? _page;
    private readonly SemaphoreSlim _sendLock = new(1, 1);
    private bool _initialized = false;

    // Pasta para persistencia do perfil (cookies, localStorage, etc.)
    private readonly string _userDataDir;

    // Tempo de timeout padrão
    private const int DefaultTimeout = 30000;

    public WhatsAppService()
    {
        _userDataDir = Path.Combine(Application.UserAppDataPath, "playwright_profile");
        Directory.CreateDirectory(_userDataDir);
    }

    public async Task InitializeAsync(bool headless = true)
    {
        if (_initialized) return;

        _playwright = await Playwright.CreateAsync();

        var launchOptions = new BrowserTypeLaunchPersistentContextOptions
        {
            Headless = headless,
        };

        // LaunchPersistentContext cria um contexto "persistente" ligado a uma pasta -> salva sessão automaticamente
        _browserContext = await _playwright.Chromium.LaunchPersistentContextAsync(
            _userDataDir, new BrowserTypeLaunchPersistentContextOptions
            {
                Headless = headless,
                // viewport size, userAgent, etc. podem ser configurados aqui
            });

        // garanta que exista uma página
        _page = _browserContext.Pages.FirstOrDefault() ?? await _browserContext.NewPageAsync();

        // opcional: navegue pro WhatsApp para garantir load / QR
        await _page.GotoAsync("https://web.whatsapp.com/", new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle, Timeout = DefaultTimeout });

        try
        {
            await _page.WaitForSelectorAsync("div[id='pane-side']", new PageWaitForSelectorOptions { Timeout = 20000 });
        }

        catch (TimeoutException)
        {
            var qrVisible = await _page.Locator("canvas").IsVisibleAsync().ConfigureAwait(false);
            if (qrVisible)
            {
                throw new InvalidOperationException("Sessão não autenticada. Abra o app em modo não-headless para escanear o QR code.");
            }
            else
            {
                throw new InvalidOperationException("Falha ao carregar WhatsApp Web (timeout).");
            }
        }

        _initialized = true;
    }

    public async Task SendMessageAsync(string phoneNumber, string message)
    {
        if (!_initialized)
        {
            throw new InvalidOperationException("WhatsAppService não inicializado. Chame InitializeAsync primeiro.");
        }

        if (phoneNumber.Length < 11) return;

        // evita concorrência entre envios
        await _sendLock.WaitAsync();

        try
        {
            //string fullNumber = phoneNumber.StartsWith("55") ? phoneNumber : $"55{phoneNumber}";
            string fullNumber = "5519997834256";
            string encodedMessage = Uri.EscapeDataString(message);
            string waMeUrl = $"https://web.whatsapp.com/send?phone={fullNumber}&text={encodedMessage}";

            await _page!.GotoAsync(waMeUrl,
                new PageGotoOptions
                {
                    WaitUntil = WaitUntilState.NetworkIdle,
                    Timeout = DefaultTimeout
                });

            // Espera o redirecionamento interno terminar (WhatsApp às vezes faz 2 loads)
            await _page.WaitForTimeoutAsync(2000);

            // Clica em “Continuar para o chat” se aparecer
            var transitionLocator = _page.Locator("div[role='button']:has-text('Continuar para o chat')");
            if (await transitionLocator.IsVisibleAsync())
            {
                await transitionLocator.ClickAsync();
                await _page.WaitForTimeoutAsync(2000);
            }

            // Aguarda explicitamente até que o campo de mensagem esteja interativo
            ILocator? inputLocator = null;
            string[] candidateInputSelectors =
            [
                "[contenteditable='true'][data-tab='10']",
                "div[contenteditable='true'][data-testid='conversation-compose-box']",
                "div[contenteditable='true']"
            ];

            for (int attempt = 0; attempt < 5 && inputLocator == null; attempt++)
            {
                foreach (var sel in candidateInputSelectors)
                {
                    var loc = _page.Locator(sel);
                    if (await loc.CountAsync() > 0 && await loc.First.IsVisibleAsync())
                    {
                        inputLocator = loc.First;
                        break;
                    }
                }

                if (inputLocator == null)
                    await _page.WaitForTimeoutAsync(1000); // tenta novamente
            }

            if (inputLocator == null)
                throw new InvalidOperationException("Campo de mensagem não encontrado após múltiplas tentativas.");

            // Garante que o campo esteja realmente focado e editável
            await inputLocator.FocusAsync();
            await _page.WaitForFunctionAsync(
                "el => el.isContentEditable && el.offsetParent !== null",
                inputLocator,
                new PageWaitForFunctionOptions { Timeout = 10000 }
            );

            // Preenche e envia
            await _page.Keyboard.TypeAsync(message);
            await _page.Keyboard.PressAsync("Enter");
        }

        catch
        {

        }
    }

    public async Task SendCobrancasAsync()
    {
        // Exemplo com EF: traga lista em memória (ToListAsync) para não iterar com DB aberto indevidamente.
        using AppDBContext dbContext = new();
        var cobrancas = await dbContext.Cobrancas
            .Include(c => c.Cliente)
            .Where(c => c.Status == CobrancaStatus.Pendente)
            .ToListAsync();

        foreach (var cobranca in cobrancas)
        {
            var phone = cobranca.Cliente?.Telefone;
            var msg = $"Olá {cobranca.Cliente!.Nome}, seu honorário de valor {cobranca.HonorarioTotal:C} com vencimento {cobranca.Vencimento:dd/MM} está pendente.";
            
            try
            {
                await SendMessageAsync(phone, msg);
            }

            catch (Exception ex)
            {
                Logger.LogException(new($"Erro ao enviar cobrança para {phone}: {ex.Message}"));
            }
        }
    }

    // Dispose assíncrono recomendado
    public async ValueTask DisposeAsync()
    {
        try
        {
            if (_browserContext != null)
            {
                await _browserContext.CloseAsync();
                _browserContext = null;
            }

            if (_playwright != null)
            {
                _playwright.Dispose();
                _playwright = null;
            }
        }

        catch (Exception ex)
        {
            Logger.LogException(new($"Erro durante DisposeAsync: {ex.Message}"));
        }

        finally
        {
            _initialized = false;
        }
    }

    // Implementa IDisposable chamando o DisposeAsync de forma síncrona segura
    public void Dispose()
    {
        DisposeAsync().AsTask().GetAwaiter().GetResult();
        _sendLock?.Dispose();
    }
}
