using Conta_Certa.Components;
using Conta_Certa.DataProviders;
using Conta_Certa.Models;
using Microsoft.EntityFrameworkCore;

namespace Conta_Certa.Forms;

public partial class ServicoForm : Form
{
    private readonly LazyPanel<Servico> _lazyPanel;
    private readonly ServicoDataProvider _provider;
    private readonly AppDBContext _dbContext;

    public ServicoForm()
    {
        InitializeComponent();

        _dbContext = new();
        _provider = new(_dbContext);

        _lazyPanel = new()
        {
            Dock = DockStyle.Fill,
        };

        // ALTERAÇÃO E EXCLUSÃO
        _lazyPanel.ItemChange += OnItemChanged;
        _lazyPanel.ItemDelete += OnItemDeleted;

        // COLUNAS
        _lazyPanel.SetColumns([
            new() { Header = "Nome", ValueSelector = s => s.Nome, OrderBySelector = s => s.Nome,Alignment = StringAlignment.Center },
            new() { Header = "Valor", ValueSelector = s => s.Valor.ToString("c"), OrderBySelector = s => s.Valor, Alignment = StringAlignment.Center } ]);

        // DATA PROVIDER
        _lazyPanel.SetProvider(_provider);

        tablePanel.Controls.Add(_lazyPanel);

        // SEARCHBAR
        searchbar.FilterChanged += (filter) =>
        {
            _provider.Filter = s =>
                EF.Functions.Like(s.Nome, filter + "%") ||
                EF.Functions.Like(s.IdServico.ToString(), filter + "%");

            _lazyPanel.RemakeCache();
        };

        searchbar.AddButtonClicked += () =>
        {
            using ManageServico form = new();
            DialogResult dialogResult = form.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                _lazyPanel.RemakeCache();
            }
        };
    }

    private void OnItemChanged(object? sender, Servico servico)
    {
        using ManageServico form = new(servico);
        DialogResult dialogResult = form.ShowDialog();

        if (dialogResult == DialogResult.OK && form.Servico != null)
        {
            _lazyPanel.RemakeCache();
        }
    }

    private void OnItemDeleted(object? sender, Servico servico)
    {
        _dbContext.Servicos.Remove(servico);
        _dbContext.SaveChanges();

        _lazyPanel.RemakeCache();
    }
}
