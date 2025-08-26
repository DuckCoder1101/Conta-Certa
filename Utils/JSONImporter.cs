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

    private static void ImportClientes(List<ClienteJSONDTO> clientes)
    {
        ClienteCadDTO[] dtos = [.. clientes.Select(c => new ClienteCadDTO(c))];
        ClienteDAO.InsertClientes(dtos);
    }

    private static Dictionary<long, long?> ImportCobrancas(List<CobrancaJSONDTO> cobrancas)
    {
        List<CobrancaCadDTO> dtos = [.. cobrancas.Select(c => new CobrancaCadDTO(c))];

        var ids = CobrancaDAO.InsertCobrancas([..dtos]);
        return MapIds(cobrancas, ids, c => c.TransitionIdCobranca);
    }

    private static Dictionary<long, long?> ImportServicos(List<ServicoJSONDTO> servicos)
    {
        ServicoCadDTO[] dtos = [.. servicos.Select(s => new ServicoCadDTO(s))];
        var ids = ServicoDAO.InsertServicos(dtos);

        return MapIds(servicos, ids, s => s.TransitionIdServico);
    }

    private static void ImportServicosCobranca(List<CobrancaJSONDTO> cobrancas, Dictionary<long, long?> idCobrancas, Dictionary<long, long?> idServicos)
    {
        List<ServicoCobrancaCadDTO> dtos = [];

        foreach (var c in cobrancas)
        {
            long? idCobranca = idCobrancas[c.TransitionIdCobranca];
            if (idCobranca != null)
            {
                foreach (var sc in c.ServicosCobranca)
                {
                    long? idServico = idServicos[sc.IdServico];
                    if (idServico != null)
                    {
                        dtos.Add(new(
                            (long)idCobranca,
                            (long)idServico,
                            sc.Valor,
                            sc.Quantidade));
                    }
                }
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
                    ImportClientes(appData.Clientes);
                    var idCobrancas = ImportCobrancas(appData.Cobrancas);
                    var idServicos = ImportServicos(appData.Servicos);
                    ImportServicosCobranca(appData.Cobrancas, idCobrancas, idServicos);

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
