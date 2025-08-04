using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public record ServicoCadDTO
{
    public string Nome { get; }
    public float Valor { get; }

    public ServicoCadDTO(string nome, float valor)
    {
        Nome = nome;
        Valor = valor;
    }

    public ServicoCadDTO(Servico servico)
    {
        Nome = servico.Nome;
        Valor = servico.Valor;
    }
}
