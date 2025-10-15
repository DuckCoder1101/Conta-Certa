
using Conta_Certa.Models;

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

    public ClienteCadDTO(Cliente cliente)
    {
        Documento = cliente.Documento;
        Nome = cliente.Nome;
        Telefone = cliente.Telefone;
        Email = cliente.Email;
        Honorario = cliente.Honorario;
        VencimentoHonorario = cliente.VencimentoHonorario
    }

    public ClienteCadDTO(string documento, string nome, string telefone, string? email, float honorario, int vencimentoHonorario)
    {
        Documento = documento;
        Nome = nome;
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
