using Conta_Certa.DTOs;

namespace Conta_Certa.UserControls;

public partial class ClienteSearchbarItem : UserControl
{
    public event Action<ClienteResumoDTO>? OnControlClick;
    
    private ClienteResumoDTO Cliente { get; }

    public ClienteSearchbarItem(ClienteResumoDTO cliente)
    {
        InitializeComponent();
        Cliente = cliente;

        clienteTxt.Text = cliente.ToString();
    }

    private void Cliente_Click(object sender, EventArgs e)
    {
        OnControlClick?.Invoke(Cliente);
    }
}
