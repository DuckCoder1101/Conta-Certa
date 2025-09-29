namespace Conta_Certa.Models;

public class AppData
{
    public ICollection<Cliente> Clientes { set; get; }
    public ICollection<Cobranca> Cobrancas { set; get; }
    public ICollection<Servico> Servicos { set; get; }

    public AppData()
    {
        using AppDBContext dbContext = new();

        Clientes = dbContext.Clientes.ToList();
        Cobrancas = dbContext.Cobrancas.ToList();
        Servicos = dbContext.Servicos.ToList();
    }
}
