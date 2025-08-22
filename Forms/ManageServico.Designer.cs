namespace Conta_Certa.Forms
{
    partial class ManageServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageServico));
            tableLayoutPanel1 = new TableLayoutPanel();
            cadastrarBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            nomeTxt = new TextBox();
            valorNb = new NumericUpDown();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)valorNb).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(cadastrarBtn, 0, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(nomeTxt, 1, 0);
            tableLayoutPanel1.Controls.Add(valorNb, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(464, 124);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // cadastrarBtn
            // 
            cadastrarBtn.Anchor = AnchorStyles.None;
            cadastrarBtn.BackColor = SystemColors.Window;
            tableLayoutPanel1.SetColumnSpan(cadastrarBtn, 2);
            cadastrarBtn.Cursor = Cursors.Hand;
            cadastrarBtn.FlatStyle = FlatStyle.Flat;
            cadastrarBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cadastrarBtn.Location = new Point(142, 78);
            cadastrarBtn.Name = "cadastrarBtn";
            cadastrarBtn.Size = new Size(180, 40);
            cadastrarBtn.TabIndex = 13;
            cadastrarBtn.Text = "CADASTRAR";
            cadastrarBtn.UseVisualStyleBackColor = false;
            cadastrarBtn.Click += CadastrarBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Arial", 12F);
            label1.Location = new Point(8, 0);
            label1.Margin = new Padding(8, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(220, 36);
            label1.TabIndex = 0;
            label1.Text = "*NOME";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Arial", 12F);
            label2.Location = new Point(8, 36);
            label2.Margin = new Padding(8, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(220, 36);
            label2.TabIndex = 2;
            label2.Text = "*VALOR";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nomeTxt
            // 
            nomeTxt.BorderStyle = BorderStyle.FixedSingle;
            nomeTxt.Dock = DockStyle.Top;
            nomeTxt.Font = new Font("Arial", 9.75F);
            nomeTxt.Location = new Point(236, 7);
            nomeTxt.Margin = new Padding(4, 7, 4, 7);
            nomeTxt.Name = "nomeTxt";
            nomeTxt.Size = new Size(224, 22);
            nomeTxt.TabIndex = 1;
            // 
            // valorNb
            // 
            valorNb.BorderStyle = BorderStyle.FixedSingle;
            valorNb.DecimalPlaces = 2;
            valorNb.Dock = DockStyle.Fill;
            valorNb.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valorNb.Location = new Point(236, 43);
            valorNb.Margin = new Padding(4, 7, 4, 7);
            valorNb.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            valorNb.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            valorNb.Name = "valorNb";
            valorNb.Size = new Size(224, 22);
            valorNb.TabIndex = 11;
            valorNb.ThousandsSeparator = true;
            valorNb.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ManageServico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 124);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ManageServico";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ManageServico";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)valorNb).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private TextBox nomeTxt;
        private NumericUpDown valorNb;
        private Button cadastrarBtn;
    }
}