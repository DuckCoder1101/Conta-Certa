using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public class ServicoCobrancaJSONDTO
{
    public long IdServico { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public float Valor { get; private set; }

    public Servico() { }

    public Servico(string nome, float valor)
    {
        Nome = nome;
        Valor = valor;
    }

    public void SetId(long id)
    {
        IdServico = id;
    }
}
