using Conta_Certa.DTO;
using Conta_Certa.DTOs;

namespace Conta_Certa.Models;

public class AppData
{
    public ICollection<ClienteJSONDTO> Clientes { set; get; }
    public ICollection<CobrancaJSONDTO> Cobrancas { set; get; }
    public ICollection<ServicoJSONDTO> Servicos { set; get; }

    public AppData()
    {
        using AppDBContext dbContext = new();

        Clientes =  [.. dbContext.Clientes.Select(c => new ClienteJSONDTO(c))];
        Cobrancas = [.. dbContext.Cobrancas.Select(c => new CobrancaJSONDTO(c))];
        Servicos =  [.. dbContext.Servicos.Select(s => new ServicoJSONDTO(s))];
    }
}
