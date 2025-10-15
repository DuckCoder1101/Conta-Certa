using Conta_Certa.Forms;
using Conta_Certa.Models;
using Conta_Certa.Relatories;
using Conta_Certa.Utils;
using QuestPDF.Fluent;

namespace Conta_Certa
{
    public partial class Main : Form
    {
        private Form? _currentForm = null;
        private FlowLayoutPanel? _submenu = null;
        private bool _isMenuExpanded = false;

        public Main()
        {
            InitializeComponent();
        }

        private void ShowMenuBtn_Click(object sender, EventArgs e)
        {
            CloseSubmenu();
            _isMenuExpanded = !_isMenuExpanded;

            if (_isMenuExpanded)
            {
                menu.Width = 250;
                openMenuBtn.Image = Properties.Resources.close;
            }

            else
            {
                menu.Width = 50;
                openMenuBtn.Image = Properties.Resources.menu;
            }
        }

        private void CloseSubmenu()
        {
            if (_submenu != null)
            {
                _submenu.Height = 56;
            }
        }

        private void Submenu_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel? panel = (FlowLayoutPanel?)((Button)sender)?.Parent?.Parent;
            if (panel != null)
            {
                if (_submenu != null && _submenu != panel)
                {
                    CloseSubmenu();
                }

                if (panel.Height == 56)
                {
                    _submenu = panel;
                    _submenu.Height = 56 * _submenu.Controls.Count;
                }

                else
                {
                    CloseSubmenu();
                    _submenu = null;
                }
            }
        }

        private void CadastrarCliente_Click(object sender, EventArgs e)
        {
            _currentForm?.Close();

            ClienteForm form = new()
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            mainFrame.Controls.Add(form);
            form.Show();

            _currentForm = form;
        }

        private void AbrirClientesList_Click(object sender, EventArgs e)
        {
            _currentForm?.Close();

            ClientesList form = new()
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            mainFrame.Controls.Add(form);
            form.Show();

            _currentForm = form;
        }

        private void ImportJSON_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Title = "Importar JSON",
                Filter = "Arquivo JSON (*.json)|*.json",
                DefaultExt = "json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                JSONImporter.ImportFromJson(dialog.FileName);
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
                JSONImporter.ExportToJSON(dialog.FileName);
            }
        }

        private void CobrancasPendentes_Menu_Click(object sender, EventArgs e)
        {
            _currentForm?.Close();

            CobrancasList form = new(CobrancaStatus.Pendente)
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            mainFrame.Controls.Add(form);
            form.Show();

            _currentForm = form;
        }

        private void CobrancasPagas_Click(object sender, EventArgs e)
        {
            _currentForm?.Close();

            CobrancasList form = new(CobrancaStatus.Paga)
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            mainFrame.Controls.Add(form);
            form.Show();

            _currentForm = form;
        }

        private void ListaServicos_Click(object sender, EventArgs e)
        {
            _currentForm?.Close();

            ServicoForm form = new()
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            mainFrame.Controls.Add(form);
            form.Show();

            _currentForm = form;
        }

        private void CadastrarSevico_Click(object sender, EventArgs e)
        {
            _currentForm?.Close();

            ManageServico form = new()
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            mainFrame.Controls.Add(form);
            form.Show();

            _currentForm = form;
        }

        private void GerarCobrancas_Click(object sender, EventArgs e)
        {
            // Agenda as cobranças
            Task.Run(() => CobrancasScheduler.GenCobrancasDoMes());
        }

        private void StartWhastappAutomation_Click(object sender, EventArgs e)
        {
            using AppDBContext dBContext = new();
            var cobrancas = dBContext.Cobrancas
                .Where(c => c.Status == CobrancaStatus.Pendente && c.Cliente!.Telefone.Length == 11);

            Server.ConnectExtension([.. cobrancas]);
        }

        private void ImportClientesTable_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Title = "Importar tabela Excel",
                Filter = "Arquivo JSON (*.xls;*.xlsx)|*.xls;*.xlsx",
                DefaultExt = "json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExcelImporter.ImportClientesTable(dialog.FileName);
            }
        }

        private void ImportCobrancaTable_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Title = "Importar tabela Excel",
                Filter = "Arquivo JSON (*.xls;*.xlsx)|*.xls;*.xlsx",
                DefaultExt = "json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExcelImporter.ImportCobrancasTable(dialog.FileName);
            }
        }

        private void RelatorioCobsPendentes(object sender, EventArgs e)
        {
            using AppDBContext dBContext = new();
            Task.Run(() =>
            {
                List<Cobranca> cobrancas = [.. dBContext.Cobrancas.Where(c => c.Status == CobrancaStatus.Pendente)];

                var document = new RelatorioCobrancas(cobrancas);
                document.GeneratePdfAndShow();
            });
        }

        private void RelatorioCobsPagas(object sender, EventArgs e)
        {
            using AppDBContext dBContext = new();
            Task.Run(() =>
            {
                List<Cobranca> cobrancas = [.. dBContext.Cobrancas.Where(c => c.Status == CobrancaStatus.Paga)];

                var document = new RelatorioCobrancas(cobrancas);
                document.GeneratePdfAndShow();
            });
        }
    }
}
