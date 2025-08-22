namespace Conta_Certa.Forms
{
    partial class ClienteColumnManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClienteColumnManager));
            tableLayoutPanel1 = new TableLayoutPanel();
            clientePanel = new TableLayoutPanel();
            label4 = new Label();
            clientesPropsList = new Panel();
            importarBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            clientePanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(clientePanel, 0, 0);
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
            clientePanel.Size = new Size(794, 406);
            clientePanel.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold);
            label4.Location = new Point(8, 8);
            label4.Margin = new Padding(6);
            label4.Name = "label4";
            label4.Size = new Size(778, 19);
            label4.TabIndex = 3;
            label4.Text = "IMPORTAR CLIENTES";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clientesPropsList
            // 
            clientesPropsList.AutoScroll = true;
            clientesPropsList.Dock = DockStyle.Fill;
            clientesPropsList.Location = new Point(5, 38);
            clientesPropsList.Name = "clientesPropsList";
            clientesPropsList.Size = new Size(784, 363);
            clientesPropsList.TabIndex = 4;
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
            // ClienteColumnManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ClienteColumnManager";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Selecinar Colunas";
            Shown += ExcelColumnAssistant_Shown;
            tableLayoutPanel1.ResumeLayout(false);
            clientePanel.ResumeLayout(false);
            clientePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel clientePanel;
        private Button importarBtn;
        private Panel clientesPropsList;
        private Label label4;
    }
}