namespace Conta_Certa
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menu = new MenuStrip();
            arquivoToolStripMenuItem = new ToolStripMenuItem();
            importarDadosToolStripMenuItem = new ToolStripMenuItem();
            importFromExelBtn = new ToolStripMenuItem();
            importFromJSONBtn = new ToolStripMenuItem();
            exportToJSONBtn = new ToolStripMenuItem();
            tabelaExelToolStripMenuItem = new ToolStripMenuItem();
            jSONToolStripMenuItem = new ToolStripMenuItem();
            openSetingsBtn = new ToolStripMenuItem();
            relatToolStripMenuItem = new ToolStripMenuItem();
            newRelatoryBtn = new ToolStripMenuItem();
            openReportsHistory = new ToolStripMenuItem();
            cobrançasToolStripMenuItem = new ToolStripMenuItem();
            openClientsListBtn = new ToolStripMenuItem();
            cadastrarClienteToolStripMenuItem = new ToolStripMenuItem();
            cobrançasToolStripMenuItem1 = new ToolStripMenuItem();
            cobrancasPendentes = new ToolStripMenuItem();
            cobrancasPagas = new ToolStripMenuItem();
            cobrarTodos = new ToolStripMenuItem();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.BackColor = SystemColors.ControlLight;
            menu.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menu.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem, relatToolStripMenuItem, cobrançasToolStripMenuItem, cobrançasToolStripMenuItem1 });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(800, 24);
            menu.TabIndex = 0;
            menu.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importarDadosToolStripMenuItem, exportToJSONBtn, openSetingsBtn });
            arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            arquivoToolStripMenuItem.Size = new Size(61, 20);
            arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // importarDadosToolStripMenuItem
            // 
            importarDadosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importFromExelBtn, importFromJSONBtn });
            importarDadosToolStripMenuItem.Name = "importarDadosToolStripMenuItem";
            importarDadosToolStripMenuItem.Size = new Size(156, 22);
            importarDadosToolStripMenuItem.Text = "Importar";
            // 
            // importFromExelBtn
            // 
            importFromExelBtn.Name = "importFromExelBtn";
            importFromExelBtn.Size = new Size(148, 22);
            importFromExelBtn.Text = "Tabela Excel";
            // 
            // importFromJSONBtn
            // 
            importFromJSONBtn.Name = "importFromJSONBtn";
            importFromJSONBtn.Size = new Size(148, 22);
            importFromJSONBtn.Text = "JSON";
            // 
            // exportToJSONBtn
            // 
            exportToJSONBtn.DropDownItems.AddRange(new ToolStripItem[] { tabelaExelToolStripMenuItem, jSONToolStripMenuItem });
            exportToJSONBtn.Name = "exportToJSONBtn";
            exportToJSONBtn.Size = new Size(156, 22);
            exportToJSONBtn.Text = "Exportar";
            // 
            // tabelaExelToolStripMenuItem
            // 
            tabelaExelToolStripMenuItem.Name = "tabelaExelToolStripMenuItem";
            tabelaExelToolStripMenuItem.Size = new Size(141, 22);
            tabelaExelToolStripMenuItem.Text = "Tabela Exel";
            // 
            // jSONToolStripMenuItem
            // 
            jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            jSONToolStripMenuItem.Size = new Size(141, 22);
            jSONToolStripMenuItem.Text = "JSON";
            jSONToolStripMenuItem.Click += Exportar_JSON_Click;
            // 
            // openSetingsBtn
            // 
            openSetingsBtn.Name = "openSetingsBtn";
            openSetingsBtn.Size = new Size(156, 22);
            openSetingsBtn.Text = "Configurações";
            // 
            // relatToolStripMenuItem
            // 
            relatToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newRelatoryBtn, openReportsHistory });
            relatToolStripMenuItem.Name = "relatToolStripMenuItem";
            relatToolStripMenuItem.Size = new Size(77, 20);
            relatToolStripMenuItem.Text = "Relatórios";
            // 
            // newRelatoryBtn
            // 
            newRelatoryBtn.Name = "newRelatoryBtn";
            newRelatoryBtn.Size = new Size(200, 22);
            newRelatoryBtn.Text = "Gerar relatório";
            // 
            // openReportsHistory
            // 
            openReportsHistory.Name = "openReportsHistory";
            openReportsHistory.Size = new Size(200, 22);
            openReportsHistory.Text = "Histórico de relatórios";
            // 
            // cobrançasToolStripMenuItem
            // 
            cobrançasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openClientsListBtn, cadastrarClienteToolStripMenuItem });
            cobrançasToolStripMenuItem.Name = "cobrançasToolStripMenuItem";
            cobrançasToolStripMenuItem.Size = new Size(66, 20);
            cobrançasToolStripMenuItem.Text = "Clientes";
            // 
            // openClientsListBtn
            // 
            openClientsListBtn.Name = "openClientsListBtn";
            openClientsListBtn.Size = new Size(172, 22);
            openClientsListBtn.Text = "Lista de clientes";
            openClientsListBtn.Click += AbrirClientesList_Click;
            // 
            // cadastrarClienteToolStripMenuItem
            // 
            cadastrarClienteToolStripMenuItem.Name = "cadastrarClienteToolStripMenuItem";
            cadastrarClienteToolStripMenuItem.Size = new Size(172, 22);
            cadastrarClienteToolStripMenuItem.Text = "Cadastrar cliente";
            cadastrarClienteToolStripMenuItem.Click += CadastrarCliente_Click;
            // 
            // cobrançasToolStripMenuItem1
            // 
            cobrançasToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { cobrancasPendentes, cobrancasPagas, cobrarTodos });
            cobrançasToolStripMenuItem1.Name = "cobrançasToolStripMenuItem1";
            cobrançasToolStripMenuItem1.Size = new Size(81, 20);
            cobrançasToolStripMenuItem1.Text = "Cobranças";
            // 
            // cobrancasPendentes
            // 
            cobrancasPendentes.Name = "cobrancasPendentes";
            cobrancasPendentes.Size = new Size(200, 22);
            cobrancasPendentes.Text = "Cobranças pendentes";
            cobrancasPendentes.Click += CobrancasPendentesToolStripMenuItem_Click;
            // 
            // cobrancasPagas
            // 
            cobrancasPagas.Name = "cobrancasPagas";
            cobrancasPagas.Size = new Size(200, 22);
            cobrancasPagas.Text = "Cobranças pagas";
            // 
            // cobrarTodos
            // 
            cobrarTodos.Name = "cobrarTodos";
            cobrarTodos.Size = new Size(200, 22);
            cobrarTodos.Text = "Cobrar todos";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menu);
            MainMenuStrip = menu;
            Name = "Main";
            Text = "Conta Fácil";
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem importarDadosToolStripMenuItem;
        private ToolStripMenuItem importFromExelBtn;
        private ToolStripMenuItem importFromJSONBtn;
        private ToolStripMenuItem exportToJSONBtn;
        private ToolStripMenuItem openSetingsBtn;
        private ToolStripMenuItem relatToolStripMenuItem;
        private ToolStripMenuItem newRelatoryBtn;
        private ToolStripMenuItem openReportsHistory;
        private ToolStripMenuItem cobrançasToolStripMenuItem;
        private ToolStripMenuItem openClientsListBtn;
        private ToolStripMenuItem cobrançasToolStripMenuItem1;
        private ToolStripMenuItem cobrancasPendentes;
        private ToolStripMenuItem cobrancasPagas;
        private ToolStripMenuItem cadastrarClienteToolStripMenuItem;
        private ToolStripMenuItem cobrarTodos;
        private ToolStripMenuItem tabelaExelToolStripMenuItem;
        private ToolStripMenuItem jSONToolStripMenuItem;
    }
}
