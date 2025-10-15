using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public record ServicoCadDTO
{
    public long? TransitionIdServico { get; set; }
    public string? Nome { get; set; }
    public float? Valor { get; set; }

    public ServicoCadDTO() { }

    public ServicoCadDTO(Servico servico)
    {
        TransitionIdServico = servico.IdServico;
        Nome = servico.Nome;
        Valor = servico.Valor;
    }

    public ServicoCadDTO(string nome, float valor)
    {
        Nome = nome;
        Valor = valor;
    }
}
