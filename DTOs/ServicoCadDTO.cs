
namespace Conta_Certa.DTOs;

public class ServicoCadDTO
{
    public string Nome { get; }
    public float Valor { get; }

    public ServicoCadDTO(string nome, float valor)
    {
        Nome = nome;
        Valor = valor;
    }
}
