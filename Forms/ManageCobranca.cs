using Conta_Certa.Components;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.UserControls;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Conta_Certa.Forms;

public partial class ManageCobranca : InputForm
{
    public Cobranca? Cobranca;

    private readonly AppDBContext _dbContext;

    // Cliente selecionado no dropdown
    private Cliente? _cliente = null;
    private long? _idCobranca = null;

    public ManageCobranca(Cobranca? cobranca = null)
    {
        InitializeComponent();

        _dbContext = new();
        LoadData();

        // Carrega a cobrança
        if (cobranca != null)
        {
            _idCobranca = cobranca.IdCobranca;

            cadastrarBtn.Text = "ALTERAR";

            searchbar.SelectCliente(cobranca.Cliente!.Documento!);

            honorarioNb.Value = (decimal)cobranca.Honorario;
            statusCb.SelectedIndex = (int)cobranca.Status;
            vencimentoTxt.Text = cobranca.Vencimento.ToString("dd/MM/yyyy");

            if (cobranca.Status == CobrancaStatus.Paga)
            {
                pagoEmTxt.Text = cobranca.PagoEm?.ToString("dd/MM/yyyy");
            }

            // Carrega os servicos da cobranca
            foreach (var sc in cobranca.ServicosCobranca)
            {
                ServicoCobrancaControl control = new(sc)
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

        _dbContext = new();
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
        searchbar.OnClienteChange += (cliente) =>
        {
            _cliente = cliente;

            if (cliente != null)
            {
                DateTime vencimento = new(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    cliente.VencimentoHonorario);

                honorarioNb.Value = (decimal)cliente.Honorario;
                vencimentoTxt.Text = vencimento.ToString("dd/MM/yyyy");
            }
        };

        // Carrega o status
        statusCb.DataSource = Enum.GetNames<CobrancaStatus>();
        statusCb.SelectedIndex = 0;
    }

    private void LoadServicos()
    {
        // Carrega todos os servicos
        foreach (var servico in _dbContext.Servicos.ToList())
        {
            bool exists = servicosPanel.Controls
                .OfType<ServicoCobrancaControl>()
                .Any(c => c.ServicoCobranca.IdServico == servico.IdServico);

            if (!exists)
            {
                ServicoCobrancaControl control = new(new((long)servico.IdServico!, servico.Nome, servico.Valor, 0))
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
            if (status == CobrancaStatus.Pendente)
            {
                pagoEmTxt.ReadOnly = true;
                pagoEmTxt.Text = "";
            }

            else
            {
                pagoEmTxt.ReadOnly = false;
                pagoEmTxt.Text = vencimentoTxt.Text;
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

        // Atualiza a cobranca
        Cobranca = new(_cliente.Documento, honorario, status, vencimento, pagoEm);

        if (_idCobranca != null)
        {
            Cobranca.SetId((long)_idCobranca);
        }

        // Atualiza os servicos
        var controls = servicosPanel.Controls.OfType<ServicoCobrancaControl>();
        foreach (var scControl in controls)
        {
            var scExistente = _dbContext.ServicosCobranca
                .FirstOrDefault(sc => 
                    sc.IdServico == scControl.ServicoCobranca.IdServico &&
                    sc.IdCobranca == Cobranca.IdCobranca);

            Debug.WriteLine($"Servico existente: {scExistente?.Nome ?? "null"}");
            Debug.WriteLine($"Quantidade servico: {scControl.ServicoCobranca.Quantidade}");

            if (scControl.ServicoCobranca.Quantidade > 0)
            {
                if (scExistente != null)
                {
                    scExistente.SetQuantidade(scControl.ServicoCobranca.Quantidade);
                }

                else
                {
                    Cobranca.ServicosCobranca.Add(scControl.ServicoCobranca);
                }
            }

            else if (scExistente != null)
            {

                Cobranca.ServicosCobranca.Remove(scExistente);
            }
        }

        try
        {
            _dbContext.Cobrancas.Add(Cobranca);
            _dbContext.SaveChanges();
        }

        catch (DbUpdateException)
        {
            _dbContext.Cobrancas.Add(Cobranca);
            _dbContext.Entry(Cobranca).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        if (Modal)
        {
            DialogResult = DialogResult.OK;
            Cobranca.Cliente = _cliente;

            Close();
        }

        else
        {
            ClearInputs();
        }
    }
}
