using Conta_Certa.Components;
using Conta_Certa.DAOs;
using Conta_Certa.Models;

namespace Conta_Certa.Forms;

public partial class CobrancasList : Form
{
    private List<Cobranca> _cobrancas = [];
    private readonly LazyPanel<Cobranca> _lazyPanel;
    private readonly CobrancaStatus _status;

    public CobrancasList(CobrancaStatus status = CobrancaStatus.Pendente)
    {
        InitializeComponent();

        _status = status;
        _cobrancas = CobrancaDAO.GetCobrancasByStatus(status);

        _lazyPanel = new()
        {
            Dock = DockStyle.Fill,
            Filter = (c) =>
            {
                string filter = searchbar.Filter;
                return c.IdCobranca.ToString().StartsWith(filter) || 
                    c.Cliente.Nome.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase) ||
                    c.HonorarioTotal.ToString().StartsWith(filter);
            }
        };

        // ALTERAÇÃO E EXCLUSÃO
        _lazyPanel.ItemChange += OnMenuAlterarClicked;
        _lazyPanel.ItemDelete += OnMenuExcluirClicked;

        // COLUNAS
        _lazyPanel.SetColumns([
            new() { Header = "ID", ValueSelector = c => c.IdCobranca.ToString(), Alignment = StringAlignment.Center },
            new() { Header = "Cliente", ValueSelector = c => c.Cliente.Nome },
            new() { Header = "Honorário Total", ValueSelector = c => c.HonorarioTotal.ToString("c") },
            new() { Header = "Status", ValueSelector = c => c.Status.ToString(), Alignment = StringAlignment.Center },
            new() { Header = "Vencimento", ValueSelector = c => c.Vencimento.ToString("dd/MM/yy"), Alignment = StringAlignment.Center },
            new() { Header = "Pago em", ValueSelector = c => c.PagoEm != null ? ((DateTime)c.PagoEm).ToString("dd/MM/yy") : "-", Alignment = StringAlignment.Center }]);

        // ITENS
        _lazyPanel.SetItems(_cobrancas);
        tablePanel.Controls.Add(_lazyPanel);

        // SEARCHBAR
        searchbar.FilterChanged += (newFilter) =>
        {
            _lazyPanel.SortItems();
        };

        searchbar.AddButtonClicked += () =>
        {
            using ManageCobranca form = new();
            DialogResult dialogResult = form.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                _cobrancas = CobrancaDAO.GetAllCobrancas();
                _lazyPanel.SetItems(_cobrancas);
            }
        };
    }

    private void OnMenuAlterarClicked(object? sender, Cobranca cobranca)
    {
        using ManageCobranca form = new(cobranca);
        DialogResult dialogResult = form.ShowDialog();

        if (dialogResult == DialogResult.OK)
        {
            _cobrancas = CobrancaDAO.GetCobrancasByStatus(_status);   
            _lazyPanel.SetItems(_cobrancas);
        }
    }

    private void OnMenuExcluirClicked(object? sender, Cobranca cobranca)
    {
        CobrancaDAO.DeleteCobranca(cobranca);

        _cobrancas.Remove(cobranca);
        _lazyPanel.SetItems(_cobrancas);
    }
}
