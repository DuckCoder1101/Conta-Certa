using Conta_Certa.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public long? IdCobranca { get; private set; }

    [Required]
    public float Honorario { get; private set; }

    [NotMapped]
    public float HonorarioTotal => Honorario +
        ServicosCobranca?.Sum(sc => sc.Valor * sc.Quantidade) ?? 0;

    [Required]
    public CobrancaStatus Status { get; private set; }

    [Required]
    public DateTime Vencimento { get; private set; }

    public DateTime? PagoEm { get; private set; }

    // Relacionamento cliente
    [Required]
    public string DocumentoCliente { get; private set; } = string.Empty;
    public Cliente? Cliente { get; set; } = null;

    // Relacionamento servicos
    public ICollection<ServicoCobranca> ServicosCobranca { get; private set; } = [];

    // Construtor vazio para EF
    protected Cobranca() { }

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

    public Cobranca(CobrancaCadDTO dto)
    {
        Honorario = (float)dto.Honorario!;
        Status = (CobrancaStatus)dto.Status!;
        Vencimento = (DateTime)dto.Vencimento!;
        PagoEm = dto.PagoEm;
        DocumentoCliente = dto.DocumentoCliente!;
    }

    public void SetId(long? id)
    {
        IdCobranca = id;
    }

    public void Update(string documentoCliente, float honorario, CobrancaStatus status, DateTime vencimento, DateTime? pagoEm)
    {
        DocumentoCliente = documentoCliente;
        Honorario = honorario;
        Status = status;
        Vencimento = vencimento;
        PagoEm = pagoEm;
    }
}