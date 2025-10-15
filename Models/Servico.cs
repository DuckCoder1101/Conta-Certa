using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Conta_Certa.DTOs;

namespace Conta_Certa.Models;

public class Servico
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long IdServico { get; set; }

    [Required]
    [Index(IsUnique = true)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public float Valor { get; set; }

    public Servico() { }

    public Servico(string nome, float valor)
    {
        Nome = nome;
        Valor = valor;
    }

    public Servico(ServicoJSONDTO dto)
    {
        Nome = dto.Nome;
        Valor = dto.Valor;
    }
}