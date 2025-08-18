using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public record CobrancaWhatsappDTO
{
    public string Telefone { get; }
    public string Vencimento { get; }
    public float Valor { get; }
    public string Nome { get; }

    public CobrancaWhatsappDTO(Cobranca cobranca)
    {
        var vencimento = cobranca.Vencimento.ToString("dd/MM");
        Telefone = $"55{cobranca.Cliente.Telefone}";
        Vencimento = cobranca.Vencimento.ToString("dd/MM/yyyy");
        Valor = cobranca.HonorarioTotal;
        Nome = cobranca.Cliente.Nome;
    }
}
