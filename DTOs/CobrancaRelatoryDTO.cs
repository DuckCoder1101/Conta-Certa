using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public record CobrancaRelatoryDTO(long idCobranca, string cliente, float honorario, CobrancaStatus status, DateTime? vencimento, DateTime? pagoEm)
{
    public long IdCobranca { get; set; } = idCobranca;
    public string Cliente { get; set; } = cliente;
    public float HonorarioTotal { get; set; } = honorario;
    public CobrancaStatus Status { get; set; } = status;
    public DateTime? Vencimento { get; set; } = vencimento;
    public DateTime? PagoEm { get; set; } = pagoEm;
}
