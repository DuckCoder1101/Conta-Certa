using Conta_Certa.DAOs;
using Conta_Certa.Forms;
using Conta_Certa.Models;
using Conta_Certa.Relatories;
using Conta_Certa.Utils;
using QuestPDF.Fluent;

namespace Conta_Certa
{
    public partial class Main : Form
    {
        Form? currentForm = null;

        FlowLayoutPanel? submenu = null;
        bool isMenuExpanded = false;
        const int step = 5;

        public Main()
        {
            InitializeComponent();
        }

        private void MenuTimer_Tick(object? sender, EventArgs e)
        {
            if (isMenuExpanded)
            {
                if (sidebarPanel.Width > 50)
                {
                    sidebarPanel.Width -= step;
                }

                else
                {
                    menuTimer.Stop();
                    isMenuExpanded = false;
                }
            }

            else
            {
                if (sidebarPanel.Width < 250)
                {
                    sidebarPanel.Width += step;
                }

                else
                {
                    menuTimer.Stop();
                    isMenuExpanded = true;
                }
            }
        }

        private void ShowMenuBtn_Click(object sender, EventArgs e)
        {
            if (!menuTimer.Enabled)
            {
                CloseSubmenu();
                menuTimer.Start();
            }
        }

        private void CloseSubmenu()
        {
            if (submenu != null)
            {
                submenu.Height = 56;
            }
        }

        private void Submenu_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel? panel = (FlowLayoutPanel?)((Button)sender)?.Parent?.Parent;
            if (panel != null && !menuTimer.Enabled)
            {
                if (submenu != null && submenu != panel)
                {
                    CloseSubmenu();
                }

                if (panel.Height == 56)
                {
                    submenu = panel;
                    submenu.Height = 56 * submenu.Controls.Count;
                }

                else
                {
                    CloseSubmenu();
                    submenu = null;
                }
            }
        }

        private void CadastrarCliente_Click(object sender, EventArgs e)
        {
            currentForm?.Close();

            ManageCliente form = new()
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            mainFrame.Controls.Add(form);
            form.Show();

            currentForm = form;
        }

        private void AbrirClientesList_Click(object sender, EventArgs e)
        {
            currentForm?.Close();

            ClientesList form = new()
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            mainFrame.Controls.Add(form);
            form.Show();

            currentForm = form;
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
            currentForm?.Close();

            CobrancasList form = new(CobrancaStatus.Pendente)
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            mainFrame.Controls.Add(form);
            form.Show();

            currentForm = form;
        }

        private void CobrancasPagas_Click(object sender, EventArgs e)
        {
            currentForm?.Close();

            CobrancasList form = new(CobrancaStatus.Paga)
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            mainFrame.Controls.Add(form);
            form.Show();

            currentForm = form;
        }

        private void ListaServicos_Click(object sender, EventArgs e)
        {
            currentForm?.Close();

            ServicosList form = new()
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            mainFrame.Controls.Add(form);
            form.Show();

            currentForm = form;
        }

        private void CadastrarSevico_Click(object sender, EventArgs e)
        {
            currentForm?.Close();

            ManageServico form = new()
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            mainFrame.Controls.Add(form);
            form.Show();

            currentForm = form;
        }

        private void GerarCobrancas_Click(object sender, EventArgs e)
        {
            // Agenda as cobranças
            Task.Run(() => CobrancasScheduler.GenCobrancasDoMes());
        }

        private void StartWhastappAutomation_Click(object sender, EventArgs e)
        {
            var cobrancas = CobrancaDAO.GetCobrancasByStatus(CobrancaStatus.Pendente);
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

        private void GerarRelatorio_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var cobrancas = CobrancaDAO.GetRelatory(CobrancaStatus.Pendente);
                var document = new CobrancaRelatory(cobrancas);
                document.GeneratePdfAndShow();
            });
        }
    }
}
