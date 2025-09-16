using Conta_Certa.Forms;
using Conta_Certa.Models;

namespace Conta_Certa.UserControls;

public partial class ClienteControl : UserControl
{
    public Cliente? Cliente { get; private set; } = null;

    public ClienteControl(Cliente? cliente = null)
    {
        InitializeComponent();

        if (cliente != null)
        {
            SetCliente(cliente);
        }
    }

    public void SetCliente(Cliente novoCliente)
    {
        Cliente = novoCliente;
        documentoTxt.Text = Cliente.FormatDocumento(Cliente.Documento);
        nomeTxt.Text = Cliente.Nome;
        telefoneTxt.Text = Cliente.FormatTelefone(Cliente.Telefone);
        emailTxt.Text = Cliente.Email;
        honorarioTxt.Text = Cliente.Honorario.ToString("C");
        vencimentoTxt.Text = Cliente.VencimentoHonorario.ToString();
    }

    private void ClienteUserControl_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ClientesList? form = (ClientesList?)FindForm();
            form?.OpenContextMenu(this);
        }
    }
}
