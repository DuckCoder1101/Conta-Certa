
namespace Conta_Certa.Models;

public class ServicoCobranca
{
    public long IdServicoCobranca { get; }
    public long IdCobranca { get; }
    public Servico Servico { get; }
    public int Quantidade { get; set; } = 0;

    public ServicoCobranca(long idServicoCobranca, long idCobranca, Servico servico, int quantidade)
    {
        IdServicoCobranca = idServicoCobranca;
        IdCobranca = idCobranca;
        Servico = servico;
        Quantidade = quantidade;
    }
}
