using Microsoft.EntityFrameworkCore;
using Conta_Certa.Components;
using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.UserControls;

namespace Conta_Certa.Forms;

public partial class CobrancaForm : InputForm
{
    private readonly AppDBContext _dbContext;

    // Cliente selecionado no dropdown
    private Cliente? _cliente = null;

    // ID da cobrança par alteração
    private readonly long? _idCobrancaExistente = null;

    public CobrancaForm()
    {
        InitializeComponent();

        _dbContext = new AppDBContext();

        // Carrega o status
        statusCb.DataSource = Enum.GetNames<CobrancaStatus>();
        statusCb.SelectedIndex = 0;

        // Carrega todos os servicos
        var scControls = servicosPanel.Controls.OfType<ServicoCobrancaControl>();
        foreach (var servico in _dbContext.Servicos)
        {
            if (!scControls.Any(c => c.Servico.IdServico == servico.IdServico))
            {
                ServicoCobrancaControl control = new(servico)
                {
                    Dock = DockStyle.Top,
                };

                servicosPanel.Controls.Add(control);
                servicosPanel.Controls.SetChildIndex(control, 0);
            }
        }

        // Cliente alterado
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
    }

    public CobrancaForm(Cobranca cobranca) : this()
    {
        cadastrarBtn.Text = "ALTERAR";

        _idCobrancaExistente = cobranca.IdCobranca;

        searchbar.SelectCliente(cobranca.Cliente!.Documento);
        honorarioNb.Value = (decimal)cobranca.Honorario;
        statusCb.SelectedIndex = (int)cobranca.Status;
        vencimentoTxt.Text = cobranca.Vencimento.ToString("dd/MM/yyyy");
        pagoEmTxt.Text = cobranca.PagoEm?.ToString("dd/MM/yyyy") ?? "";

        // Carrega os servicos da cobranca
        var controls = servicosPanel.Controls.OfType<ServicoCobrancaControl>();
        foreach (var sc in cobranca.ServicosCobranca)
        {
            var scControl = controls
                .FirstOrDefault(scc => scc.Servico.IdServico == sc.IdServicoOrigem);

            if (scControl != null)
            {
                scControl.SetQuantidade(sc.Quantidade);
                scControl.Servico.SetValor(sc.Valor);
            }
        }
    }

    public CobrancaForm(CobrancaCadDTO cobrancaDTO) : this()
    {
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
    }

    private void SetServicos(Cobranca cobranca)
    {
        // Atualiza os servicos da cobrança
        var controls = servicosPanel.Controls.OfType<ServicoCobrancaControl>();
        foreach (var scControl in controls)
        {
            var idCobranca = cobranca.IdCobranca;
            var scExistente = cobranca.ServicosCobranca
                .FirstOrDefault(sc => sc.IdServicoOrigem == scControl.Servico.IdServico);

            if (scControl.Quantidade > 0)
            {
                if (scExistente != null)
                {
                    scExistente.SetQuantidade(scControl.Quantidade);
                }

                else
                {
                    cobranca.ServicosCobranca.Add(new(
                        (long) scControl.Servico.IdServico!,
                        scControl.Servico.Nome,
                        scControl.Servico.Valor,
                        scControl.Quantidade));
                }
            }

            else if (scExistente != null)
            {
                cobranca.ServicosCobranca.Remove(scExistente);
            }
        }
    }

    // Form components
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
        var honorario = (float)honorarioNb.Value;
        var status = Enum.Parse<CobrancaStatus>(statusCb.Text);
        DateTime? pagoEm = null;

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

        // Verifica data de vencimento.
        if (!DateTime.TryParse(vencimentoTxt.Text, out DateTime vencimento))
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

        // Cobrança já existe no banco?
        var cobExistente = _dbContext.Cobrancas
            .Include(c => c.Cliente)
            .Include(c => c.ServicosCobranca)
            .FirstOrDefault(c => 
                c.IdCobranca == _idCobrancaExistente ||
                (c.Cliente!.Documento == _cliente.Documento &&
                (c.Vencimento.Year == vencimento.Year && c.Vencimento.Month == vencimento.Month)));

        if (cobExistente != null)
        {
            cobExistente.Update(
                _cliente.Documento,
                honorario,
                status,
                vencimento,
                pagoEm);

            SetServicos(cobExistente);
            _dbContext.Cobrancas.Attach(cobExistente);
        }

        else
        {
            Cobranca cobNova = new(
                _cliente.Documento,
                honorario,
                status,
                vencimento,
                pagoEm);

            SetServicos(cobNova);
            _dbContext.Cobrancas.Add(cobNova);
        }
            
        _dbContext.SaveChanges();

        if (Modal)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        else
        {
            ClearInputs();
        }
    }
}
