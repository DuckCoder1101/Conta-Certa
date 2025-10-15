using Conta_Certa.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Conta_Certa.Models;

public class AppData
{
    public ICollection<ClienteJSONDTO> Clientes { get; set; }
    public ICollection<CobrancaJSONDTO> Cobrancas { get; set; }
    public ICollection<ServicoJSONDTO> Servicos { get; set; }

    public AppData()
    {
        using AppDBContext dbContext = new();

        Clientes =  [.. dbContext.Clientes.Select(c => new ClienteJSONDTO(c))];
        Cobrancas = [
            .. dbContext.Cobrancas
                .Include(c => c.ServicosCobranca)
                .Select(c => new CobrancaJSONDTO(c))];
        Servicos =  [.. dbContext.Servicos.Select(s => new ServicoJSONDTO(s))];
    }
}
