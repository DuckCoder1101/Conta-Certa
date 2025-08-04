using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public record ClienteResumoDTO
{
    public long IdCliente { get; }
    public string Nome { get; }
    public string Documento { get; }

    public ClienteResumoDTO(long idCliente, string nome, string documento)
    {
        Nome = nome;
        IdCliente = idCliente;
        Documento = Cliente.FormatDocumento(documento);
    }

    public override string ToString()
    {
        return $"{Nome} - {Documento} - ID: {IdCliente}";
    }
}
