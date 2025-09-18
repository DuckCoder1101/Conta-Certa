namespace Conta_Certa.Components;

public class InputForm : Form
{
    public void ClearInputs(Control? c = null)
    {
        foreach (Control ctrl in c?.Controls ?? Controls)
        {
            if (ctrl is TextBox textBox)
                textBox.Clear();

            else if (ctrl is MaskedTextBox maskedTextBox)
                maskedTextBox.Clear();

            else if (ctrl is ComboBox comboBox)
                comboBox.SelectedIndex = -1;

            else if (ctrl is CheckBox checkBox)
                checkBox.Checked = false;

            else if (ctrl is NumericUpDown numericUpDown)
                numericUpDown.Value = numericUpDown.Minimum;

            if (ctrl.HasChildren)
                ClearInputs(ctrl);
        }
    }
}
