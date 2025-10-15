using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Conta_Certa.DTOs;

namespace Conta_Certa.Models;

public enum CobrancaStatus
{
    Pendente,
    Paga
};

public class Cobranca
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long IdCobranca { get; set; }

    [Required]
    public float Honorario { get; set; }

    [NotMapped]
    public float HonorarioTotal => Honorario + ServicosCobranca?.Sum(sc => sc.Valor * sc.Quantidade) ?? 0;

    [Required]
    public CobrancaStatus Status { get; set; }

    [Required]
    public DateTime Vencimento { get; set; }

    public DateTime? PagoEm { get; set; }

    // Relacionamento cliente
    [Required]
    public string DocumentoCliente { get; set; } = string.Empty;
    public Cliente? Cliente { get; set; } = null;

    // Relacionamento servicos
    public ICollection<ServicoCobranca> ServicosCobranca { get; set; } = [];

    // Construtor vazio para EF
    public Cobranca() { }

    public Cobranca(string documentoCliente, float honorario, CobrancaStatus status, DateTime vencimento, DateTime? pagoEm, ICollection<ServicoCobranca>? scs = null)
    {
        DocumentoCliente = documentoCliente;
        Honorario = honorario;
        Status = status;
        Vencimento = vencimento;
        PagoEm = pagoEm;

        if (scs != null)
        {
            ServicosCobranca = scs;
        }
    }

    public Cobranca(CobrancaJSONDTO dto)
    {
        DocumentoCliente = dto.DocumentoCliente;
        Honorario = dto.Honorario;
        Status = dto.Status;
        Vencimento = dto.Vencimento;
        PagoEm = dto.PagoEm;
        ServicosCobranca = [.. dto.ServicosCobranca.Select(dto => new ServicoCobranca(dto))];
    }
}