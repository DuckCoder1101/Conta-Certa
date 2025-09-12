using Conta_Certa.DTOs;

namespace Conta_Certa.Models;

public enum CobrancaStatus
{
    Pendente,
    Paga
};

public class Cobranca
{
    public long IdCobranca { get; }
    public ClienteResumoDTO Cliente { get; }
    public float Honorario { get; }
    public float HonorarioTotal
    {
        get => Honorario + 
            ServicosCobranca.Sum(sc => sc.Servico.Valor * sc.Quantidade);
    }

    public CobrancaStatus Status { get; private set; }
    public DateTime Vencimento { get; private set; }
    public DateTime? PagoEm { get; private set; }
    public List<ServicoCobranca> ServicosCobranca { get; set; } = [];

    public Cobranca(long idCobranca, ClienteResumoDTO cliente, float honorario, CobrancaStatus status, DateTime vencimento, DateTime? pagoEm)
    {
        IdCobranca = idCobranca;
        Cliente = cliente;
        Honorario = honorario;
        Status = status;
        Vencimento = vencimento;
        PagoEm = pagoEm;
    }
}
