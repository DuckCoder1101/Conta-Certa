namespace Conta_Certa.Models;

public class ColumnMap
{
    public string Nome { get; set; }
    public int ColumnIndex { get; set; } = 1;
    public bool Import { get; set; } = false;
    public string ToolTip { get; } = string.Empty;
    public string PropertyName { get; }

    public ColumnMap(string nome, string propertyName, string toolTip = "")
    {
        Nome = nome;
        PropertyName = propertyName; 
        ToolTip = toolTip;
    }
}
