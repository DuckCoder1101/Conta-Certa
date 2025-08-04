using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public record CobrancaCadDTO
{
    public long? IdCliente { get; set; }
    public float? Honorario { get; set; }
    public CobrancaStatus? Status { get; set; }
    public DateTime? Vencimento { get; set; }
    public DateTime? PagoEm { get; set; }

    public CobrancaCadDTO()
    {

    }

    public CobrancaCadDTO(long idCliente, float honorario, CobrancaStatus status, DateTime vencimento, DateTime? pagoEm)
    {
        IdCliente = idCliente;
        Honorario = honorario;
        Status = status;
        Vencimento = vencimento;
        PagoEm = pagoEm;
    }

    public CobrancaCadDTO(Cobranca cobranca, long idCliente)
    {
        IdCliente = idCliente;
        Honorario = cobranca.Honorario;
        Status = cobranca.Status;
        Vencimento = cobranca.Vencimento;
        PagoEm = cobranca.PagoEm;
    }

    public bool IsFull()
    {
        return (
            IdCliente != null &&
            Honorario != null &&
            Status != null &&
            Vencimento != null &&
            (Status != CobrancaStatus.Paga || PagoEm != null));
    }
}
