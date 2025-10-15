using Conta_Certa.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Conta_Certa.Models;

public class AppData
{
    public ICollection<ClienteCadDTO> Clientes { set; get; }
    public ICollection<CobrancaCadDTO> Cobrancas { set; get; }
    public ICollection<ServicoCadDTO> Servicos { set; get; }

    public AppData()
    {
        using AppDBContext dbContext = new();

        Clientes = [.. dbContext.Clientes.Select(c => new ClienteCadDTO(c))];
        Cobrancas = [.. 
            dbContext.Cobrancas
                .Include(c => c.ServicosCobranca)
                .Select(c => new CobrancaCadDTO(c))
        ];

        Servicos = [.. dbContext.Servicos.Select(s => new ServicoCadDTO(s))];
    }
}
