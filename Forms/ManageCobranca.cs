using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.UserControls;

namespace Conta_Certa.Forms;

public partial class ManageCobranca : Form
{
    public Cobranca? Cobranca { get; private set; } = null;

    private ClienteResumoDTO[] clientes = [];

    private System.Windows.Forms.Timer? debounceTimer;

    public ManageCobranca(Cobranca? cobranca = null)
    {
        InitializeComponent();
        LoadData();

        // Carrega a cobrança
        if (cobranca != null)
        {
            cadastrarBtn.Text = "ALTERAR";

            var cliente = clientes.First(c => c.IdCliente == cobranca.Cliente.IdCliente);
            clientesCb.SelectedItem = cliente;

            Cobranca = cobranca;
            honorarioNb.Value = (decimal)cobranca.Honorario;
            statusCb.SelectedIndex = (int)cobranca.Status;
            vencimentoTxt.Text = cobranca.Vencimento.ToString("dd/MM/yyyy");

            if (cobranca.Status == CobrancaStatus.Paga)
            {
                pagoEmTxt.Text = cobranca.PagoEm?.ToString("dd/MM/yyyy");
            }

            // Carrega os servicos da cobranca
            foreach (var servicoCobranca in cobranca.Servicos)
            {
                ServicoCobrancaControl control = new(
                    servicoCobranca.Servico,
                    servicoCobranca.Quantidade)
                {
                    Dock = DockStyle.Top,
                };

                servicosPanel.Controls.Add(control);
                servicosPanel.Controls.SetChildIndex(control, 0);
            }
        }

        LoadServicos();
    }

    public ManageCobranca(CobrancaCadDTO cobrancaDTO)
    {
        InitializeComponent();
        LoadData();

        var cliente = clientes.First(c => c.IdCliente == cobrancaDTO.IdCliente);
        clientesCb.SelectedItem = cliente;

        if (cobrancaDTO.Honorario != null)
        {
            honorarioNb.Value = (decimal)cobrancaDTO.Honorario;
            honorarioNb.ReadOnly = true;
        }

        if (cobrancaDTO.Status != null)
        {
            statusCb.SelectedIndex = (int)cobrancaDTO.Status;
            statusCb.Enabled = false;
        }

        if (cobrancaDTO.Vencimento != null)
        {
            vencimentoTxt.Text = ((DateTime)cobrancaDTO.Vencimento!).ToString("dd/MM/yyyy");
            vencimentoTxt.ReadOnly = true;
        }

        LoadServicos();
    }

    private void LoadData()
    {
        // Timer
        debounceTimer = new()
        {
            Interval = 200
        };

        debounceTimer.Tick += DebounceTimer_Tick;

        // Carrega o status
        statusCb.DataSource = Enum.GetNames<CobrancaStatus>();
        statusCb.SelectedIndex = 0;

        // Carrega a lista de clientes
        clientes = [.. ClienteDAO.SelectAllClientesResumos()];
        clientesCb.Items.AddRange(clientes);
    }

    private void LoadServicos()
    {
        // Carrega todos os servicos
        foreach (var servico in ServicoDAO.SelectAllServicos())
        {
            bool exists = servicosPanel.Controls
                .OfType<ServicoCobrancaControl>()
                .Any(c => c.Servico.IdServico == servico.IdServico);

            if (!exists)
            {
                ServicoCobrancaControl control = new(servico, 0)
                {
                    Dock = DockStyle.Top,
                };

                servicosPanel.Controls.Add(control);
                servicosPanel.Controls.SetChildIndex(control, 0);
            }
        }
    }

    private void StatusCb_SelectedIndexChanged(object sender, EventArgs e)
    {
        var status = Enum.Parse<CobrancaStatus>(statusCb.Text);
        pagoEmTxt.ReadOnly = !(status == CobrancaStatus.Paga);
    }

    private void CadastrarBtn_Click(object sender, EventArgs e)
    {
        // Verifica os campos obrigatórios
        if (
            clientesCb.SelectedItem is not ClienteResumoDTO clienteResumoDTO ||
            honorarioNb.Value == 0 ||
            !vencimentoTxt.MaskCompleted)
        {
            MessageBox.Show(
                "Os campos marcados com * são obrigatórios!",
                "Faltam informações!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        var honorario = (float)honorarioNb.Value;
        var status = Enum.Parse<CobrancaStatus>(statusCb.Text);
        var vencimento = DateTime.Parse(vencimentoTxt.Text.Trim());
        DateTime? pagoEm = null;

        // Verifica o status
        if (status == CobrancaStatus.Paga)
        {
            // Verifica o campo de data de pagamento
            if (!pagoEmTxt.MaskCompleted)
            {
                MessageBox.Show(
                    "Quando o status é definido para Paga, é necessária informar uma data de pagamento!",
                    "Faltam informações!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            pagoEm = DateTime.Parse(vencimentoTxt.Text);
        }

        long? idCobranca;

        if (Cobranca != null)
        {
            idCobranca = Cobranca.IdCobranca;

            CobrancaDAO.UpdateCobranca(new(
                Cobranca.IdCobranca,
                Cobranca.Cliente,
                honorario,
                status,
                vencimento,
                pagoEm));
        }

        else
        {
            CobrancaCadDTO cobranca = new(
                clienteResumoDTO.IdCliente,
                honorario,
                status,
                vencimento,
                pagoEm);

            idCobranca = CobrancaDAO.InsertCobrancas(cobranca)[0];
        }

        // Salva os serviços da cobrança
        var controls = servicosPanel.Controls.OfType<ServicoCobrancaControl>();
        var servicosCobrancaBase = Cobranca?.Servicos.ToDictionary(sc => sc.Servico.IdServico);

        foreach (var servicoCobrancaControl in controls)
        {
            var servico = servicoCobrancaControl.Servico;
            var quantidade = servicoCobrancaControl.Quantidade;

            if (servicosCobrancaBase != null &&
                servicosCobrancaBase.TryGetValue(servico.IdServico, out var sc))
            {
                if (sc.Quantidade != quantidade)
                {
                    if (quantidade > 0)
                    {
                        ServicoCobrancaDAO.UpdateServicoCobranca(new(
                            sc.IdServicoCobranca,
                            sc.IdCobranca,
                            sc.Servico,
                            quantidade));
                    }

                    else
                    {
                        ServicoCobrancaDAO.DeleteSerivocCobranca(sc);
                    }
                }
            }

            else if (quantidade > 0 && idCobranca != null)
            {
                ServicoCobrancaCadDTO servicoCobranca = new(
                    servico,
                    (long)idCobranca,
                    quantidade);

                ServicoCobrancaDAO.InsertServicosCobranca(servicoCobranca);
            }
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void ClientesCb_TextUpdate(object sender, EventArgs e)
    {
        debounceTimer?.Stop();
        debounceTimer?.Start();
    }

    private void DebounceTimer_Tick(object? sender, EventArgs e)
    {
        debounceTimer?.Stop();

        string filter = clientesCb.Text;
        string digits = new([.. filter.Where(char.IsDigit)]);

        var filteredClientes = clientes
            .Where(c =>
                c.Nome.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                c.Documento.Contains(digits) ||
                c.IdCliente.ToString().Contains(filter))
            .ToArray();

        clientesCb.BeginUpdate();
        
        if (!clientesCb.DroppedDown)
        {
            clientesCb.DroppedDown = false;
        }

        clientesCb.Items.Clear();

        if (filteredClientes.Length > 0)
        {
            clientesCb.Items.AddRange(filteredClientes);
            
            clientesCb.Text = filter;
            clientesCb.SelectionStart = clientesCb.SelectionStart;
            clientesCb.SelectionLength = 0;
        }

        clientesCb.DroppedDown = true;
        clientesCb.EndUpdate();
    }
}
