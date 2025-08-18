namespace Conta_Certa.Models;

public class ColumnMap
{
    public string Nome { get; set; }
    public int ColumnIndex { get; set; } = 1;
    public bool Import { get; set; } = false;
    public bool IsRequired { get; }
    public string ToolTip { get; } = string.Empty;
    public string PropertyName { get; }

    public ColumnMap(string nome, string propertyName, bool isRequired, string toolTip = "")
    {
        Nome = nome;
        PropertyName = propertyName;
        IsRequired = isRequired;
        ToolTip = toolTip;
    }
}
