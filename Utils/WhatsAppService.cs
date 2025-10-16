using Conta_Certa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;
using System.Diagnostics;

namespace Conta_Certa.Utils;

public class WhatsAppService : IDisposable
{
    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private IBrowserContext? _browserContext;
    private IPage? _page;

    // Arquivo de sessão
    private readonly string STORAGE_STATE_FILE = $"{Application.UserAppDataPath}/whatsapp.lock";

    private async Task SendMessage(string phoneNumber, string message)
    {
        string fullNumber = $"55{phoneNumber}";
        string encodedMessage = Uri.EscapeDataString(message);

        string waMeUrl = $"https://web.whatsapp.com/send?phone={fullNumber}&text={encodedMessage}";
        await _page!.GotoAsync(waMeUrl);

        try
        {
            // 1. Aguarda a página de transição/confirmação carregar.
            const string TRANSITION_SELECTOR = "div[role='button']:has-text('Continuar para o chat')";

            var options = new PageWaitForSelectorOptions { Timeout = 10000 };

            // 2. Tenta encontrar e clicar no botão "Continuar para o chat" (Seletor pode variar)
            if (await _page.Locator(TRANSITION_SELECTOR).IsVisibleAsync())
            {
                await _page.ClickAsync(TRANSITION_SELECTOR);
            }


            // Se a mensagem já estiver pré-preenchida pelo URL, o WhatsApp apenas espera o botão de envio.
            const string SEND_BUTTON_SELECTOR = "button[data-testid='send']";
            const string MESSAGE_AREA_SELECTOR = "div[data-testid='conversation-compose-box']";

            // 3. Aguarda o botão de envio *final* (dentro do chat) aparecer.
            await _page.WaitForSelectorAsync(SEND_BUTTON_SELECTOR, new PageWaitForSelectorOptions { Timeout = 20000 });

            // 4. Garante que o input de mensagem existe, se o URL não tiver preenchido (ou por segurança).
            if (string.IsNullOrWhiteSpace(await _page.Locator(MESSAGE_AREA_SELECTOR).InputValueAsync()))
            {
                await _page.FillAsync(MESSAGE_AREA_SELECTOR, message);
            }

            // 5. Clica no botão de enviar
            await _page.WaitForTimeoutAsync(1000); // Pequeno atraso para estabilidade
            await _page.ClickAsync(SEND_BUTTON_SELECTOR);

            await _page.WaitForSelectorAsync("span[data-testid='msg-check']", new PageWaitForSelectorOptions { Timeout = 5000 });

        }

        catch (TimeoutException)
        {
            Logger.LogException(new($"Erro ou Timeout: Não foi possível encontrar o botão de enviar. O chat pode não ter sido carregado."));
        }

        catch (Exception ex)
        {
            Logger.LogException(new($"Erro ao enviar mensagem: {ex.Message}"));
        }
    }

    public async Task Initialize(bool headless = true)
    {
        _playwright = await Playwright.CreateAsync();

        BrowserTypeLaunchOptions launchOptions = new()
        {
            Headless = headless,
            SlowMo = 50
        };

        BrowserNewContextOptions contextOptions = new();

        // Verifica se a sessão existe
        if (File.Exists(STORAGE_STATE_FILE))
        {
            contextOptions.StorageStatePath = STORAGE_STATE_FILE;
        }

        _browser = await _playwright.Chromium.LaunchAsync(launchOptions);
        _browserContext = await _browser.NewContextAsync(contextOptions);
        _page = await _browserContext!.NewPageAsync();

        await _page.GotoAsync("https://web.whatsapp.com/");

        const string CONVERSATION_LIST_SELECTOR = "div[data-testid='conversation-list']";
        const string QR_CODE_SELECTOR = "div[data-testid='qrcode']";

        try
        {
            await _page.WaitForSelectorAsync(CONVERSATION_LIST_SELECTOR,
                new PageWaitForSelectorOptions
                {
                    Timeout = 5000
                });

            await _browserContext.StorageStateAsync(new BrowserContextStorageStateOptions { Path = STORAGE_STATE_FILE });

            if (!headless)
            {
                await _browser.CloseAsync();

                _browser = null;
                _browserContext = null;
                _page = null;

                await Initialize(true);
            }
        }

        catch (TimeoutException)
        {
            if (await _page.Locator(QR_CODE_SELECTOR).IsVisibleAsync())
            {
                Logger.LogException(new("Sessão expirada. Por favor, reinicie o aplicativo com 'headless: false' para escanear o QR Code."));
            }

            else
            {
                Logger.LogException(new("Falha ao carregar a interface do WhatsApp Web após 60s."));
            }
        }
    }

    public async Task SendCobrancas()
    {
        using AppDBContext dbContext = new();

        var cobrancas = dbContext.Cobrancas
            .Include(c => c.Cliente)
            .Where(c => c.Status == CobrancaStatus.Pendente);

        foreach (var cobranca in cobrancas)
        {
            var phone = cobranca.Cliente!.Telefone;
            var msg = $"Olá ${cobranca.Cliente.Nome}, seu honorário de valor {cobranca.HonorarioTotal:c} com vencimento {cobranca.Vencimento:dd/MM} está pendente.";

            await SendMessage("19997834256", msg);
        }
    }

    public async void Dispose()
    {
        if (_browser != null)
        {
            await _browserContext!.StorageStateAsync(new BrowserContextStorageStateOptions { Path = STORAGE_STATE_FILE });
            await _browser.CloseAsync();
        }
    }
}
