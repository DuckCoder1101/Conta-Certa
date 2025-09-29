using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conta_Certa.Models;

public class ServicoCobranca
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long IdServico { get; private set; }

    [Required]
    public string Nome { get; private set; } = string.Empty;

    [Required]
    public float Valor { get; private set; }

    [Required]
    public int Quantidade { get; private set; } = 0;

    // Relacionamento
    public long IdCobranca { get; private set; }
    public Cobranca? Cobranca { get; private set; }

    public ServicoCobranca(long idServico, string nome, float valor, int quantidade)
    {
        IdServico = idServico;
        Nome = nome;
        Valor = valor;
        Quantidade = quantidade;
    }

    public void SetQuantidade(int quantidade)
    {
        Quantidade = quantidade;
    }
}
