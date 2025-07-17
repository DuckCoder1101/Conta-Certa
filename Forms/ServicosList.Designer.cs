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
            tableLayoutPanel1 = new TableLayoutPanel();
            searchbarControl1 = new Conta_Certa.UserControls.SearchbarControl();
            servicosPanel = new Panel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(searchbarControl1, 0, 0);
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
            // searchbarControl1
            // 
            searchbarControl1.Dock = DockStyle.Top;
            searchbarControl1.Location = new Point(5, 5);
            searchbarControl1.Margin = new Padding(0);
            searchbarControl1.Name = "searchbarControl1";
            searchbarControl1.Size = new Size(790, 28);
            searchbarControl1.TabIndex = 0;
            // 
            // servicosPanel
            // 
            servicosPanel.Dock = DockStyle.Fill;
            servicosPanel.Location = new Point(5, 33);
            servicosPanel.Margin = new Padding(0);
            servicosPanel.Name = "servicosPanel";
            servicosPanel.Size = new Size(790, 412);
            servicosPanel.TabIndex = 1;
            // 
            // ServicosList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "ServicosList";
            Text = "ServicosList";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UserControls.SearchbarControl searchbarControl1;
        private Panel servicosPanel;
    }
}