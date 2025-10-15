using System.Text.Json;
using Conta_Certa.DTOs;
using Conta_Certa.Forms;
using Conta_Certa.Models;

namespace Conta_Certa.Utils;

public static class JSONImporter
{
    private static readonly JsonSerializerOptions _jsonOptions = new();

    private static void ImportClientes(AppDBContext dbContext, ICollection<ClienteCadDTO> dtos)
    {
        foreach (var dto in dtos)
        {
            if (!dto.IsFull())
            {
                ClienteForm form = new(dto);
                form.ShowDialog();
                return;
            }

            var clienteExistente = dbContext.Clientes
                .FirstOrDefault(c => c.Documento == dto.Documento);

            if (clienteExistente != null)
            {
                clienteExistente.Telefone = dto.Telefone!;
                clienteExistente.Email = dto.Email;
                clienteExistente.VencimentoHonorario = (int) dto.VencimentoHonorario!;
                clienteExistente.Honorario = (float) dto.Honorario!;

                dbContext.Update(clienteExistente);
            }

            else
            {
                Cliente cliente = new(dto);
                dbContext.Add(cliente);
            }
        }

        dbContext.SaveChanges();
    }

    private static void ImportCobrancas(AppDBContext dbContext, ICollection<CobrancaCadDTO> dtos)
    {
        foreach (var dto in dtos)
        {
            if (!dto.IsFull())
            {
                CobrancaForm form = new(dto);
                form.ShowDialog();
                return;
            }

            var cobrancaExistente = dbContext.Cobrancas
                .FirstOrDefault(c => c.DocumentoCliente == dto.DocumentoCliente &&
                (c.Vencimento.Month == dto.Vencimento!.Value.Month && c.Vencimento.Year == dto.Vencimento.Value.Year));

            if (cobrancaExistente != null)
            {
                cobrancaExistente.Honorario = dto.Honorario!.Value;
                cobrancaExistente.PagoEm = dto.PagoEm;
                cobrancaExistente.ServicosCobranca = dto.ServicosCobranca.Select(sc => new ServicoCobranca(sc)));

                dbContext.Update(cobrancaExistente);
            }

            else
            {
                Cliente cliente = new(dto);
                dbContext.Add(cliente);
            }
        }

        dbContext.SaveChanges();
    }

    private static void ImportServicos(AppDBContext dbContext, ICollection<ServicoCadDTO> dtos)
    {
        dbContext.Servicos.AddRange(dtos.Select(dto => new Servico(dto)));
        dbContext.SaveChanges();
    }

    public static void ExportToJSON(string filePath)
    {
        try
        {
            AppData appData = new();
            string json = JsonSerializer.Serialize(appData, _jsonOptions);

            File.WriteAllText(filePath, json, System.Text.Encoding.UTF8);

            MessageBox.Show(
                "Os dados foram exportados com sucesso!",
                "Exportação concluída!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }

    public static void ImportFromJson(string filePath)
    {
        try
        {
            using AppDBContext dbContext = new();

            var result = MessageBox.Show(
                        "Deseja mesmo importar os dados?\nOs registros iguais serão sobrescritos.",
                        "Importar os dados?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string json = File.ReadAllText(filePath, System.Text.Encoding.UTF8);
                AppData? appData = JsonSerializer.Deserialize<AppData>(json);

                if (appData != null)
                {
                    ImportClientes(dbContext, appData.Clientes);
                    ImportCobrancas(dbContext, appData.Cobrancas);
                    ImportServicos(dbContext, appData.Servicos);

                    MessageBox.Show(
                        "Os dados foram importados com sucesso!",
                        "Importação concluída!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show(
                        "Não foi possível traduzir os dados!",
                        "Importação falhada!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        catch (UnauthorizedAccessException)
        {
            MessageBox.Show(
                "Esse arquivo está sendo usado por outro programa.\nFeche-o e tente novamente!",
                "Arquivo em uso!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        catch (JsonException)
        {
            MessageBox.Show(
                "O arquivo lido não está no padrão esperado.\nTente novamente com outro arquivo!",
                "Arquivo ilegível!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }
}
