using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using System.Diagnostics;

namespace Conta_Certa.UserControls;

public partial class ClientesSearchbar : UserControl
{
    private readonly List<ClienteResumoDTO> clientes = [];

    public event Action<Cliente?>? OnClienteChange;

    public ClientesSearchbar()
    {
        InitializeComponent();

        clientes = ClienteDAO.SelectAllClientesResumos();
        clientes = [.. clientes.OrderBy(c => c.Nome)];

        UpdateClientesList();
    }

    private void UpdateClientesList(string filter = "")
    {
        clientesCB.BeginUpdate();
        clientesCB.Items.Clear();

        foreach (var cliente in clientes)
        {
            if (cliente.Nome.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase) ||
                cliente.Documento.StartsWith(filter))
            {
                clientesCB.Items.Add(cliente);
            }
        }

        clientesCB.EndUpdate();

        if (clientesCB.SelectedItem == null)
        {
            OnClienteChange?.Invoke(null);
        }
    }

    private void Searchbar_TextChanged(object sender, EventArgs e)
    {
        UpdateClientesList(searchbar.Text.Trim());
    }

    public void SelectCliente(string documento)
    {
        clientesCB.SelectedItem = clientesCB.Items
            .OfType<ClienteResumoDTO>()
            .First(c => c.Documento == documento);
    }

    private void ClientesCB_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cliente? cliente = null;

        if (clientesCB.SelectedItem is ClienteResumoDTO clienteResumo)
        {
            cliente = ClienteDAO.GetClienteByDocumento(clienteResumo.Documento);
        }
        
        OnClienteChange?.Invoke(cliente);
    }
}
