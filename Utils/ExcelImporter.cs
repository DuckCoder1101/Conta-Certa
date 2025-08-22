using System.Data;
using ExcelDataReader;
using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Forms;
using Conta_Certa.Models;

namespace Conta_Certa.Utils;

public static class ExcelImporter
{
    private static DataSet? GetTableDataSet(string filePath)
    {
        try
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            using var columnMapForm = new ClienteColumnManager();

            return reader.AsDataSet(new()
            {
                UseColumnDataType = false
            });
        }

        catch (UnauthorizedAccessException)
        {
            MessageBox.Show(
                "Esse arquivo está sendo usado por outro programa.\nFeche-o e tente novamente!",
                "Arquivo em uso!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return null;
        }

        catch (Exception ex)
        {
            Logger.LogException(ex);
            return null;
        }
    }

    public static void ImportClientesTable(string filePath)
    {
        var dataSet = GetTableDataSet(filePath);

        if (dataSet != null)
        {
            using var columnMapForm = new ClienteColumnManager();
            var dialogResult = columnMapForm.ShowDialog();

            if (dialogResult == DialogResult.Yes)
            {
                var clienteModel = columnMapForm.ClienteModel;

                for (int i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var row = dataSet.Tables[0].Rows[i];
                    ClienteCadDTO clienteDTO = new();

                    foreach (ColumnMap map in clienteModel.GetColumns())
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
                        cadForm.ShowDialog();
                    }
                }
            }
        }
    }

    public static void ImportCobrancasTable(string filePath)
    {
        var dataSet = GetTableDataSet(filePath);

        if (dataSet != null)
        {
            using var columnMapForm = new CobrancaColumnManager();
            var dialogResult = columnMapForm.ShowDialog();

            if (dialogResult == DialogResult.Yes)
            {
                var cobrancaModel = columnMapForm.CobrancaModel;

                List<CobrancaCadDTO> cobrancas = [];

                for (int i = 1; i < dataSet.Tables[1].Rows.Count; i++)
                {
                    var row = dataSet.Tables[1].Rows[i];
                    CobrancaCadDTO cobrancaDTO = new();

                    foreach (ColumnMap map in cobrancaModel.GetColumns())
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
                            case nameof(ClienteCadDTO.Documento)
                            when (Cliente.CheckDocumento(columnValue)):
                                cobrancaDTO.DocumentoCliente = columnValue;
                                break;

                            case nameof(CobrancaCadDTO.Honorario)
                            when (float.TryParse(columnValue, out var honorario) && honorario > 0):
                                cobrancaDTO.Honorario = honorario;
                                break;

                            case nameof(CobrancaCadDTO.Status)
                            when (Enum.TryParse<CobrancaStatus>(columnValue, true, out var status)):
                                cobrancaDTO.Status = status;
                                break;

                            case nameof(Cobranca.Vencimento)
                            when (DateTime.TryParse(columnValue, out var vencimento)):
                                cobrancaDTO.Vencimento = vencimento;
                                break;

                            case nameof(Cobranca.PagoEm)
                            when (cobrancaDTO.Status == CobrancaStatus.Paga && DateTime.TryParse(columnValue, out var pagoEm)):
                                cobrancaDTO.PagoEm = pagoEm;
                                break;
                        }
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

                    CobrancaDAO.InsertCobrancas([.. cobrancas.Where(c => c.IsFull())]);
                }
            }
        }
    }
}
