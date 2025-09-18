using Conta_Certa.Components;
using Conta_Certa.DAOs;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.UserControls;

namespace Conta_Certa.Forms;

public partial class ManageCobranca : InputForm
{
    // Cliente selecionado no dropdown
    private Cliente? _cliente = null;
    private long? _idCobranca = null;

    public ManageCobranca(Cobranca? cobranca = null)
    {
        InitializeComponent();
        LoadData();

        // Carrega a cobrança
        if (cobranca != null)
        {
            _idCobranca = cobranca.IdCobranca;

            cadastrarBtn.Text = "ALTERAR";

            searchbar.SelectCliente(cobranca.Cliente.Documento!);

            honorarioNb.Value = (decimal)cobranca.Honorario;
            statusCb.SelectedIndex = (int)cobranca.Status;
            vencimentoTxt.Text = cobranca.Vencimento.ToString("dd/MM/yyyy");

            if (cobranca.Status == CobrancaStatus.Paga)
            {
                pagoEmTxt.Text = cobranca.PagoEm?.ToString("dd/MM/yyyy");
            }

            // Carrega os servicos da cobranca
            foreach (var servicoCobranca in cobranca.ServicosCobranca)
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

        if (cobrancaDTO.DocumentoCliente != null)
        {
            searchbar.SelectCliente(cobrancaDTO.DocumentoCliente!);
        }

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
        searchbar.OnClienteChange += (novoCliente) =>
        {
            _cliente = novoCliente;
            
            if (_cliente != null)
            {
                honorarioNb.Value = (decimal)_cliente.Honorario;
            }
        };

        // Carrega o status
        statusCb.DataSource = Enum.GetNames<CobrancaStatus>();
        statusCb.SelectedIndex = 0;
    }

    private void LoadServicos()
    {
        // Carrega todos os servicos
        foreach (var servico in ServicoDAO.GetAllServicos())
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
        var statusTxt = statusCb.SelectedItem?.ToString();

        if (Enum.TryParse<CobrancaStatus>(statusTxt, true, out var status))
        {
            pagoEmTxt.ReadOnly = !(status == CobrancaStatus.Paga);
        }
    }

    private void InsertServicos(long idCobranca)
    {
        // Salva os serviços da cobrança
        var controls = servicosPanel.Controls.OfType<ServicoCobrancaControl>();

        foreach (var servicoCobrancaControl in controls)
        {
            var servico = servicoCobrancaControl.Servico;
            var quantidade = servicoCobrancaControl.Quantidade;

            if (quantidade > 0)
            {
                ServicoCobrancaCadDTO servicoCobranca = new(
                    servico,
                    idCobranca,
                    quantidade);

                ServicoCobrancaDAO.InsertServicosCobranca(servicoCobranca);
            }

            else
            {
                ServicoCobrancaDAO.DeleteServicoCobranca(idCobranca, servico.IdServico);
            }
        }
    }

    private void CadastrarBtn_Click(object sender, EventArgs e)
    {
        // Verifica os campos obrigatórios
        if (_cliente == null || honorarioNb.Value == 0 || !vencimentoTxt.MaskCompleted)
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
        DateTime vencimento;
        DateTime? pagoEm = null;

        // Verifica o status e a data de pagamento
        if (status == CobrancaStatus.Paga && !pagoEmTxt.MaskCompleted)
        { 
            MessageBox.Show(
                "Quando o status é definido para 'Paga', é necessária informar uma data de pagamento!",
                "Faltam informações!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        // Verifica d data de vencimento.
        if (!DateTime.TryParse(vencimentoTxt.Text, out vencimento))
        {
            MessageBox.Show(
                "A data de vencimento é inválida!",
                "Data de vencimento inválida!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        // Verifica a data de pagamento
        if (status == CobrancaStatus.Paga)
        {
            if (!DateTime.TryParse(pagoEmTxt.Text, out DateTime pagoEmResult))
            {
                MessageBox.Show(
                    "A data de pagamento é inválida!",
                    "Data de pagamento inválida!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            pagoEm = pagoEmResult;
        }

        CobrancaCadDTO cobranca = new(
            _cliente.Documento,
            honorario,
            status,
            vencimento,
            pagoEm);

        if (_idCobranca != null)
        {
            CobrancaDAO.UpdateCobranca((long) _idCobranca, cobranca);
        }

        else
        {
            var ids = CobrancaDAO.InsertCobrancas(cobranca);

            if (ids.Count > 0 && ids[0] != null)
            {
                _idCobranca = ids[0];
            }
        }

        if (_idCobranca != null)
        {
            InsertServicos((long)_idCobranca);
        
            if (Modal)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        ClearInputs();
    }
}
