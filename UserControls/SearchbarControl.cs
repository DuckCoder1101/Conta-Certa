
namespace Conta_Certa.UserControls;

public partial class SearchbarControl : UserControl
{
    public string Filter
    {
        get => searchboxTxt.Text.Trim().ToUpper();
    }

    public event Action<string>? FilterChanged;
    public event Action? AddButtonClicked;

    public SearchbarControl()
    {
        InitializeComponent();
    }

    private void SearchbarTxt_TextChanged(object sender, EventArgs e)
    {
        FilterChanged?.Invoke(searchboxTxt.Text.Trim());
    }

    private void AddBtn_Click(object sender, EventArgs e)
    {
        AddButtonClicked?.Invoke();
    }
}
