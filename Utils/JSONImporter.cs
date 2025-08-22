using System.Data;
using System.Text.Json;
using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Models;

namespace Conta_Certa.Utils;

public static class JSONImporter
{
    private static readonly JsonSerializerOptions jsonOptions = new()
    {
        WriteIndented = true,
    };

    private static Dictionary<long, long?> MapIds<T>(IEnumerable<T> originals, IEnumerable<long?> newIds, Func<T, long> getOldId)
    {
        if (newIds.Any(id => id == 0))
        {
            MessageBox.Show(
                "Não foi possível importar o arquivo!",
                "Erro de importação!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return [];
        }

        Dictionary<long, long?> map = [];
        using var enumOrig = originals.GetEnumerator();
        using var enumNews = newIds.GetEnumerator();
        
        while (enumOrig.MoveNext() && enumNews.MoveNext())
        {
            map[getOldId(enumOrig.Current)] = enumNews.Current;
        }

        return map;
    }

    private static void ImportClientesFromJSON(List<Cliente> clientes)
    {
        ClienteCadDTO[] dtos = [.. clientes.Select(c => new ClienteCadDTO(c))];
        ClienteDAO.InsertClientes(dtos);
    }

    private static Dictionary<long, long?> ImportCobrancasFromJSON(List<Cobranca> cobrancas)
    {
       List<CobrancaCadDTO> dtos = [];

        foreach (var cobranca in cobrancas)
        {
            dtos.Add(new(cobranca));
        }

        var ids = CobrancaDAO.InsertCobrancas([..dtos]);
        return MapIds(cobrancas, ids, c => c.IdCobranca);
    }

    private static Dictionary<long, long?> ImportServicosFromJSON(List<Servico> servicos)
    {
        ServicoCadDTO[] dtos = [.. servicos.Select(s => new ServicoCadDTO(s))];
        var ids = ServicoDAO.InsertServicos(dtos);

        return MapIds(servicos, ids, s => s.IdServico);
    }

    private static void ImportServicosCobrancaFromJSON(List<ServicoCobranca> servicosCobrancas, Dictionary<long, long?> idCobrancas, Dictionary<long, long?> idServicos)
    {
        List<ServicoCobrancaCadDTO> dtos = [];

        foreach (var sc in servicosCobrancas)
        {
            if (idCobrancas[sc.IdCobranca] != null && 
                idServicos[sc.Servico.IdServico] != null)
            {
                dtos.Add(new(
                    sc,
                    (long)idCobrancas[sc.IdCobranca]!,
                    (long)idServicos[sc.Servico.IdServico]!));
            }
        }

        ServicoCobrancaDAO.InsertServicosCobranca([..dtos]);
    }

    public static void ExportToJSON(string filePath)
    {
        try
        {
            AppData appData = new();
            string json = JsonSerializer.Serialize(appData, jsonOptions);

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
                    List<ServicoCobranca> servicoCobrancas = [.. appData.Cobrancas.SelectMany(c => c.ServicosCobranca)];

                    ImportClientesFromJSON(appData.Clientes);
                    var idCobrancas = ImportCobrancasFromJSON(appData.Cobrancas);
                    var idServicos = ImportServicosFromJSON(appData.Servicos);

                    ImportServicosCobrancaFromJSON(servicoCobrancas, idCobrancas, idServicos);

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
