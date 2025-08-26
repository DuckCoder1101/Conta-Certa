using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public record ServicoCobrancaCadDTO
{
    public long IdCobranca { get; set; }
    public long IdServico { get; set; }
    public float Valor { get; set; }
    public int Quantidade { get; set; }

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

    public ServicoCobrancaCadDTO(ServicoCobranca servicoCobranca, long idCobranca, long idServico)
    {
        IdCobranca = idCobranca;
        IdServico = idServico;
        Valor = servicoCobranca.Servico.Valor;
        Quantidade = servicoCobranca.Quantidade;
    }
}
