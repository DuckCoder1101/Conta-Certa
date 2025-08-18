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
            openSetingsBtn = new ToolStripMenuItem();
            configuraçõesToolStripMenuItem = new ToolStripMenuItem();
            cobrançasToolStripMenuItem = new ToolStripMenuItem();
            openClientsListBtn = new ToolStripMenuItem();
            cadastrarClienteToolStripMenuItem = new ToolStripMenuItem();
            cobrançasToolStripMenuItem1 = new ToolStripMenuItem();
            cobrancasPendentes = new ToolStripMenuItem();
            cobrancasPagas = new ToolStripMenuItem();
            gerarCobrancas = new ToolStripMenuItem();
            enviarCobrançasPorWhastappToolStripMenuItem = new ToolStripMenuItem();
            enviarCobrançasPorEmailToolStripMenuItem = new ToolStripMenuItem();
            serviçosToolStripMenuItem = new ToolStripMenuItem();
            listaDeServiçosToolStripMenuItem = new ToolStripMenuItem();
            cadastrarServiçoToolStripMenuItem = new ToolStripMenuItem();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.BackColor = SystemColors.ControlLight;
            menu.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menu.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem, cobrançasToolStripMenuItem, cobrançasToolStripMenuItem1, serviçosToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(800, 24);
            menu.TabIndex = 0;
            menu.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importarDadosToolStripMenuItem, exportToJSONBtn, openSetingsBtn, configuraçõesToolStripMenuItem });
            arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            arquivoToolStripMenuItem.Size = new Size(61, 20);
            arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // importarDadosToolStripMenuItem
            // 
            importarDadosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importFromExelBtn, importFromJSONBtn });
            importarDadosToolStripMenuItem.Name = "importarDadosToolStripMenuItem";
            importarDadosToolStripMenuItem.Size = new Size(190, 22);
            importarDadosToolStripMenuItem.Text = "Importar";
            // 
            // importFromExelBtn
            // 
            importFromExelBtn.Name = "importFromExelBtn";
            importFromExelBtn.Size = new Size(148, 22);
            importFromExelBtn.Text = "Tabela Excel";
            importFromExelBtn.Click += ImportFromExcelBtn_Click;
            // 
            // importFromJSONBtn
            // 
            importFromJSONBtn.Name = "importFromJSONBtn";
            importFromJSONBtn.Size = new Size(148, 22);
            importFromJSONBtn.Text = "JSON";
            importFromJSONBtn.Click += ImportFromJSON_Click;
            // 
            // exportToJSONBtn
            // 
            exportToJSONBtn.Name = "exportToJSONBtn";
            exportToJSONBtn.Size = new Size(190, 22);
            exportToJSONBtn.Text = "Exportar para JSON";
            exportToJSONBtn.Click += ExportToJSON_Click;
            // 
            // openSetingsBtn
            // 
            openSetingsBtn.Name = "openSetingsBtn";
            openSetingsBtn.Size = new Size(190, 22);
            openSetingsBtn.Text = "Gerar relatório";
            openSetingsBtn.Click += GerarRelatorio;
            // 
            // configuraçõesToolStripMenuItem
            // 
            configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            configuraçõesToolStripMenuItem.Size = new Size(190, 22);
            configuraçõesToolStripMenuItem.Text = "Configurações";
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
            cobrançasToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { cobrancasPendentes, cobrancasPagas, gerarCobrancas, enviarCobrançasPorWhastappToolStripMenuItem, enviarCobrançasPorEmailToolStripMenuItem });
            cobrançasToolStripMenuItem1.Name = "cobrançasToolStripMenuItem1";
            cobrançasToolStripMenuItem1.Size = new Size(81, 20);
            cobrançasToolStripMenuItem1.Text = "Cobranças";
            // 
            // cobrancasPendentes
            // 
            cobrancasPendentes.Name = "cobrancasPendentes";
            cobrancasPendentes.Size = new Size(258, 22);
            cobrancasPendentes.Text = "Cobranças pendentes";
            cobrancasPendentes.Click += CobrancasPendentes_Menu_Click;
            // 
            // cobrancasPagas
            // 
            cobrancasPagas.Name = "cobrancasPagas";
            cobrancasPagas.Size = new Size(258, 22);
            cobrancasPagas.Text = "Cobranças pagas";
            cobrancasPagas.Click += CobrancasPagas_Click;
            // 
            // gerarCobrancas
            // 
            gerarCobrancas.Name = "gerarCobrancas";
            gerarCobrancas.Size = new Size(258, 22);
            gerarCobrancas.Text = "Gerar cobranças do mês";
            gerarCobrancas.Click += GerarCobrancas_Click;
            // 
            // enviarCobrançasPorWhastappToolStripMenuItem
            // 
            enviarCobrançasPorWhastappToolStripMenuItem.Name = "enviarCobrançasPorWhastappToolStripMenuItem";
            enviarCobrançasPorWhastappToolStripMenuItem.Size = new Size(258, 22);
            enviarCobrançasPorWhastappToolStripMenuItem.Text = "Enviar cobranças por Whastapp";
            enviarCobrançasPorWhastappToolStripMenuItem.Click += EnviarCobrancasPorWhastapp_Click;
            // 
            // enviarCobrançasPorEmailToolStripMenuItem
            // 
            enviarCobrançasPorEmailToolStripMenuItem.Name = "enviarCobrançasPorEmailToolStripMenuItem";
            enviarCobrançasPorEmailToolStripMenuItem.Size = new Size(258, 22);
            enviarCobrançasPorEmailToolStripMenuItem.Text = "Enviar cobranças por email";
            // 
            // serviçosToolStripMenuItem
            // 
            serviçosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listaDeServiçosToolStripMenuItem, cadastrarServiçoToolStripMenuItem });
            serviçosToolStripMenuItem.Name = "serviçosToolStripMenuItem";
            serviçosToolStripMenuItem.Size = new Size(68, 20);
            serviçosToolStripMenuItem.Text = "Serviços";
            // 
            // listaDeServiçosToolStripMenuItem
            // 
            listaDeServiçosToolStripMenuItem.Name = "listaDeServiçosToolStripMenuItem";
            listaDeServiçosToolStripMenuItem.Size = new Size(174, 22);
            listaDeServiçosToolStripMenuItem.Text = "Lista de serviços";
            listaDeServiçosToolStripMenuItem.Click += ListaServicos_Menu_Click;
            // 
            // cadastrarServiçoToolStripMenuItem
            // 
            cadastrarServiçoToolStripMenuItem.Name = "cadastrarServiçoToolStripMenuItem";
            cadastrarServiçoToolStripMenuItem.Size = new Size(174, 22);
            cadastrarServiçoToolStripMenuItem.Text = "Cadastrar serviço";
            cadastrarServiçoToolStripMenuItem.Click += CadastrarSevico_Menu_Click;
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
        private ToolStripMenuItem cobrançasToolStripMenuItem;
        private ToolStripMenuItem openClientsListBtn;
        private ToolStripMenuItem cobrançasToolStripMenuItem1;
        private ToolStripMenuItem cobrancasPendentes;
        private ToolStripMenuItem cobrancasPagas;
        private ToolStripMenuItem cadastrarClienteToolStripMenuItem;
        private ToolStripMenuItem gerarCobrancas;
        private ToolStripMenuItem serviçosToolStripMenuItem;
        private ToolStripMenuItem listaDeServiçosToolStripMenuItem;
        private ToolStripMenuItem cadastrarServiçoToolStripMenuItem;
        private ToolStripMenuItem enviarCobrançasPorWhastappToolStripMenuItem;
        private ToolStripMenuItem enviarCobrançasPorEmailToolStripMenuItem;
        private ToolStripMenuItem configuraçõesToolStripMenuItem;
    }
}
