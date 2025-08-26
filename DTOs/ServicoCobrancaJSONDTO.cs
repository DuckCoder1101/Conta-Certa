using Conta_Certa.Models;
using System.Text.Json.Serialization;

namespace Conta_Certa.DTOs;

public class ServicoCobrancaJSONDTO
{
    public long IdServico { get; set; }
    public float Valor { get; set; }
    public int Quantidade { get; set; }

    [JsonConstructor]
    public ServicoCobrancaJSONDTO(long idServico, float valor, int quantidade)
    {
        IdServico = idServico;
        Valor = valor;
        Quantidade = quantidade;
    }

    public ServicoCobrancaJSONDTO(Servico @base, int quantidade)
    {
        IdServico = @base.IdServico;
        Valor = @base.Valor;
        Quantidade = quantidade;
    }
}
