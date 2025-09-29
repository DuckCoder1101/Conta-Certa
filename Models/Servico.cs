using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conta_Certa.Models;

public class Servico
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? IdServico { get; private set; }

    [Required]
    [Index(IsUnique = true)]
    public string Nome { get; private set; } = string.Empty;

    [Required]
    public float Valor { get; private set; }

    public Servico() { }

    public Servico(string nome, float valor)
    {
        Nome = nome;
        Valor = valor;
    }

    public void SetId(long? id)
    {
        IdServico = id;
    }
}
