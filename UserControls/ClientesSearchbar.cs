using Conta_Certa.DAOs;
using Conta_Certa.DTOs;

namespace Conta_Certa.UserControls;

public partial class ClientesSearch : UserControl
{
    ClienteSearchbarItem? selectedItem;
    List<ClienteResumoDTO> clientes;

    public ClientesSearch()
    {
        InitializeComponent();

        clientes = ClienteDAO.SelectAllClientesResumos();
        clientes = [.. clientes.OrderBy(c => c.Nome)];

        UpdateClientesList();
    }

    private void UpdateClientesList(string filter = "")
    {
        clientesList.Controls.Clear();

        foreach (var cliente in clientes)
        {
            if (cliente.Nome.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase) ||
                cliente.IdCliente.ToString().StartsWith(filter) ||
                cliente.Documento.StartsWith(filter))
            {
                ClienteSearchbarItem item = new(cliente);

                clientesList.Controls.Add(item);
                clientesList.Controls.SetChildIndex(item, 0);
            }
        }
    }

    private void SearchBar_TextChanged(object sender, EventArgs e)
    {
        UpdateClientesList(searchBar.Text);
    }
}
