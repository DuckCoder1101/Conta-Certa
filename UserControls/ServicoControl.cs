using Conta_Certa.Models;

namespace Conta_Certa.UserControls;

public partial class ServicoControl : UserControl
{
    public Servico? Servico { get; } = null;

    public ServicoControl(Servico? servico = null)
    {
        InitializeComponent();

        if (servico != null)
        {
            Servico = servico;

            idTxt.Text = servico.IdServico.ToString();
            nomeTxt.Text = servico.Nome;
            valorTxt.Text = servico.Valor.ToString("c");
        }
    }

    private void ServicoControl_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {

        }
    }
}
