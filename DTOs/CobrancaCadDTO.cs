using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public record CobrancaCadDTO
{
    public string? DocumentoCliente { get; set; }
    public float? Honorario { get; set; }
    public CobrancaStatus? Status { get; set; }
    public DateTime? Vencimento { get; set; }
    public DateTime? PagoEm { get; set; }

    public CobrancaCadDTO()
    {

    }

    public CobrancaCadDTO(string documentoCliente, float honorario, CobrancaStatus status, DateTime vencimento, DateTime? pagoEm)
    {
        DocumentoCliente = documentoCliente;
        Honorario = honorario;
        Status = status;
        Vencimento = vencimento;
        PagoEm = pagoEm;
    }

    public CobrancaCadDTO(Cobranca cobranca)
    {
        DocumentoCliente = cobranca.Cliente.Documento;
        Honorario = cobranca.Honorario;
        Status = cobranca.Status;
        Vencimento = cobranca.Vencimento;
        PagoEm = cobranca.PagoEm;
    }

    public bool IsFull()
    {
        return (
            DocumentoCliente != null &&
            Honorario != null &&
            Status != null &&
            Vencimento != null &&
            (Status != CobrancaStatus.Paga || PagoEm != null));
    }
}
