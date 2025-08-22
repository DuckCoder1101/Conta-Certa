namespace Conta_Certa.Forms
{
    partial class ClientesList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesList));
            menu = new ContextMenuStrip(components);
            verCobrançasToolStripMenuItem = new ToolStripMenuItem();
            alterarToolStripMenuItem = new ToolStripMenuItem();
            excluirToolStripMenuItem = new ToolStripMenuItem();
            clientesPanel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            searchbar = new Conta_Certa.UserControls.SearchbarControl();
            menu.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menu.Items.AddRange(new ToolStripItem[] { verCobrançasToolStripMenuItem, alterarToolStripMenuItem, excluirToolStripMenuItem });
            menu.Name = "menu";
            menu.Size = new Size(158, 70);
            menu.Text = "Menu cliente";
            // 
            // verCobrançasToolStripMenuItem
            // 
            verCobrançasToolStripMenuItem.Name = "verCobrançasToolStripMenuItem";
            verCobrançasToolStripMenuItem.Size = new Size(157, 22);
            verCobrançasToolStripMenuItem.Text = "Ver cobranças";
            // 
            // alterarToolStripMenuItem
            // 
            alterarToolStripMenuItem.Name = "alterarToolStripMenuItem";
            alterarToolStripMenuItem.Size = new Size(157, 22);
            alterarToolStripMenuItem.Text = "Alterar";
            alterarToolStripMenuItem.Click += Alterar_Menu_Click;
            // 
            // excluirToolStripMenuItem
            // 
            excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            excluirToolStripMenuItem.Size = new Size(157, 22);
            excluirToolStripMenuItem.Text = "Excluir";
            excluirToolStripMenuItem.Click += Excluir_Menu_Click;
            // 
            // clientesPanel
            // 
            clientesPanel.Dock = DockStyle.Fill;
            clientesPanel.Location = new Point(5, 33);
            clientesPanel.Margin = new Padding(0);
            clientesPanel.Name = "clientesPanel";
            clientesPanel.Size = new Size(790, 412);
            clientesPanel.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(clientesPanel, 0, 1);
            tableLayoutPanel1.Controls.Add(searchbar, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(5);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // searchbar
            // 
            searchbar.Dock = DockStyle.Top;
            searchbar.Location = new Point(5, 5);
            searchbar.Margin = new Padding(0);
            searchbar.Name = "searchbar";
            searchbar.Size = new Size(790, 28);
            searchbar.TabIndex = 4;
            // 
            // ClientesList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClientesList";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lista de clientes";
            FormClosing += ClientesList_FormClosing;
            menu.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip menu;
        private ToolStripMenuItem verCobrançasToolStripMenuItem;
        private ToolStripMenuItem alterarToolStripMenuItem;
        private ToolStripMenuItem excluirToolStripMenuItem;
        private Panel clientesPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private UserControls.SearchbarControl searchbar;
    }
}