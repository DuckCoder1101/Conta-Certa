
using Conta_Certa.Models;

namespace Conta_Certa.DTOs;


public record ServicoCobrancaCadDTO
{
    public long? TransitionIdServicoOrigem;
    public string? Nome { get; set; }
    public float? Valor { get; set; }
    public int? Quantidade { get; set; }

    public ServicoCobrancaCadDTO() { }

    public ServicoCobrancaCadDTO(ServicoCobranca sc)
    {
        TransitionIdServicoOrigem = sc.IdServicoOrigem;
        Nome = sc.Nome;
        Valor = sc.Valor;
        Quantidade = sc.Quantidade;
    }

    public ServicoCobrancaCadDTO(long transitionIdServico,  string nome, float valor, int quantidade)
    {
        TransitionIdServicoOrigem = transitionIdServico;
        Nome = nome;
        Valor = valor;
        Quantidade = quantidade;
    }
}
