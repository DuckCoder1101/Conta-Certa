using Conta_Certa.Models;

namespace Conta_Certa.UserControls;

public partial class ImportPropSelector : UserControl
{
    public ColumnMap ColumnMap { get; private set; }

    public ImportPropSelector(ColumnMap map)
    {
        InitializeComponent();
        ColumnMap = map;

        propNameTxt.Text = ColumnMap.Nome;
        toolTip.SetToolTip(toolTipBtn, map.ToolTip);
    }

    private void ImportPropCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        ColumnMap.Import = importPropCheckbox.Checked;

        if (ColumnMap.Import)
        {
            BackColor = Color.LightGray;
            indexNb.Enabled = true;
        }

        else
        {
            BackColor = Color.DarkGray;
            indexNb.Value = 1;
            indexNb.Enabled = false;
        }
    }

    private void IndexNb_ValueChanged(object sender, EventArgs e)
    {
        ColumnMap.ColumnIndex = (int)indexNb.Value;
    }
}
