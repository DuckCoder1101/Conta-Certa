using Conta_Certa.DTOs;
using Conta_Certa.Models;
using Conta_Certa.UserControls;
namespace Conta_Certa.Forms;

public partial class ExcelColumnAssistant : Form
{
    public ClienteExcelImportDTO ClienteModel { get; private set; } = new();
    public CobrancaExcelImportDTO CobrancaModel { get; private set; } = new();

    public ExcelColumnAssistant()
    {
        InitializeComponent();

        CreateClienteControls();
        CreateCobrancaControls();
    }

    // Manipulacao das listas
    private void CreateClienteControls()
    {
        foreach (var prop in ClienteModel.GetColumns())
        {
            ImportPropSelector control = new(prop)
            {
                Dock = DockStyle.Top
            };

            clientesPropsList.Controls.Add(control);
        }
    }

    private void CreateCobrancaControls()
    {
        foreach (var prop in CobrancaModel.GetColumns())
        {
            ImportPropSelector control = new(prop)
            {
                Dock = DockStyle.Top
            };

            cobrancasPropsList.Controls.Add(control);
        }
    }

    private void Import_Click(object sender, EventArgs e)
    {
        ImportColumnMap[] clienteColumns = [
            ..ClienteModel.GetColumns().Where(c => c.Import)];

        ImportColumnMap[] cobrancaColumns = [
            ..CobrancaModel.GetColumns().Where(c => c.Import)];

        if (clienteColumns.Length == 0 && cobrancaColumns.Length == 0)
        {
            MessageBox.Show(
                "É necessário selecionar ao menos uma coluna para continuar!",
                "Nenhuma coluna selecionada!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        else if (
            clienteColumns.GroupBy(c => c.ColumnIndex).Any(c => c.Count() > 1) || 
            cobrancaColumns.GroupBy(c => c.ColumnIndex).Any(c => c.Count() > 1))
        {
            MessageBox.Show(
                "Duas ou mais colunas estão com os índices iguais, altere para continuar!",
                "Índices duplicados!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        else
        {
            // Checa se a importação de IDs está ativa
            if (cobrancaColumns.Any(c => c.Import) && !CobrancaModel.IdCliente.Import)
            {
                var importIdResult = MessageBox.Show(
                    "Recomendamos ativar a importação dos IDs para evitar ter que digita-los manualmente depois.\nContinuar mesmo assim?",
                    "Importação de IDs desativada!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (importIdResult != DialogResult.Yes)
                {
                    return;
                }
            }

            var result = MessageBox.Show(
                "Deseja mesmo importar os dados?\nOs registros iguais serão sobrescritos.",
                "Importar os dados?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            DialogResult = result;
            Close();
        }
    }

    private void ExcelColumnAssistant_Shown(object sender, EventArgs e)
    {
        MessageBox.Show(
            "1º Marque as colunas que serão importadas em cada tabela.\n2º Altere o índice numérico de cada informação de acordo com a sua tabela.\nImportante: a linha 1 é considerada cabeçalho e será automaticamente ignorada.",
            "Como importar?",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
}
