namespace Conta_Certa.Forms
{
    partial class ManageCobranca
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
            label7 = new Label();
            label1 = new Label();
            idClienteNb = new NumericUpDown();
            label2 = new Label();
            nomeClienteTxt = new TextBox();
            label3 = new Label();
            honorarioNb = new NumericUpDown();
            label4 = new Label();
            statusCb = new ComboBox();
            label5 = new Label();
            vencimentoTxt = new MaskedTextBox();
            label6 = new Label();
            pagoEmTxt = new MaskedTextBox();
            cadastrarBtn = new Button();
            servicosPanel = new Panel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)idClienteNb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)honorarioNb).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(idClienteNb, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(nomeClienteTxt, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(honorarioNb, 1, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(statusCb, 1, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(vencimentoTxt, 1, 4);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(pagoEmTxt, 1, 5);
            tableLayoutPanel1.Controls.Add(cadastrarBtn, 0, 7);
            tableLayoutPanel1.Controls.Add(servicosPanel, 1, 6);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(572, 348);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Arial", 12F);
            label7.Location = new Point(8, 218);
            label7.Margin = new Padding(8, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(274, 66);
            label7.TabIndex = 18;
            label7.Text = "SERVIÇOS";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Arial", 12F);
            label1.Location = new Point(8, 0);
            label1.Margin = new Padding(8, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(274, 36);
            label1.TabIndex = 0;
            label1.Text = "*ID CLIENTE";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // idClienteNb
            // 
            idClienteNb.BorderStyle = BorderStyle.FixedSingle;
            idClienteNb.Dock = DockStyle.Fill;
            idClienteNb.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idClienteNb.Location = new Point(290, 7);
            idClienteNb.Margin = new Padding(4, 7, 4, 7);
            idClienteNb.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            idClienteNb.Name = "idClienteNb";
            idClienteNb.Size = new Size(278, 22);
            idClienteNb.TabIndex = 11;
            idClienteNb.ValueChanged += IdClienteNb_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Arial", 12F);
            label2.Location = new Point(8, 36);
            label2.Margin = new Padding(8, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(274, 36);
            label2.TabIndex = 2;
            label2.Text = "NOME CLIENTE";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nomeClienteTxt
            // 
            nomeClienteTxt.BorderStyle = BorderStyle.FixedSingle;
            nomeClienteTxt.Dock = DockStyle.Top;
            nomeClienteTxt.Font = new Font("Arial", 9.75F);
            nomeClienteTxt.Location = new Point(290, 43);
            nomeClienteTxt.Margin = new Padding(4, 7, 4, 7);
            nomeClienteTxt.Name = "nomeClienteTxt";
            nomeClienteTxt.ReadOnly = true;
            nomeClienteTxt.Size = new Size(278, 22);
            nomeClienteTxt.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Arial", 12F);
            label3.Location = new Point(8, 72);
            label3.Margin = new Padding(8, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(274, 36);
            label3.TabIndex = 4;
            label3.Text = "*HONORÁRIO BASE";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // honorarioNb
            // 
            honorarioNb.DecimalPlaces = 2;
            honorarioNb.Dock = DockStyle.Fill;
            honorarioNb.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            honorarioNb.Location = new Point(290, 79);
            honorarioNb.Margin = new Padding(4, 7, 4, 7);
            honorarioNb.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            honorarioNb.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            honorarioNb.Name = "honorarioNb";
            honorarioNb.Size = new Size(278, 22);
            honorarioNb.TabIndex = 14;
            honorarioNb.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Arial", 12F);
            label4.Location = new Point(8, 108);
            label4.Margin = new Padding(8, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(274, 38);
            label4.TabIndex = 6;
            label4.Text = "*STATUS";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // statusCb
            // 
            statusCb.Dock = DockStyle.Fill;
            statusCb.DropDownStyle = ComboBoxStyle.DropDownList;
            statusCb.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusCb.FormattingEnabled = true;
            statusCb.Location = new Point(290, 115);
            statusCb.Margin = new Padding(4, 7, 4, 7);
            statusCb.Name = "statusCb";
            statusCb.Size = new Size(278, 24);
            statusCb.TabIndex = 13;
            statusCb.SelectedIndexChanged += StatusCb_SelectedIndexChanged_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Arial", 12F);
            label5.Location = new Point(8, 146);
            label5.Margin = new Padding(8, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(274, 36);
            label5.TabIndex = 8;
            label5.Text = "*VENCIMENTO";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // vencimentoTxt
            // 
            vencimentoTxt.BorderStyle = BorderStyle.FixedSingle;
            vencimentoTxt.Dock = DockStyle.Fill;
            vencimentoTxt.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vencimentoTxt.Location = new Point(290, 153);
            vencimentoTxt.Margin = new Padding(4, 7, 4, 7);
            vencimentoTxt.Mask = "00/00/0000";
            vencimentoTxt.Name = "vencimentoTxt";
            vencimentoTxt.Size = new Size(278, 22);
            vencimentoTxt.TabIndex = 16;
            vencimentoTxt.ValidatingType = typeof(DateTime);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Arial", 12F);
            label6.Location = new Point(8, 182);
            label6.Margin = new Padding(8, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(274, 36);
            label6.TabIndex = 15;
            label6.Text = "*PAGO EM";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pagoEmTxt
            // 
            pagoEmTxt.BorderStyle = BorderStyle.FixedSingle;
            pagoEmTxt.Dock = DockStyle.Fill;
            pagoEmTxt.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pagoEmTxt.Location = new Point(290, 189);
            pagoEmTxt.Margin = new Padding(4, 7, 4, 7);
            pagoEmTxt.Mask = "00/00/0000";
            pagoEmTxt.Name = "pagoEmTxt";
            pagoEmTxt.ReadOnly = true;
            pagoEmTxt.Size = new Size(278, 22);
            pagoEmTxt.TabIndex = 17;
            pagoEmTxt.ValidatingType = typeof(DateTime);
            // 
            // cadastrarBtn
            // 
            tableLayoutPanel1.SetColumnSpan(cadastrarBtn, 2);
            cadastrarBtn.Cursor = Cursors.Hand;
            cadastrarBtn.Dock = DockStyle.Fill;
            cadastrarBtn.FlatStyle = FlatStyle.Flat;
            cadastrarBtn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cadastrarBtn.Location = new Point(3, 287);
            cadastrarBtn.Name = "cadastrarBtn";
            cadastrarBtn.Size = new Size(566, 58);
            cadastrarBtn.TabIndex = 10;
            cadastrarBtn.Text = "CADASTRAR";
            cadastrarBtn.UseVisualStyleBackColor = true;
            cadastrarBtn.Click += CadastrarBtn_Click;
            // 
            // servicosPanel
            // 
            servicosPanel.AutoScroll = true;
            servicosPanel.Dock = DockStyle.Fill;
            servicosPanel.Location = new Point(290, 225);
            servicosPanel.Margin = new Padding(4, 7, 4, 7);
            servicosPanel.Name = "servicosPanel";
            servicosPanel.Size = new Size(278, 52);
            servicosPanel.TabIndex = 19;
            // 
            // ManageCobranca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 348);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ManageCobranca";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ManageCobranca";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)idClienteNb).EndInit();
            ((System.ComponentModel.ISupportInitialize)honorarioNb).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button cadastrarBtn;
        private NumericUpDown idClienteNb;
        private TextBox nomeClienteTxt;
        private ComboBox statusCb;
        private NumericUpDown honorarioNb;
        private Label label6;
        private MaskedTextBox vencimentoTxt;
        private MaskedTextBox pagoEmTxt;
        private Label label7;
        private Panel servicosPanel;
    }
}