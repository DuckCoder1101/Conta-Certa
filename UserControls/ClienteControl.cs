using Conta_Certa.Forms;
using Conta_Certa.Models;

namespace Conta_Certa.UserControls;

public partial class ClienteControl : UserControl
{
    public Cliente? Cliente { get; } = null;

    public ClienteControl(Cliente? cliente = null)
    {
        InitializeComponent();

        if (cliente != null)
        {
            Cliente = cliente;
            documentoTxt.Text = Cliente.FormatDocumento(Cliente.Documento);
            nomeTxt.Text = Cliente.Nome;
            telefoneTxt.Text = Cliente.FormatTelefone(Cliente.Telefone);
            emailTxt.Text = Cliente.Email;
            honorarioTxt.Text = Cliente.Honorario.ToString("C");
            vencimentoTxt.Text = Cliente.VencimentoHonorario.ToString();
        }
    }

    private void ClienteUserControl_Click(object sender, EventArgs e)
    {
        if (Cliente != null && FindForm() is ClientesList form)
        {
            form.OpenContextMenu(this);
        }
    }
}
