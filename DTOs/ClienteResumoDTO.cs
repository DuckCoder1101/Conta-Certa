
namespace Conta_Certa.DTOs;

public class ClienteResumoDTO
{
    public long Id { get; }
    public string Nome { get; }

    public ClienteResumoDTO(long id, string nome)
    {
        Nome = nome;
        Id = id;
    }
}
