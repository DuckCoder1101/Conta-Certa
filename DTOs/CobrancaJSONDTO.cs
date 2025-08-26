using Conta_Certa.Models;
using System.Text.Json.Serialization;

namespace Conta_Certa.DTOs;

public class CobrancaJSONDTO
{
    public long TransitionIdCobranca { get; set; }
    public string DocumentoCliente { get; set; }
    public float Honorario { get; set; }
    public CobrancaStatus Status { get; set; }
    public DateTime Vencimento { get; set; }
    public DateTime? PagoEm { get; set; }

    public List<ServicoCobrancaJSONDTO> ServicosCobranca { get; set; }

    [JsonConstructor]
    public CobrancaJSONDTO(long transitionIdCobranca, string documentoCliente, float honorario, CobrancaStatus status, DateTime vencimento, DateTime? pagoEm, List<ServicoCobrancaJSONDTO> servicosCobranca)
    {
        TransitionIdCobranca = transitionIdCobranca;
        DocumentoCliente = documentoCliente;
        Honorario = honorario;
        Status = status;
        Vencimento = vencimento;
        PagoEm = pagoEm;
        ServicosCobranca = servicosCobranca;
    }

    public CobrancaJSONDTO(Cobranca cobranca)
    {
        TransitionIdCobranca = cobranca.IdCobranca;
        DocumentoCliente = cobranca.Cliente.Documento;
        Honorario = cobranca.Honorario;
        Status = cobranca.Status;
        Vencimento = cobranca.Vencimento;
        PagoEm = cobranca.PagoEm;
        ServicosCobranca = [..cobranca.ServicosCobranca.Select(sc => 
            new ServicoCobrancaJSONDTO(sc.Servico, sc.Quantidade))];
    }
}
