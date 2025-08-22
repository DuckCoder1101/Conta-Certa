using Conta_Certa.DTOs;

namespace Conta_Certa.Models;

public class CobrancaColumns
{
    public ColumnMap DocumentoCliente { get; }
    public ColumnMap Honorario { get; }
    public ColumnMap Status { get; }
    public ColumnMap Vencimento { get; }
    public ColumnMap PagoEm { get; }

    public CobrancaColumns()
    {
        DocumentoCliente = new("Doc. cliente", nameof(ClienteCadDTO.Documento), "Documento do devedor.");
        Honorario = new("Honorário", nameof(CobrancaCadDTO.Honorario), "Honorário base da cobrança.");
        Status = new("Status", nameof(CobrancaCadDTO.Status), "Status do pagamento da cobrança (Pago | Pendente).");
        Vencimento = new("Vencimento", nameof(CobrancaCadDTO.Vencimento), "Data de vencimento da cobrança (dd/MM/aaaa).");
        PagoEm = new("Pago em", nameof(CobrancaCadDTO.PagoEm), "Data de pagamento da cobrança (dd/MM/aaaa).");
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
