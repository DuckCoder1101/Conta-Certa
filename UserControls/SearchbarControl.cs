
using Conta_Certa.Utils;

namespace Conta_Certa.UserControls;

public partial class SearchbarControl : UserControl
{
    public event Action<string>? FilterChanged;
    public event Action<string>? OrderChanged;
    public event Action? AddButtonClicked;

    public SearchbarControl()
    {
        InitializeComponent();
        orderCB.DataSource = Enum.GetNames<OrderBy>();
    }


    private void SearchboxTxt_TextChanged(object sender, EventArgs e)
    {
        FilterChanged?.Invoke(searchboxTxt.Text.Trim().ToUpper());
    }

    private void OrderCB_SelectedIndexChanged(object sender, EventArgs e)
    {
        OrderChanged?.Invoke(orderCB.Text);
    }

    private void AddBtn_Click(object sender, EventArgs e)
    {
        AddButtonClicked?.Invoke();
    }
}
