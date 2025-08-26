using Conta_Certa.Models;
using System.Text.Json.Serialization;

namespace Conta_Certa.DTOs;

public class ClienteJSONDTO
{

    public string Documento { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string? Email { get; set; }
    public float Honorario { get; set; }
    public int VencimentoHonorario { get; set; }

    [JsonConstructor]
    public ClienteJSONDTO(string documento, string nome, string telefone, string email, float honorario, int vencimentoHonorario)
    {
        Documento = documento;
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Honorario = honorario;
        VencimentoHonorario = vencimentoHonorario;
    }

    public ClienteJSONDTO(Cliente cliente)
    {
        Documento = cliente.Documento;
        Nome = cliente.Nome;
        Telefone = cliente.Telefone;
        Email = cliente.Email;
        Honorario = cliente.Honorario;
        VencimentoHonorario = cliente.VencimentoHonorario;
    }
}
