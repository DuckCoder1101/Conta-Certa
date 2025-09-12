using Conta_Certa.DAOs;
using Conta_Certa.Models;
using Conta_Certa.UserControls;
using Conta_Certa.Utils;
using System.Diagnostics;

namespace Conta_Certa.Forms;

public partial class CobrancasList : Form
{
    private readonly CobrancaStatus? statusFilter = null;

    private List<Cobranca> cobrancas = [];
    private CobrancaControl? currentCobranca = null;

    private string filter = "";
    private OrderBy order = OrderBy.ID;

    public CobrancasList()
    {
        InitializeComponent();

        searchbar.FilterChanged += OnSearchbarFilterChanged;
        searchbar.OrderChanged += OnSearchbarOrderValueChanged;
        searchbar.AddButtonClicked += OnAddButtonClicked;

        UpdateCobrancasList();
    }

    public CobrancasList(CobrancaStatus statusFilter)
    {
        InitializeComponent();

        this.statusFilter = statusFilter;

        searchbar.FilterChanged += OnSearchbarFilterChanged;
        searchbar.OrderChanged += OnSearchbarOrderValueChanged;
        searchbar.AddButtonClicked += OnAddButtonClicked;

        UpdateCobrancasList();
    }

    private List<Cobranca> GetSortedCobrancas()
    {
        switch (order)
        {
            case OrderBy.Nome:
                return [.. cobrancas.OrderBy(c => c.Cliente.Nome)];

            case OrderBy.Valor:
                return [.. cobrancas.OrderBy(c => c.Honorario)];

            default:
                return [.. cobrancas.OrderBy(c => c.IdCobranca)];
        }
    }

    private void UpdateCobrancasList()
    {
        if (statusFilter != null)
        {
            cobrancas = CobrancaDAO.GetCobrancasByStatus((CobrancaStatus)statusFilter);
        }

        else
        {
            cobrancas = CobrancaDAO.GetAllCobrancas();
        }

        UpdateCobrancasPanel();
    }

    private void UpdateCobrancasPanel()
    {
        cobrancasPanel.Controls.Clear();

        CobrancaControl guide = new(null)
        {
            Dock = DockStyle.Top
        };

        cobrancasPanel.Controls.Add(guide);
        cobrancasPanel.Controls.SetChildIndex(guide, 0);

        foreach (var cobranca in GetSortedCobrancas())
        {
            if (cobranca.Cliente.Nome.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase))
            {
                CobrancaControl control = new(cobranca)
                {
                    Dock = DockStyle.Top
                };

                cobrancasPanel.Controls.Add(control);
                cobrancasPanel.Controls.SetChildIndex(control, 0);
            }
        }
    }

    private void OnSearchbarFilterChanged(string filter)
    {
        this.filter = filter;
        UpdateCobrancasPanel();
    }

    private void OnSearchbarOrderValueChanged(string rawOrder)
    {
        OrderBy order = Enum.Parse<OrderBy>(rawOrder);
        if (this.order != order)
        {
            this.order = order;
            UpdateCobrancasList();
        }
    }

    private void OnAddButtonClicked()
    {
        using ManageCobranca form = new();
        DialogResult result = form.ShowDialog();

        if (result == DialogResult.OK)
        {
            UpdateCobrancasList();
        }
    }

    private void AlterarToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (currentCobranca?.Cobranca != null)
        {
            using ManageCobranca form = new(currentCobranca.Cobranca);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateCobrancasList();
            }
        }
    }

    private void ExcluirToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (currentCobranca?.Cobranca != null)
        {
            var message =
                "Deseja mesmo excluir esta cobrança?\nEsta ação é irreversível e apagará também todas as informações associadas a ela.";

            DialogResult result = MessageBox.Show(
                message,
                "Excluir cliente?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                CobrancaDAO.DeleteCobranca(currentCobranca.Cobranca);

                cobrancasPanel.Controls.Remove(currentCobranca);
                currentCobranca.Dispose();
            }
        }
    }

    public void OpenContextMenu(CobrancaControl control)
    {
        currentCobranca = control;
        menu.Show(Cursor.Position);
    }

    private void CobrancasList_FormClosing(object sender, FormClosingEventArgs e)
    {
        searchbar.FilterChanged -= OnSearchbarFilterChanged;
        searchbar.OrderChanged -= OnSearchbarOrderValueChanged;
        searchbar.AddButtonClicked -= OnAddButtonClicked;
    }
}
