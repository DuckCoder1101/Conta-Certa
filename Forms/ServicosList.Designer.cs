namespace Conta_Certa.Forms
{
    partial class ServicosList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicosList));
            tableLayoutPanel1 = new TableLayoutPanel();
            searchbar = new Conta_Certa.UserControls.SearchbarControl();
            servicosPanel = new Panel();
            menu = new ContextMenuStrip(components);
            alterarToolStripMenuItem = new ToolStripMenuItem();
            excluirToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(searchbar, 0, 0);
            tableLayoutPanel1.Controls.Add(servicosPanel, 0, 1);
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
            searchbar.TabIndex = 0;
            // 
            // servicosPanel
            // 
            servicosPanel.AutoScroll = true;
            servicosPanel.Dock = DockStyle.Fill;
            servicosPanel.Location = new Point(5, 33);
            servicosPanel.Margin = new Padding(0);
            servicosPanel.Name = "servicosPanel";
            servicosPanel.Size = new Size(790, 412);
            servicosPanel.TabIndex = 1;
            // 
            // menu
            // 
            menu.Items.AddRange(new ToolStripItem[] { alterarToolStripMenuItem, excluirToolStripMenuItem });
            menu.Name = "menu";
            menu.Size = new Size(110, 48);
            menu.Text = "Menu";
            // 
            // alterarToolStripMenuItem
            // 
            alterarToolStripMenuItem.Name = "alterarToolStripMenuItem";
            alterarToolStripMenuItem.Size = new Size(109, 22);
            alterarToolStripMenuItem.Text = "Alterar";
            alterarToolStripMenuItem.Click += Alterar_Menu_Click;
            // 
            // excluirToolStripMenuItem
            // 
            excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            excluirToolStripMenuItem.Size = new Size(109, 22);
            excluirToolStripMenuItem.Text = "Excluir";
            excluirToolStripMenuItem.Click += Excluir_Menu_Click;
            // 
            // ServicosList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ServicosList";
            Text = "ServicosList";
            FormClosing += ServicosList_FormClosing;
            tableLayoutPanel1.ResumeLayout(false);
            menu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UserControls.SearchbarControl searchbar;
        private Panel servicosPanel;
        private ContextMenuStrip menu;
        private ToolStripMenuItem alterarToolStripMenuItem;
        private ToolStripMenuItem excluirToolStripMenuItem;
    }
}