namespace Conta_Certa.Forms
{
    partial class CobrancaColumnManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CobrancaColumnManager));
            tableLayoutPanel1 = new TableLayoutPanel();
            cobrancaPanel = new TableLayoutPanel();
            cobrancasPropsList = new Panel();
            label1 = new Label();
            importarBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            cobrancaPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
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
            // cobrancaPanel
            // 
            cobrancaPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            cobrancaPanel.ColumnCount = 1;
            cobrancaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            cobrancaPanel.Controls.Add(cobrancasPropsList, 0, 1);
            cobrancaPanel.Controls.Add(label1, 0, 0);
            cobrancaPanel.Dock = DockStyle.Fill;
            cobrancaPanel.Location = new Point(3, 3);
            cobrancaPanel.Name = "cobrancaPanel";
            cobrancaPanel.RowCount = 2;
            cobrancaPanel.RowStyles.Add(new RowStyle());
            cobrancaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            cobrancaPanel.Size = new Size(794, 406);
            cobrancaPanel.TabIndex = 5;
            // 
            // cobrancasPropsList
            // 
            cobrancasPropsList.AutoScroll = true;
            cobrancasPropsList.Dock = DockStyle.Fill;
            cobrancasPropsList.Location = new Point(5, 38);
            cobrancasPropsList.Name = "cobrancasPropsList";
            cobrancasPropsList.Size = new Size(784, 363);
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
            label1.Size = new Size(778, 19);
            label1.TabIndex = 3;
            label1.Text = "IMPORTAR COBRANÇAS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // importarBtn
            // 
            importarBtn.BackColor = Color.Green;
            importarBtn.Dock = DockStyle.Fill;
            importarBtn.FlatStyle = FlatStyle.Flat;
            importarBtn.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            importarBtn.ForeColor = SystemColors.HighlightText;
            importarBtn.Location = new Point(4, 416);
            importarBtn.Margin = new Padding(4);
            importarBtn.Name = "importarBtn";
            importarBtn.Size = new Size(792, 30);
            importarBtn.TabIndex = 6;
            importarBtn.Text = "IMPORTAR";
            importarBtn.UseVisualStyleBackColor = false;
            importarBtn.Click += Import_Click;
            // 
            // CobrancaColumnManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "CobrancaColumnManager";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Selecinar Colunas";
            Shown += ExcelColumnAssistant_Shown;
            tableLayoutPanel1.ResumeLayout(false);
            cobrancaPanel.ResumeLayout(false);
            cobrancaPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel cobrancaPanel;
        private Label label1;
        private Button importarBtn;
        private Panel cobrancasPropsList;
    }
}