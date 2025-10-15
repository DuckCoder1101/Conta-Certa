using Conta_Certa.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conta_Certa.Models;

public class ServicoCobranca
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long IdServicoCobranca { get; private set; }

    [Required]
    public long IdServicoOrigem { get; private set; }

    [Required]
    public string Nome { get; private set; } = string.Empty;

    [Required]
    public float Valor { get; private set; }

    [Required]
    public int Quantidade { get; private set; } = 0;

    // Relacionamento
    public long IdCobranca { get; private set; }
    public Cobranca? Cobranca { get; private set; }

    public ServicoCobranca() { }

    public ServicoCobranca(ServicoCobrancaJSONDTO dto)
    {
        IdServicoOrigem = dto.TransitionIdServicoOrigem;
        Valor = dto.Valor;
        Quantidade = dto.Quantidade;
    }

    public ServicoCobranca(long idServicoOrigem, string nome, float valor, int quantidade)
    {
        IdServicoOrigem = idServicoOrigem;
        Nome = nome;
        Valor = valor;
        Quantidade = quantidade;
    }

    public void SetQuantidade(int quantidade)
    {
        Quantidade = quantidade;
    }
}
