using Conta_Certa.DAOs;

namespace Conta_Certa.Models;

public class AppData
{
    public List<Cliente> Clientes { set; get; }
    public List<Cobranca> Cobrancas { set; get; }
    public List<Servico> Servicos { set; get; }

    public AppData()
    {
        Clientes = ClienteDAO.GetAllClientes();
        Cobrancas = CobrancaDAO.GetAllCobrancas();
        Servicos = ServicoDAO.SelectAllServicos();
    }
}
