using Conta_Certa.Components;
using Conta_Certa.Models;

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
                _dbContext.Dispose();
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
            alterarToolStripMenuItem = new ToolStripMenuItem();
            excluirToolStripMenuItem = new ToolStripMenuItem();
            tablePanel = new TableLayoutPanel();
            searchbar = new Conta_Certa.UserControls.SearchbarControl();
            tablePanel.SuspendLayout();
            SuspendLayout();
            // 
            // alterarToolStripMenuItem
            // 
            alterarToolStripMenuItem.Name = "alterarToolStripMenuItem";
            alterarToolStripMenuItem.Size = new Size(114, 22);
            alterarToolStripMenuItem.Text = "Alterar";
            // 
            // excluirToolStripMenuItem
            // 
            excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            excluirToolStripMenuItem.Size = new Size(114, 22);
            excluirToolStripMenuItem.Text = "Excluir";
            // 
            // tablePanel
            // 
            tablePanel.ColumnCount = 1;
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tablePanel.Controls.Add(searchbar, 0, 0);
            tablePanel.Dock = DockStyle.Fill;
            tablePanel.Location = new Point(0, 0);
            tablePanel.Name = "tablePanel";
            tablePanel.Padding = new Padding(5);
            tablePanel.RowCount = 2;
            tablePanel.RowStyles.Add(new RowStyle());
            tablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tablePanel.Size = new Size(800, 450);
            tablePanel.TabIndex = 0;
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
            Controls.Add(tablePanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClientesList";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lista de clientes";
            tablePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ToolStripMenuItem alterarToolStripMenuItem;
        private ToolStripMenuItem excluirToolStripMenuItem;
        private TableLayoutPanel tablePanel;
        private UserControls.SearchbarControl searchbar;
    }
}