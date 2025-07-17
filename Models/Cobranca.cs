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
    public CobrancaStatus Status { get; private set; }
    public DateTime Vencimento { get; private set; }
    public DateTime? PagoEm { get; private set; }

    public List<ServicoCobranca> Servicos { get; private set; } = [];

    public Cobranca(
        long idCobranca,
        ClienteResumoDTO cliente, 
        float honorario, 
        CobrancaStatus status,
        DateTime vencimento,
        DateTime? pagoEm = null,
        List<ServicoCobranca>? servicosExtras = null)
    {
        IdCobranca = idCobranca;
        Cliente = cliente;
        Honorario = honorario;
        Status = status;
        Vencimento = vencimento;
        PagoEm = pagoEm;

        if (servicosExtras != null)
        {
            Servicos = servicosExtras;
        }
    }
}
