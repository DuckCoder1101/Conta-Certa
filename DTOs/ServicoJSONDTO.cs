using Conta_Certa.Models;
using System.Text.Json.Serialization;

namespace Conta_Certa.DTOs;

public class ServicoJSONDTO
{
    public long TransitionIdServico { get; set; }
    public string Nome { get; set; }
    public float Valor { get; set; }

    [JsonConstructor]
    public ServicoJSONDTO(string nome, float valor)
    {
        Nome = nome;
        Valor = valor;
    }

    public ServicoJSONDTO(Servico servico)
    {
        TransitionIdServico = servico.IdServico;
        Nome = servico.Nome;
        Valor = servico.Valor;
    }
}
