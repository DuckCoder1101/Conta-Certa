using Conta_Certa.Models;
using System.Text.Json;

namespace Conta_Certa.Utils;

public static class JSONImporter
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true,
    };

    private static void ImportClientes(AppDBContext dbContext, ICollection<Cliente> clientes)
    {
        dbContext.Clientes.AddRange(clientes);
        dbContext.SaveChanges();
    }

    private static void ImportCobrancas(AppDBContext dbContext, ICollection<Cobranca> cobrancas)
    {
        foreach (var cobranca in cobrancas)
        {
            cobranca.SetId(null);
        }

        dbContext.Cobrancas.AddRange(cobrancas);
        dbContext.SaveChanges();
    }

    private static void ImportServicos(AppDBContext dbContext, ICollection<Servico> servicos)
    {
        foreach (var servico in servicos)
        {
            servico.SetId(null);
        }

        dbContext.Servicos.AddRange(servicos);
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
