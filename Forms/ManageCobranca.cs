using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.UserControls;

namespace Conta_Certa.Forms;

public partial class ManageCobranca : Form
{
    public Cobranca? Cobranca { get; } = null;

    public ManageCobranca(Cobranca? cobranca = null)
    {
        InitializeComponent();

        // Carrega os status
        statusCb.DataSource = Enum.GetNames<CobrancaStatus>();
        statusCb.SelectedIndex = 0;

        // Carrega a cobrança
        if (cobranca != null)
        {
            cadastrarBtn.Text = "ALTERAR";

            Cobranca = cobranca;

            idClienteNb.Value = cobranca.Cliente.Id;
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

        // Carrega todos os servicos restantes
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

    private void StatusCb_SelectedIndexChanged_1(object sender, EventArgs e)
    {
        CobrancaStatus status = Enum.Parse<CobrancaStatus>(statusCb.Text);
        pagoEmTxt.ReadOnly = !(status == CobrancaStatus.Paga);
    }

    private void CadastrarBtn_Click(object sender, EventArgs e)
    {
        // Vefica os campos obrigatorios
        if (idClienteNb.Value == 0 ||
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

        int idCliente = (int)idClienteNb.Value;
        float honorario = (float)honorarioNb.Value;
        CobrancaStatus status = Enum.Parse<CobrancaStatus>(statusCb.Text);
        DateTime vencimento = DateTime.Parse(vencimentoTxt.Text);
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

        if (Cobranca != null)
        {
            Cobranca cobranca = new(
                Cobranca.IdCobranca,
                Cobranca.Cliente,
                honorario,
                status,
                vencimento,
                pagoEm);

            CobrancaDAO.UpdateCobranca(cobranca);
        }

        else
        {
            CobrancaCadDTO cobranca = new(
                idCliente,
                honorario,
                status,
                vencimento,
                pagoEm);

            CobrancaDAO.InsertCobrancas(cobranca);
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void IdClienteNb_ValueChanged(object sender, EventArgs e)
    {
        nomeClienteTxt.Text = "";

        if (idClienteNb.Value > 0)
        {
            var cliente = ClienteDAO.GetClienteByID((long)idClienteNb.Value);
            if (cliente != null)
            {
                nomeClienteTxt.Text = cliente.Nome;
                honorarioNb.Value = (decimal) cliente.Honorario;

                DateTime vencimento = new(
                    DateTime.Now.Year, 
                    DateTime.Now.Month, 
                    cliente.VencimentoHonorario);

                vencimentoTxt.Text = vencimento.ToString("dd/MM/yyyy");
            }

            else
            {
                idClienteNb.Value = 0;

                MessageBox.Show(
                    "O ID digitado não corresponde a um cliente existente!",
                    "Usuário não encontrado!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
