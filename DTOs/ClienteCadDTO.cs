
namespace Conta_Certa.DTOs;

public record ClienteCadDTO
{
    public string? Documento { get; set; }
    public string? Nome { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public float? Honorario { get; set; }
    public int? VencimentoHonorario { get; set; }

    public ClienteCadDTO() { }

    public ClienteCadDTO(string documento, string nome, string telefone, string? email, float honorario, int vencimentoHonorario)
    {
        Nome = nome;
        Documento = documento;
        Telefone = telefone;
        Email = email;
        Honorario = honorario;
        VencimentoHonorario = vencimentoHonorario;
    }

    public bool IsFull()
    {
        return (
            Documento != null &&
            Nome != null &&
            Telefone != null &&
            Honorario != null &&
            VencimentoHonorario != null
        );
    }
}
