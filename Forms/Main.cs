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

        private void Exportar_JSON_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new()
            {
                Title = "Exportar para JSON",
                Filter = "Arquivo JSON (*.json)|.json",
                DefaultExt = "json",
                FileName = "Conta Certa.json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExportImportData.ExportToJSON(dialog.FileName);
            }
        }

        private void CobrancasPendentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using CobrancasList form = new(CobrancaStatus.Pendente);
            form.ShowDialog();
        }
    }
}
