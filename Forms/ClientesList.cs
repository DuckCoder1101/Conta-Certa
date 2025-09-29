using Conta_Certa.Components;
using Conta_Certa.DataProviders;
using Conta_Certa.Models;
using Microsoft.EntityFrameworkCore;

namespace Conta_Certa.Forms;

public partial class ClientesList : Form
{
    private readonly ClienteDataProvider _provider;
    private readonly AppDBContext _dbContext;

    private readonly LazyPanel<Cliente> _lazyPanel;

    public ClientesList()
    {
        InitializeComponent();

        _dbContext = new();
        _provider = new(_dbContext);

        _lazyPanel = new()
        {
            Dock = DockStyle.Fill
        };

        // ALTERAÇÃO E EXCLUSÃO
        _lazyPanel.ItemChange += OnItemChanged;
        _lazyPanel.ItemDelete += OnItemDeleted;

        // COLUNAS
        _lazyPanel.SetProvider(_provider);
        _lazyPanel.SetColumns([
            new() { Header = "Documento", ValueSelector = c => c.Documento, OrderBySelector = c => c.Documento },
            new() { Header = "Nome", ValueSelector = c => c.Nome, OrderBySelector = c => c.Nome },
            new() { Header = "Telefone", ValueSelector = c => c.Telefone, OrderBySelector = c => c.Telefone },
            new() { Header = "Email", ValueSelector = c => c.Email ?? "-", OrderBySelector = c => c.Email },
            new() { Header = "Honorário", ValueSelector = c => c.Honorario.ToString("c"), OrderBySelector = c => c.Honorario },
            new() { Header = "Vencimento honorário", ValueSelector = c => c.VencimentoHonorario.ToString(), OrderBySelector = c => c.VencimentoHonorario, Alignment = StringAlignment.Center }]);

        // DATA PROVIDER

        tablePanel.Controls.Add(_lazyPanel);

        // SEARCHBAR
        searchbar.FilterChanged += (filter) =>
        {
            _provider.Filter = c =>
                EF.Functions.Like(c.Nome, filter + "%")||
                EF.Functions.Like(c.Documento, filter);

            _lazyPanel.RemakeCache();
        };

        searchbar.AddButtonClicked += () =>
        {
            using ManageCliente form = new();
            DialogResult dialogResult = form.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                _lazyPanel.RemakeCache();
            }
        };
    }

    private void OnItemChanged(object? sender, Cliente cliente)
    {

        using ManageCliente form = new(cliente);
        DialogResult dialogResult = form.ShowDialog();

        if (dialogResult == DialogResult.OK && form.Cliente != null)
        {
            _lazyPanel.RemakeCache();
        }
    }

    private void OnItemDeleted(object? sender, Cliente cliente)
    {
        _dbContext.Clientes.Remove(cliente);
        _dbContext.SaveChanges();

        _lazyPanel.RemakeCache();
    }
}
