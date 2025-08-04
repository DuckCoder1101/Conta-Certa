using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public record ClienteCadDTO
{
    public string? Nome { get; set; }

    public string? Documento { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public float? Honorario { get; set; }
    public int? VencimentoHonorario { get; set; }

    public ClienteCadDTO()
    {

    }

    public ClienteCadDTO(string nome, string documento, string telefone, string? email, float honorario, int vencimentoHonorario)
    {
        Nome = nome;
        Documento = documento;
        Telefone = telefone;
        Email = email;
        Honorario = honorario;
        VencimentoHonorario = vencimentoHonorario;
    }

    public ClienteCadDTO(Cliente cliente)
    {
        Nome = cliente.Nome;
        Documento = cliente.Documento;
        Telefone = cliente.Telefone;
        Email = cliente.Email;
        Honorario = cliente.Honorario;
        VencimentoHonorario = cliente.VencimentoHonorario;
    }

    public bool IsFull()
    {
        return (
            Nome != null && 
            Documento != null &&
            Telefone != null && 
            Honorario != null && 
            VencimentoHonorario != null
        );
    }
}
