using Conta_Certa.DAOs;
using Conta_Certa.DTOs;

namespace Conta_Certa.Models;

public class AppData
{
    public List<ClienteJSONDTO> Clientes { set; get; }
    public List<CobrancaJSONDTO> Cobrancas { set; get; }
    public List<ServicoJSONDTO> Servicos { set; get; }

    public AppData()
    {
        Clientes =  [..ClienteDAO.GetAllClientes().Select(c => new ClienteJSONDTO(c))];
        Cobrancas = [..CobrancaDAO.GetAllCobrancas().Select(c => new CobrancaJSONDTO(c))];
        Servicos =  [..ServicoDAO.GetAllServicos().Select(s => new ServicoJSONDTO(s))];
    }
}
