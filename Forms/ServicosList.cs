using Conta_Certa.DAOs;
using Conta_Certa.Models;
using Conta_Certa.UserControls;
using Conta_Certa.Utils;

namespace Conta_Certa.Forms;

public partial class ServicosList : Form
{
    private List<Servico> servicos = [];
    private ServicoControl? currentControl = null;

    private OrderBy order = OrderBy.ID;
    private string filter = "";

    public ServicosList()
    {
        InitializeComponent();

        searchbar.FilterChanged += OnSearchbarFilterChanged;
        searchbar.OrderChanged += OnSearchbarOrderValueChanged;
        searchbar.AddButtonClicked += OnAddButtonClicked;

        UpdateServicosList();
    }
    
    private List<Servico> GetSortedServicos()
    {
        switch (order)
        {
            case OrderBy.Nome:
                return [.. servicos.OrderBy(s => s.Nome)];

            case OrderBy.Valor:
                return [.. servicos.OrderBy(s => s.Valor)];

            default:
                return [.. servicos.OrderBy(s => s.IdServico)];
        }
    }

    private void UpdateServicosList()
    {
        servicos = ServicoDAO.SelectAllServicos();
        UpdateServicosPanel();
    }

    private void UpdateServicosPanel()
    {
        servicosPanel.Controls.Clear();

        // Guia
        ServicoControl guide = new(null)
        {
            Dock = DockStyle.Top
        };

        servicosPanel.Controls.Add(guide);
        servicosPanel.Controls.SetChildIndex(guide, 0);

        foreach (var servico in GetSortedServicos())
        {
            if (servico.Nome.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase))
            {
                ServicoControl servicoControl = new(servico)
                {
                    Dock = DockStyle.Top
                };

                servicosPanel.Controls.Add(servicoControl);
                servicosPanel.Controls.SetChildIndex(servicoControl, 0);
            }
        }
    }

    private void Alterar_Menu_Click(object sender, EventArgs e)
    {
        if (currentControl?.Servico != null)
        {
            using ManageServico form = new(currentControl.Servico);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateServicosList();
            }
        }
    }

    private void Excluir_Menu_Click(object sender, EventArgs e)
    {
        if (currentControl?.Servico != null)
        {
            var message =
                "Deseja mesmo excluir este serviço?\nEsta ação é irreversível e apagará também as outras informações associadas a ele.";

            DialogResult result = MessageBox.Show(
                message,
                "Excluir cliente?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ServicoDAO.DeleteServico(currentControl.Servico);

                servicos.Remove(currentControl.Servico);
                currentControl.Dispose();
            }
        }
    }

    private void OnSearchbarFilterChanged(string filter)
    {
        this.filter = filter;
        UpdateServicosList();
    }

    private void OnSearchbarOrderValueChanged(string rawOrder)
    {
        OrderBy order = Enum.Parse<OrderBy>(rawOrder);
        if (this.order != order)
        {
            this.order = order;
            UpdateServicosList();
        }
    }

    private void OnAddButtonClicked()
    {
        using ManageServico form = new();
        DialogResult result = form.ShowDialog();

        if (result == DialogResult.OK)
        {
            UpdateServicosList();
        }
    }

    private void ServicosList_FormClosing(object sender, FormClosingEventArgs e)
    {
        searchbar.FilterChanged -= OnSearchbarFilterChanged;
        searchbar.OrderChanged -= OnSearchbarOrderValueChanged;
        searchbar.AddButtonClicked -= OnAddButtonClicked;
    }

    public void OpenContextMenu(ServicoControl control)
    {
        currentControl = control;
        menu.Show(Cursor.Position);
    }
}
 