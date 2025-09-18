using Conta_Certa.Components;
using Conta_Certa.DAOs;
using Conta_Certa.Models;

namespace Conta_Certa.Forms;

public partial class ClientesList : Form
{
    private List<Cliente> _clientes = [];
    private readonly LazyPanel<Cliente> _lazyPanel;

    public ClientesList()
    {
        InitializeComponent();

        _clientes = ClienteDAO.GetAllClientes();

        _lazyPanel = new()
        {
            Dock = DockStyle.Fill,
            Filter = (c) =>
            {
                string filter = searchbar.Filter;
                return c.Documento.StartsWith(filter) || c.Nome.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase);
            }
        };

        // ALTERAÇÃO E EXCLUSÃO
        _lazyPanel.ItemChange += OnMenuAlterarClicked;
        _lazyPanel.ItemDelete += OnMenuExcluirClicked;

        // COLUNAS
        _lazyPanel.SetColumns([
            new() { Header = "Documento", ValueSelector = c => c.Documento },
            new() { Header = "Nome", ValueSelector = c => c.Nome },
            new() { Header = "Telefone", ValueSelector = c => c.Telefone },
            new() { Header = "Email", ValueSelector = c => c.Email ?? "-" },
            new() { Header = "Honorário", ValueSelector = c => c.Honorario.ToString("c") },
            new() { Header = "Vencimento honorário", ValueSelector = c => c.VencimentoHonorario.ToString(), Alignment = StringAlignment.Center }]);

        // ITENS
        _lazyPanel.SetItems(_clientes);
        tablePanel.Controls.Add(_lazyPanel);

        // SEARCHBAR
        searchbar.FilterChanged += (newFilter) =>
        {
            _lazyPanel.SortItems();
        };

        searchbar.AddButtonClicked += () =>
        {
            using ManageCliente form = new();
            DialogResult dialogResult = form.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                _clientes = ClienteDAO.GetAllClientes();
                _lazyPanel.SetItems(_clientes);
            }
        };
    }

    private void OnMenuAlterarClicked(object? sender, Cliente cliente)
    {

        using ManageCliente form = new(cliente);
        DialogResult dialogResult = form.ShowDialog();

        if (dialogResult == DialogResult.OK && form.Result != null)
        {
            if (cliente.Documento == form.Result.Documento)
            {
                int index = _clientes.IndexOf(cliente);
                _clientes[index] = form.Result;
            }

            else
            {
                _clientes.Add(form.Result);
            }

            _lazyPanel.SetItems(_clientes);
        }
    }

    private void OnMenuExcluirClicked(object? sender, Cliente cliente)
    {
        ClienteDAO.DeleteCliente(cliente);

        _clientes.Remove(cliente);
        _lazyPanel.SetItems(_clientes);
    }
}
