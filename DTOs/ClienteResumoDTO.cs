using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public record ClienteResumoDTO
{
    public string Nome { get; }
    public string Documento { get; }
    public string Telefone { get; }

    public ClienteResumoDTO(string documento, string nome, string telefone)
    {
        Documento = documento;
        Nome = nome;
        Telefone = telefone;
    }

    public override string ToString()
    {
        return $"{Nome} - {Cliente.FormatDocumento(Documento)}";
    }
}
