using Conta_Certa.Models;

namespace Conta_Certa.UserControls;

public partial class ServicoCobrancaControl : UserControl
{
    public ServicoCobranca ServicoCobranca;

    public ServicoCobrancaControl(ServicoCobranca sc)
    {
        InitializeComponent();
        ServicoCobranca = sc;

        nomeServicoTxt.Text = sc.Nome;
        valorServicoTxt.Text = sc.Valor.ToString("c");
        quantidadeServicoNb.Value = sc.Quantidade;
    }

    private void QuantidadeServicoNb_ValueChanged(object sender, EventArgs e)
    {
        ServicoCobranca.SetQuantidade((int)quantidadeServicoNb.Value);
    }
}
