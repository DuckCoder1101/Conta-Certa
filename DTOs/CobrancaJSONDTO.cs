using Conta_Certa.Models;

namespace Conta_Certa.DTOs;

public class CobrancaJSONDTO
{
    public string DocumentoCliente { get; set; } = string.Empty;
    public float Honorario { get; set; }
    public CobrancaStatus Status { get; set; }
    public DateTime Vencimento { get; set; }
    public DateTime? PagoEm { get; set; }

    public List<ServicoCobrancaJSONDTO> ServicosCobranca { get; set; } = [];

    public CobrancaJSONDTO() { }

    public CobrancaJSONDTO(Cobranca cobranca)
    {
        DocumentoCliente = cobranca.DocumentoCliente;
        Honorario = cobranca.Honorario;
        Status = cobranca.Status;
        Vencimento = cobranca.Vencimento;
        PagoEm = cobranca.PagoEm;
        ServicosCobranca = [.. cobranca.ServicosCobranca.Select(sc => new ServicoCobrancaJSONDTO(sc))];
    }
}
