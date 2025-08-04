using System.Data;
using System.Text.Json;
using System.Globalization;
using ExcelDataReader;
using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.Forms;

namespace Conta_Certa.Utils;

public static class ExportImportData
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

    private static Dictionary<long, long?> ImportClientesFromJSON(List<Cliente> clientes)
    {
        ClienteCadDTO[] dtos = [.. clientes.Select(c => new ClienteCadDTO(c))];
        var ids = ClienteDAO.InsertClientes(dtos);

        return MapIds(clientes, ids, c => c.IdCliente);
    }

    private static Dictionary<long, long?> ImportCobrancasFromJSON(List<Cobranca> cobrancas, Dictionary<long, long?> idClientes)
    {
       List<CobrancaCadDTO> dtos = [];

        foreach (var cobranca in cobrancas)
        {
            if (idClientes[cobranca.Cliente.IdCliente] != null)
            {
                dtos.Add(new(cobranca, (long)idClientes[cobranca.Cliente.IdCliente]!));
            }
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
    
    private static Dictionary<string, long?> ImportClientesFromTable(ClienteExcelImportDTO clienteModel, DataSet dataSet)
    {
        Dictionary<string, long?> idClientes = [];
        List<ClienteCadDTO> clientes = [];

        for (int i = 1; i < dataSet.Tables[0].Rows.Count; i++)
        {
            var row = dataSet.Tables[0].Rows[i];   
            ClienteCadDTO clienteDTO = new();

            foreach (ImportColumnMap map in clienteModel.GetColumns())
            {
                int columnIndex = map.ColumnIndex - 1;
                var columnValue = row.Table.Columns.Count > columnIndex
                    ? row[columnIndex].ToString()
                    : null;

                // Dado nulo ou coluna desativada?
                if (!map.Import || string.IsNullOrEmpty(columnValue))
                {
                    continue;
                }

                switch (map.PropertyName)
                {
                    case nameof(ClienteCadDTO.Nome):
                        clienteDTO.Nome = columnValue;
                        break;

                    case nameof(ClienteCadDTO.Documento) when (Cliente.CheckDocumento(columnValue)):
                        clienteDTO.Documento = columnValue;
                        break;

                    case nameof(ClienteCadDTO.Telefone) when (Cliente.CheckTelefone(columnValue)):
                        clienteDTO.Telefone = Cliente.FormatTelefone(columnValue);
                        break;

                    case nameof(ClienteCadDTO.Email):
                        clienteDTO.Email = columnValue; 
                        break;

                    case nameof(ClienteCadDTO.Honorario) when (float.TryParse(columnValue, out var honorario) && honorario > 0):
                        clienteDTO.Honorario = honorario;
                        break;

                    case nameof(ClienteCadDTO.VencimentoHonorario) when (int.TryParse(columnValue, out var vencimento) && vencimento > 0 && vencimento <= 30):
                        clienteDTO.VencimentoHonorario = vencimento;
                        break;
                }
            }

            if (!clienteDTO.IsFull())
            {
                ManageCliente cadForm = new(clienteDTO);
                DialogResult result = cadForm.ShowDialog();

                if (result == DialogResult.OK && cadForm.Cliente != null)
                {
                    idClientes[cadForm.Cliente.Documento] = cadForm.Cliente.IdCliente;
                }
            }

            else
            {
                clientes.Add(clienteDTO);
                idClientes[clienteDTO.Documento!] = null;
            }
        }

        foreach (long? id in ClienteDAO.InsertClientes([.. clientes.Where(c => c.IsFull())]))
        {
            var map = idClientes.First((id) => id.Value == null);
            idClientes[map.Key] = id;
        }

        return idClientes;
    }

    private static void ImportCobrancasFromTable(CobrancaExcelImportDTO cobrancaModel, DataSet dataSet, Dictionary<string, long?> idsClientes)
    {
        List<CobrancaCadDTO> cobrancas = [];

        for (int i = 1; i < dataSet.Tables[1].Rows.Count; i++)
        {
            var row = dataSet.Tables[1].Rows[i];
            CobrancaCadDTO cobrancaDTO = new();

            foreach (ImportColumnMap map in cobrancaModel.GetColumns())
            {
                int columnIndex = map.ColumnIndex - 1;
                var columnValue = row.Table.Columns.Count > columnIndex
                    ? row[columnIndex].ToString()
                    : null;

                // Dado nulo ou coluna desativada?
                if (!map.Import || string.IsNullOrEmpty(columnValue))
                {
                    continue;
                }

                // Formatos de data aceitos
                string[] dateFormats = { "dd/MM/yyyy", "d/M/yy", "dd/MM/yy", "d/M/yyyy" };
                
                switch (map.PropertyName)
                {
                    case nameof(CobrancaCadDTO.IdCliente) when (Cliente.CheckDocumento(columnValue)):
                        cobrancaDTO.IdCliente = idsClientes[columnValue];
                        break;

                    case nameof(CobrancaCadDTO.Honorario) when (float.TryParse(columnValue, out var honorario) && honorario > 0):
                        cobrancaDTO.Honorario = honorario;
                        break;

                    case nameof(CobrancaCadDTO.Status) when (Enum.TryParse<CobrancaStatus>(columnValue, true, out var status)):
                        cobrancaDTO.Status = status;
                        break;

                    case nameof(Cobranca.Vencimento) 
                    when (DateTime.TryParseExact(columnValue, dateFormats, new CultureInfo("pt-BR"), DateTimeStyles.None, out var vencimento)):
                        cobrancaDTO.Vencimento = vencimento;
                        break;

                    case nameof(Cobranca.PagoEm)
                    when (cobrancaDTO.Status == CobrancaStatus.Paga && DateTime.TryParseExact(columnValue, dateFormats, new CultureInfo("pt-BR"), DateTimeStyles.None, out var pagoEm)):
                        cobrancaDTO.PagoEm = pagoEm;
                        break;
                }

                if (!cobrancaDTO.IsFull())
                {
                    ManageCobranca cadForm = new(cobrancaDTO);
                    cadForm.ShowDialog();
                }

                else
                {
                    cobrancas.Add(cobrancaDTO);
                }
            }

            CobrancaDAO.InsertCobrancas([
                ..cobrancas.Where(c => c.IsFull())]);
        }
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
                    List<ServicoCobranca> servicoCobrancas = [.. appData.Cobrancas.SelectMany(c => c.Servicos)];

                    var idClientes = ImportClientesFromJSON(appData.Clientes);
                    var idCobrancas = ImportCobrancasFromJSON(appData.Cobrancas, idClientes);
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

    public static void ImportFromTable(string filePath) 
    {
        try
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            using var columnMapForm = new ExcelColumnAssistant();

            if (columnMapForm.ShowDialog() == DialogResult.Yes)
            {
                var clienteModel = columnMapForm.ClienteModel;
                var cobrancaModel = columnMapForm.CobrancaModel;

                var dataSet = reader.AsDataSet(new()
                {
                    UseColumnDataType = false
                });

                var idClientes = ImportClientesFromTable(clienteModel, dataSet);
                ImportCobrancasFromTable(cobrancaModel, dataSet, idClientes);
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

        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }
}
