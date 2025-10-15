using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public class ServicoJSONDTO
{
    public long TransitionIdServico { get; set; }
    public string Nome { get; set; } = string.Empty;
    public float Valor { get; set; }

    public ServicoJSONDTO() { }

    public ServicoJSONDTO(Servico servico)
    {
        TransitionIdServico = servico.IdServico;
        Nome = servico.Nome;
        Valor = servico.Valor;
    }
}
