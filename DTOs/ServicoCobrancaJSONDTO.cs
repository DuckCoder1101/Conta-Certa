using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public class ServicoCobrancaJSONDTO
{
    public long TransitionIdServicoOrigem { get; set; }
    public string Nome { get; set; } = string.Empty;
    public float Valor { get; set; }
    public int Quantidade { get; set; } = 0;

    public ServicoCobrancaJSONDTO() { }

    public ServicoCobrancaJSONDTO(ServicoCobranca servicoCobranca)
    {
        TransitionIdServicoOrigem = servicoCobranca.IdServicoOrigem;
        Nome = servicoCobranca.Nome;
        Valor = servicoCobranca.Valor;
        Quantidade = servicoCobranca.Quantidade;
    }
}
