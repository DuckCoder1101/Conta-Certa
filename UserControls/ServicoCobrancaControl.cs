
using Conta_Certa.Models;

namespace Conta_Certa.UserControls;

public partial class ServicoCobrancaControl : UserControl
{
    public Servico Servico { get; }
    public int Quantidade { get; private set; }

    public ServicoCobrancaControl(Servico servico, int quantidade)
    {
        InitializeComponent();

        Servico = servico;
        Quantidade = quantidade;

        nomeServicoTxt.Text = Servico.Nome;
        quantidadeServicoNb.Value = Quantidade;
    }

    private void QuantidadeServicoNb_ValueChanged(object sender, EventArgs e)
    {
        Quantidade = (int) quantidadeServicoNb.Value;
    }
}
