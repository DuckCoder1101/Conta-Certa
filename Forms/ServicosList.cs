using Conta_Certa.Components;
using Conta_Certa.DAOs;
using Conta_Certa.Models;

namespace Conta_Certa.Forms;

public partial class ServicosList : Form
{
    private List<Servico> _servicos = [];
    private readonly LazyPanel<Servico> _lazyPanel;

    public ServicosList()
    {
        InitializeComponent();

        _servicos = ServicoDAO.GetAllServicos();

        _lazyPanel = new()
        {
            Dock = DockStyle.Fill,
            Filter = (s) =>
            {
                string filter = searchbar.Filter;
                return s.Nome.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase);
            }
        };

        // ALTERAÇÃO E EXCLUSÃO
        _lazyPanel.ItemChange += OnMenuAlterarClicked;
        _lazyPanel.ItemDelete += OnMenuExcluirClicked;

        // COLUNAS
        _lazyPanel.SetColumns([
            new() { Header = "Nome", ValueSelector = s => s.Nome, Alignment = StringAlignment.Center },
            new() { Header = "Honorário", ValueSelector = s => s.Valor.ToString("c"), Alignment = StringAlignment.Center } ]);

        // ITENS
        _lazyPanel.SetItems(_servicos);
        tablePanel.Controls.Add(_lazyPanel);

        // SEARCHBAR
        searchbar.FilterChanged += (newFilter) =>
        {
            _lazyPanel.SortItems();
        };

        searchbar.AddButtonClicked += () =>
        {
            using ManageServico form = new();
            DialogResult dialogResult = form.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                _servicos = ServicoDAO.GetAllServicos();
                _lazyPanel.SetItems(_servicos);
            }
        };
    }

    private void OnMenuAlterarClicked(object? sender, Servico servico)
    {
        using ManageServico form = new(servico);
        DialogResult dialogResult = form.ShowDialog();

        if (dialogResult == DialogResult.OK && form.Result != null)
        {
            int index = _servicos.IndexOf(servico);
            _servicos[index] = form.Result;

            _lazyPanel.SetItems(_servicos);
        }
    }

    private void OnMenuExcluirClicked(object? sender, Servico servico)
    {
        ServicoDAO.DeleteServico(servico);

        _servicos.Remove(servico);
        _lazyPanel.SetItems(_servicos);
    }
}
 