namespace Conta_Certa.Forms
{
    partial class ExcelColumnAssistant
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
            clientePanel = new TableLayoutPanel();
            clientesPropsList = new Panel();
            cobrancaPanel = new TableLayoutPanel();
            cobrancasPropsList = new Panel();
            label1 = new Label();
            importarBtn = new Button();
            label4 = new Label();
            tableLayoutPanel1.SuspendLayout();
            clientePanel.SuspendLayout();
            cobrancaPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(clientePanel, 0, 0);
            tableLayoutPanel1.Controls.Add(cobrancaPanel, 1, 0);
            tableLayoutPanel1.Controls.Add(importarBtn, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // clientePanel
            // 
            clientePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            clientePanel.ColumnCount = 1;
            clientePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            clientePanel.Controls.Add(label4, 0, 0);
            clientePanel.Controls.Add(clientesPropsList, 0, 1);
            clientePanel.Dock = DockStyle.Fill;
            clientePanel.Location = new Point(3, 3);
            clientePanel.Name = "clientePanel";
            clientePanel.RowCount = 2;
            clientePanel.RowStyles.Add(new RowStyle());
            clientePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            clientePanel.Size = new Size(394, 406);
            clientePanel.TabIndex = 4;
            // 
            // clientesPropsList
            // 
            clientesPropsList.Dock = DockStyle.Fill;
            clientesPropsList.Location = new Point(5, 38);
            clientesPropsList.Name = "clientesPropsList";
            clientesPropsList.Size = new Size(384, 363);
            clientesPropsList.TabIndex = 4;
            // 
            // cobrancaPanel
            // 
            cobrancaPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            cobrancaPanel.ColumnCount = 1;
            cobrancaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            cobrancaPanel.Controls.Add(cobrancasPropsList, 0, 1);
            cobrancaPanel.Controls.Add(label1, 0, 0);
            cobrancaPanel.Dock = DockStyle.Fill;
            cobrancaPanel.Location = new Point(403, 3);
            cobrancaPanel.Name = "cobrancaPanel";
            cobrancaPanel.RowCount = 2;
            cobrancaPanel.RowStyles.Add(new RowStyle());
            cobrancaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            cobrancaPanel.Size = new Size(394, 406);
            cobrancaPanel.TabIndex = 5;
            // 
            // cobrancasPropsList
            // 
            cobrancasPropsList.Dock = DockStyle.Fill;
            cobrancasPropsList.Location = new Point(5, 38);
            cobrancasPropsList.Name = "cobrancasPropsList";
            cobrancasPropsList.Size = new Size(384, 363);
            cobrancasPropsList.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold);
            label1.Location = new Point(8, 8);
            label1.Margin = new Padding(6);
            label1.Name = "label1";
            label1.Size = new Size(378, 19);
            label1.TabIndex = 3;
            label1.Text = "COBRANÇAS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // importarBtn
            // 
            importarBtn.BackColor = Color.Green;
            tableLayoutPanel1.SetColumnSpan(importarBtn, 2);
            importarBtn.Dock = DockStyle.Right;
            importarBtn.FlatStyle = FlatStyle.Flat;
            importarBtn.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            importarBtn.ForeColor = SystemColors.HighlightText;
            importarBtn.Location = new Point(694, 416);
            importarBtn.Margin = new Padding(4);
            importarBtn.Name = "importarBtn";
            importarBtn.Size = new Size(102, 30);
            importarBtn.TabIndex = 6;
            importarBtn.Text = "IMPORTAR";
            importarBtn.UseVisualStyleBackColor = false;
            importarBtn.Click += Import_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold);
            label4.Location = new Point(8, 8);
            label4.Margin = new Padding(6);
            label4.Name = "label4";
            label4.Size = new Size(378, 19);
            label4.TabIndex = 3;
            label4.Text = "CLIENTES";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ExcelColumnAssistant
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ExcelColumnAssistant";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Selecinar Colunas";
            Shown += ExcelColumnAssistant_Shown;
            tableLayoutPanel1.ResumeLayout(false);
            clientePanel.ResumeLayout(false);
            clientePanel.PerformLayout();
            cobrancaPanel.ResumeLayout(false);
            cobrancaPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel clientePanel;
        private TableLayoutPanel cobrancaPanel;
        private Label label1;
        private Button importarBtn;
        private Panel clientesPropsList;
        private Panel cobrancasPropsList;
        private Label label4;
    }
}