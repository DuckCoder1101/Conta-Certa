using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public class CobrancaExcelImportDTO
{
    public ImportColumnMap IdCliente { get; }
    public ImportColumnMap Honorario { get; }
    public ImportColumnMap Status { get; }
    public ImportColumnMap Vencimento { get; }
    public ImportColumnMap PagoEm { get; }

    public CobrancaExcelImportDTO()
    {
        IdCliente = new("Índice cliente", nameof(CobrancaCadDTO.IdCliente), true, "Número de identificação de cada cliente, correspondentes à cobrança.");
        Honorario = new("Honorário", nameof(CobrancaCadDTO.Honorario), true, "Honorário base da cobrança.");
        Status = new("Status", nameof(CobrancaCadDTO.Status), true, "Status do pagamento da cobrança (Pago | Pendente).");
        Vencimento = new("Vencimento", nameof(CobrancaCadDTO.Vencimento), true, "Data de vencimento da cobrança (dd/MM/aaaa).");
        PagoEm = new("Pago em", nameof(CobrancaCadDTO.PagoEm), true, "Data de pagamento da cobrança (dd/MM/aaaa).");
    }

    public CobrancaExcelImportDTO(ImportColumnMap idCliente, ImportColumnMap honorario, ImportColumnMap status, ImportColumnMap vencimento, ImportColumnMap pagoEm)
    {
        IdCliente = idCliente;
        Honorario = honorario;
        Status = status;
        Vencimento = vencimento;
        PagoEm = pagoEm;
    }

    public IEnumerable<ImportColumnMap> GetColumns()
    {
        yield return IdCliente;
        yield return Honorario;
        yield return Status;
        yield return Vencimento;
        yield return PagoEm;
        yield break;
    }
}
