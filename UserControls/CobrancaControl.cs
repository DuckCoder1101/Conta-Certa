using Conta_Certa.Forms;
using Conta_Certa.Models;

namespace Conta_Certa.UserControls;

public partial class CobrancaControl : UserControl
{
    public Cobranca? Cobranca { get; } = null;

    public CobrancaControl(Cobranca? cobranca = null)
    {
        InitializeComponent();

        if (cobranca != null)
        {
            Cobranca = cobranca;

            idTxt.Text = Cobranca.IdCobranca.ToString();
            clienteTxt.Text = Cobranca.Cliente.Nome;
            honorarioBaseTxt.Text = Cobranca.Honorario.ToString("c");
            vencimentoTxt.Text = Cobranca.Honorario.ToString();
            statusTxt.Text = Cobranca.Status.ToString();
            vencimentoTxt.Text = Cobranca.Vencimento.ToString("dd/MM/yy");
            pagoEmTxt.Text = Cobranca.PagoEm?.ToString("dd/MM/yyyy") ?? "-";

            float honorarioTotal = Cobranca.Honorario;
            foreach (var servicoCobranca in Cobranca.Servicos)
            {
                honorarioTotal += servicoCobranca.Servico.Valor * servicoCobranca.Quantidade;
            }

            honorarioTotalTxt.Text = honorarioTotal.ToString("c");
        }
    }

    private void CobrancaControl_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            CobrancasList? form = (CobrancasList?) FindForm();
            form?.OpenContextMenu(this);
        }
    }
}
