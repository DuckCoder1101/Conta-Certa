using Conta_Certa.DTOs;
using System.Text.Json.Serialization;

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
    public float HonorarioTotal { get; }
    public CobrancaStatus Status { get; private set; }
    public DateTime Vencimento { get; private set; }
    public DateTime? PagoEm { get; private set; }
    public List<ServicoCobranca> ServicosCobranca { get; private set; } = [];

    [JsonConstructor]

    public Cobranca(long idCobranca, ClienteResumoDTO cliente, float honorario, CobrancaStatus status, DateTime vencimento, DateTime? pagoEm, List<ServicoCobranca>? servicos = null)
    {
        IdCobranca = idCobranca;
        Cliente = cliente;
        Honorario = honorario;
        HonorarioTotal = honorario;
        Status = status;
        Vencimento = vencimento;
        PagoEm = pagoEm;
        
        if (servicos != null)
        {
            ServicosCobranca = servicos;

            foreach (var servicoCobranca in ServicosCobranca)
            {
                HonorarioTotal += 
                    servicoCobranca.Servico.Valor * servicoCobranca.Quantidade;
            }
        }
    }
}
