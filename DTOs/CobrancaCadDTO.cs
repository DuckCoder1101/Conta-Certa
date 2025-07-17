using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public record CobrancaCadDTO
{
    public long IdCliente { get; }
    public float Honorario { get; }
    public CobrancaStatus Status { get; }
    public DateTime Vencimento { get; }
    public DateTime? PagoEm { get; }

    public CobrancaCadDTO(long idCliente, float honorario, CobrancaStatus status, DateTime vencimento, DateTime? pagoEm)
    {
        IdCliente = idCliente;
        Honorario = honorario;
        Status = status;
        Vencimento = vencimento;
        PagoEm = pagoEm;
    }
}
