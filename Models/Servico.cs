namespace Conta_Certa.Models;

public class Servico
{
    public long IdServico { get; }
    public string Nome { get; private set; }
    public float Valor { get; private set; }

    public Servico(long idServico, string nome, float valor)
    {
        IdServico = idServico;
        Nome = nome;
        Valor = valor;
    }
}
