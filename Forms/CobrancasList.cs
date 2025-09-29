using Conta_Certa.Components;
using Conta_Certa.DataProviders;
using Conta_Certa.Models;
using Microsoft.EntityFrameworkCore;

namespace Conta_Certa.Forms;

public partial class CobrancasList : Form
{
    private readonly LazyPanel<Cobranca> _lazyPanel;
    private readonly CobrancaDataProvider _provider;
    private readonly AppDBContext _dbContext;

    public CobrancasList(CobrancaStatus status = CobrancaStatus.Pendente)
    {
        InitializeComponent();

        _dbContext = new();
        _provider = new(_dbContext, status);

        _lazyPanel = new()
        {
            Dock = DockStyle.Fill,
        };

        // ALTERAÇÃO E EXCLUSÃO
        _lazyPanel.ItemChange += OnItemChanged;
        _lazyPanel.ItemDelete += OnItemDeleted;

        // COLUNAS
        _lazyPanel.SetColumns([
            new() { Header = "ID", ValueSelector = c => c.IdCobranca?.ToString() ?? "", OrderBySelector = c => c.IdCobranca, Alignment = StringAlignment.Center },
            new() { Header = "Cliente", ValueSelector = c => c.Cliente!.Nome, OrderBySelector = c => c.Cliente!.Nome },
            new() { Header = "Honorário Total", ValueSelector = c => c.HonorarioTotal.ToString("c"), OrderBySelector = c => c.HonorarioTotal },
            new() { Header = "Status", ValueSelector = c => c.Status.ToString(), OrderBySelector = c => c.Status, Alignment = StringAlignment.Center },
            new() { Header = "Vencimento", ValueSelector = c => c.Vencimento.ToString("dd/MM/yy"), OrderBySelector = c => c.Vencimento, Alignment = StringAlignment.Center },
            new() { Header = "Pago em", ValueSelector = c => c.PagoEm != null ? ((DateTime)c.PagoEm).ToString("dd/MM/yy") : "-", OrderBySelector = c => c.PagoEm, Alignment = StringAlignment.Center }]);

        // DATA PROVIDER
        _lazyPanel.SetProvider(_provider);

        tablePanel.Controls.Add(_lazyPanel);

        // SEARCHBAR
        searchbar.FilterChanged += (filter) =>
        {
            _provider.Filter = c =>
                EF.Functions.Like(c.Cliente!.Nome, filter + "%") ||
                EF.Functions.Like(c.IdCobranca.ToString(), filter + "%");

            _lazyPanel.RemakeCache();
        };

        searchbar.AddButtonClicked += () =>
        {
            using ManageCobranca form = new();
            DialogResult dialogResult = form.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                _lazyPanel.RemakeCache();
            }
        };
    }

    private void OnItemChanged(object? sender, Cobranca cobranca)
    {
        using ManageCobranca form = new(cobranca);
        DialogResult dialogResult = form.ShowDialog();

        if (dialogResult == DialogResult.OK && form.Cobranca != null)
        {
            _lazyPanel.RemakeCache();
        }
    }

    private void OnItemDeleted(object? sender, Cobranca cobranca)
    {
        _dbContext.Cobrancas.Remove(cobranca);
        _dbContext.SaveChanges();

        _lazyPanel.RemakeCache();
    }
}
