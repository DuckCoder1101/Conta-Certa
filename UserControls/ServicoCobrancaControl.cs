using Conta_Certa.Models;

namespace Conta_Certa.UserControls;

public partial class ServicoCobrancaControl : UserControl
{
    public Servico Servico { get; private set; }
    public int Quantidade { get; private set; } = 0;

    public ServicoCobrancaControl(Servico servico, int quantidade = 0)
    {
        InitializeComponent();

        Servico = servico;
        Quantidade = quantidade;

        nomeServicoTxt.Text = servico.Nome;
        valorServicoTxt.Text = servico.Valor.ToString("c");
        quantidadeServicoNb.Value = quantidade;
    }

    public void SetQuantidade(int quantidade)
    {
        Quantidade = quantidade;
        quantidadeServicoNb.Value = quantidade;
    }

    private void QuantidadeServicoNb_ValueChanged(object sender, EventArgs e)
    {
        Quantidade = (int)quantidadeServicoNb.Value;
    }
}
