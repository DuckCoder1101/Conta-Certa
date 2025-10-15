
using Conta_Certa.Models;

namespace Conta_Certa.DTO;

public class ClienteJSONDTO
{
    public string Documento { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string? Email { get; set; }
    public float Honorario { get; set; }
    public int VencimentoHonorario { get; set; }

    public ClienteJSONDTO() { }

    public ClienteJSONDTO(Cliente cliente)
    {
        Nome = cliente.Nome;
        Documento = cliente.Documento;
        Telefone = cliente.Telefone;
        Email = cliente.Email;
        Honorario = cliente.Honorario;
        VencimentoHonorario = cliente.VencimentoHonorario;
    }
}
