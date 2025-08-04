using Conta_Certa.Forms;
using Conta_Certa.Models;
using Conta_Certa.Utils;

namespace Conta_Certa
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            Database.CreateDatabase();
        }

        private void CadastrarCliente_Click(object sender, EventArgs e)
        {
            using ManageCliente form = new();
            form.ShowDialog();
        }

        private void AbrirClientesList_Click(object sender, EventArgs e)
        {
            using ClientesList form = new();
            form.ShowDialog();
        }

        private void ImportFromJSON_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Title = "Importar JSON",
                Filter = "Arquivo JSON (*.json)|*.json",
                DefaultExt = "json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExportImportData.ImportFromJson(dialog.FileName);
            }
        }

        private void ExportToJSON_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new()
            {
                Title = "Exportar para JSON",
                Filter = "Arquivo JSON (*.json)|*.json",
                DefaultExt = "json",
                FileName = "Conta Certa.json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExportImportData.ExportToJSON(dialog.FileName);
            }
        }

        private void ImportFromExcelBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Title = "Importar tabela Excel",
                Filter = "Arquivo JSON (*.xls;*.xlsx)|*.xls;*.xlsx",
                DefaultExt = "json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExportImportData.ImportFromTable(dialog.FileName);
            }
        }

        private void CobrancasPendentes_Menu_Click(object sender, EventArgs e)
        {
            using CobrancasList form = new(CobrancaStatus.Pendente);
            form.ShowDialog();
        }

        private void ListaServicos_Menu_Click(object sender, EventArgs e)
        {
            using ServicosList form = new();
            form.ShowDialog();
        }

        private void CadastrarSevico_Menu_Click(object sender, EventArgs e)
        {
            using ManageServico manageServico = new ManageServico();
            manageServico.ShowDialog();
        }
    }
}
