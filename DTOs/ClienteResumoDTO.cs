using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public record ClienteResumoDTO
{
    public string Nome { get; }
    public string Documento { get; }

    public ClienteResumoDTO(string documento, string nome)
    {
        Documento = documento;
        Nome = nome;
    }

    public override string ToString()
    {
        return $"{Nome} - {Cliente.FormatDocumento(Documento)}";
    }
}
