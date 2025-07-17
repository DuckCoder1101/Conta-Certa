namespace Conta_Certa.DTOs;

public record ClienteCadDTO
{
    public string Nome { get; }
    public string Telefone { get; }
    public string? Email { get; }
    public float Honorario { get; }
    public int VencimentoHonorario { get; }

    public ClienteCadDTO(string nome, string telefone, string? email, float honorario, int vencimentoHonorario)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Honorario = honorario;
        VencimentoHonorario = vencimentoHonorario;
    }
}
