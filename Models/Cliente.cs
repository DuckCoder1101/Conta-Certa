namespace Conta_Certa.Models;

public class Cliente
{
    public long IdCliente { get; }
    public string Nome { get; private set; }
    public string Telefone { get; private set; }
    public string? Email { get; private set; }
    public float Honorario { get; private set; }
    public int VencimentoHonorario { get; private set; }

    public Cliente(long idCliente, string nome, string telefone, string email, float honorario, int vencimentoHonorario)
    {
        
        IdCliente = idCliente;
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Honorario = honorario;
        VencimentoHonorario = vencimentoHonorario;
    }
}
