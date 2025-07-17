using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public class ServicoCobrancaCadDTO
{
    public long IdCobranca { get; }
    public long IdServico { get; }
    public float Valor { get; }
    public int Quantidade { get; }

    public ServicoCobrancaCadDTO(long idCobranca, long idServico, float valor, int quantidade)
    {
        IdCobranca = idCobranca;
        IdServico = idServico;
        Valor = valor;
        Quantidade = quantidade;
    }

    public ServicoCobrancaCadDTO(Servico servico, long idCobranca, int quantidade)
    {
        IdCobranca = idCobranca;
        IdServico = servico.IdServico;
        Valor = servico.Valor;
        Quantidade = quantidade;
    }
}
