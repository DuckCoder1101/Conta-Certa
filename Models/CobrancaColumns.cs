using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public class CobrancaColumns
{
    public ColumnMap DocumentoCliente { get; }
    public ColumnMap Honorario { get; }
    public ColumnMap Status { get; }
    public ColumnMap Vencimento { get; }
    public ColumnMap PagoEm { get; }

    public CobrancaColumns()
    {
        DocumentoCliente = new("Doc. cliente", nameof(ClienteCadDTO.Documento), true, "Documento do devedor.");
        Honorario = new("Honorário", nameof(CobrancaCadDTO.Honorario), true, "Honorário base da cobrança.");
        Status = new("Status", nameof(CobrancaCadDTO.Status), true, "Status do pagamento da cobrança (Pago | Pendente).");
        Vencimento = new("Vencimento", nameof(CobrancaCadDTO.Vencimento), true, "Data de vencimento da cobrança (dd/MM/aaaa).");
        PagoEm = new("Pago em", nameof(CobrancaCadDTO.PagoEm), true, "Data de pagamento da cobrança (dd/MM/aaaa).");
    }

    public IEnumerable<ColumnMap> GetColumns()
    {
        yield return DocumentoCliente;
        yield return Honorario;
        yield return Status;
        yield return Vencimento;
        yield return PagoEm;
        yield break;
    }
}
