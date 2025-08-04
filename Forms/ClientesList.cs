using Conta_Certa.DAOs;
using Conta_Certa.Models;
using Conta_Certa.UserControls;
using Conta_Certa.Utils;

namespace Conta_Certa.Forms;

public partial class ClientesList : Form
{
    private List<Cliente> clientes = [];
    private ClienteControl? currentControl = null;

    private OrderBy order = OrderBy.ID;
    private string filter = "";

    public ClientesList()
    {
        InitializeComponent();

        searchbar.FilterChanged += OnSearchbarFilterChanged;
        searchbar.OrderChanged += OnSearchbarOrderValueChanged;
        searchbar.AddButtonClicked += OnAddButtonClicked;

        UpdateClientesList();
    }

    private List<Cliente> GetSortedClientes()
    {
        switch (order)
        {
            case OrderBy.Nome:
                return [.. clientes.OrderBy(c => c.Nome)];

            case OrderBy.Valor:
                return [.. clientes.OrderBy(c => c.Honorario)];

            default:
                return [.. clientes.OrderBy(c => c.IdCliente)];
        }
    }

    private void UpdateClientesList()
    {
        clientes = ClienteDAO.SelectAllClientes();
        UpdateClientesPanel();
    }

    private void UpdateClientesPanel()
    {
        clientesPanel.Controls.Clear();

        // Guia
        ClienteControl guide = new(null)
        {
            Dock = DockStyle.Top
        };

        clientesPanel.Controls.Add(guide);
        clientesPanel.Controls.SetChildIndex(guide, 0);

        foreach (var cliente in GetSortedClientes())
        {
            if (cliente.Nome.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase))
            {
                ClienteControl control = new(cliente)
                {
                    Dock = DockStyle.Top,
                };

                clientesPanel.Controls.Add(control);
                clientesPanel.Controls.SetChildIndex(control, 0);
            }
        }
    }

    private void Alterar_Menu_Click(object sender, EventArgs e)
    {
        if (currentControl?.Cliente != null)
        {
            using ManageCliente form = new(currentControl.Cliente);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateClientesList();
            }
        }
    }

    private void Excluir_Menu_Click(object sender, EventArgs e)
    {
        if (currentControl?.Cliente != null)
        {
            var message = 
                "Deseja mesmo excluir este cliente?\nEsta ação é irreversível e apagará também as outras informações associadas a ele";

            DialogResult result = MessageBox.Show(
                message,
                "Excluir cliente?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ClienteDAO.DeleteCliente(currentControl.Cliente);

                clientes.Remove(currentControl.Cliente);
                currentControl.Dispose();
            }
        }
    }

    private void OnSearchbarOrderValueChanged(string rawOrder)
    {
        OrderBy order = Enum.Parse<OrderBy>(rawOrder);
        if (this.order != order)
        {
            this.order = order;
            UpdateClientesPanel();
        }
    }

    private void OnSearchbarFilterChanged(string filter)
    {
        this.filter = filter;
        UpdateClientesPanel();
    }

    private void OnAddButtonClicked()
    {
        using ManageCliente form = new();
        DialogResult result = form.ShowDialog();

        if (result == DialogResult.OK)
        {
            UpdateClientesList();
        }
    }

    private void ClientesList_FormClosing(object sender, FormClosingEventArgs e)
    {
        searchbar.FilterChanged -= OnSearchbarFilterChanged;
        searchbar.OrderChanged -= OnSearchbarOrderValueChanged;
        searchbar.AddButtonClicked -= OnAddButtonClicked;
    }

    public void OpenContextMenu(ClienteControl control)
    {
        currentControl = control;
        menu.Show(Cursor.Position);
    }
}
