
using Conta_Certa.DAOs;

namespace Conta_Certa.Models;

public class AppData
{
    public List<Cliente> Clientes { get; }
    public List<Cobranca> Cobrancas { get; }
    public List<Servico> Servicos { get; }

    public AppData()
    {
        Clientes = ClienteDAO.SelectAllClientes();
        Cobrancas = CobrancaDAO.SelectAllCobrancas();
        Servicos = ServicoDAO.SelectAllServicos();
    }
}
