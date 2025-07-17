namespace Conta_Certa.Forms
{
    partial class ManageCliente
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            nomeTxt = new TextBox();
            telefoneTxt = new MaskedTextBox();
            emailTxt = new TextBox();
            honorarioNumber = new NumericUpDown();
            vencimentoNumber = new NumericUpDown();
            cadastrarBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)honorarioNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vencimentoNumber).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(nomeTxt, 1, 0);
            tableLayoutPanel1.Controls.Add(telefoneTxt, 1, 1);
            tableLayoutPanel1.Controls.Add(emailTxt, 1, 2);
            tableLayoutPanel1.Controls.Add(honorarioNumber, 1, 3);
            tableLayoutPanel1.Controls.Add(vencimentoNumber, 1, 4);
            tableLayoutPanel1.Controls.Add(cadastrarBtn, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(474, 239);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Arial", 12F);
            label1.Location = new Point(8, 0);
            label1.Margin = new Padding(8, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(225, 36);
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
            label2.Size = new Size(225, 36);
            label2.TabIndex = 2;
            label2.Text = "*TELEFONE";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Arial", 12F);
            label3.Location = new Point(8, 72);
            label3.Margin = new Padding(8, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(225, 36);
            label3.TabIndex = 4;
            label3.Text = " EMAIL";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Arial", 12F);
            label4.Location = new Point(8, 108);
            label4.Margin = new Padding(8, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(225, 34);
            label4.TabIndex = 6;
            label4.Text = "*HONORÁRIO";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Arial", 12F);
            label5.Location = new Point(8, 142);
            label5.Margin = new Padding(8, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(225, 38);
            label5.TabIndex = 8;
            label5.Text = "*DIA VENCIMENTO";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nomeTxt
            // 
            nomeTxt.BorderStyle = BorderStyle.FixedSingle;
            nomeTxt.Dock = DockStyle.Top;
            nomeTxt.Font = new Font("Arial", 9.75F);
            nomeTxt.Location = new Point(241, 7);
            nomeTxt.Margin = new Padding(4, 7, 4, 7);
            nomeTxt.Name = "nomeTxt";
            nomeTxt.Size = new Size(229, 22);
            nomeTxt.TabIndex = 1;
            // 
            // telefoneTxt
            // 
            telefoneTxt.BorderStyle = BorderStyle.FixedSingle;
            telefoneTxt.Dock = DockStyle.Top;
            telefoneTxt.Font = new Font("Arial", 9.75F);
            telefoneTxt.Location = new Point(241, 43);
            telefoneTxt.Margin = new Padding(4, 7, 4, 7);
            telefoneTxt.Mask = "(99) 99999-9999";
            telefoneTxt.Name = "telefoneTxt";
            telefoneTxt.Size = new Size(229, 22);
            telefoneTxt.TabIndex = 3;
            // 
            // emailTxt
            // 
            emailTxt.BorderStyle = BorderStyle.FixedSingle;
            emailTxt.Dock = DockStyle.Top;
            emailTxt.Font = new Font("Arial", 9.75F);
            emailTxt.Location = new Point(241, 79);
            emailTxt.Margin = new Padding(4, 7, 4, 7);
            emailTxt.Name = "emailTxt";
            emailTxt.Size = new Size(229, 22);
            emailTxt.TabIndex = 5;
            // 
            // honorarioNumber
            // 
            honorarioNumber.BorderStyle = BorderStyle.FixedSingle;
            honorarioNumber.DecimalPlaces = 2;
            honorarioNumber.Dock = DockStyle.Top;
            honorarioNumber.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            honorarioNumber.Location = new Point(240, 114);
            honorarioNumber.Margin = new Padding(3, 6, 3, 6);
            honorarioNumber.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            honorarioNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            honorarioNumber.Name = "honorarioNumber";
            honorarioNumber.Size = new Size(231, 22);
            honorarioNumber.TabIndex = 7;
            honorarioNumber.ThousandsSeparator = true;
            honorarioNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // vencimentoNumber
            // 
            vencimentoNumber.Dock = DockStyle.Fill;
            vencimentoNumber.Location = new Point(240, 148);
            vencimentoNumber.Margin = new Padding(3, 6, 3, 6);
            vencimentoNumber.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            vencimentoNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            vencimentoNumber.Name = "vencimentoNumber";
            vencimentoNumber.Size = new Size(231, 26);
            vencimentoNumber.TabIndex = 9;
            vencimentoNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cadastrarBtn
            // 
            tableLayoutPanel1.SetColumnSpan(cadastrarBtn, 2);
            cadastrarBtn.Cursor = Cursors.Hand;
            cadastrarBtn.Dock = DockStyle.Fill;
            cadastrarBtn.FlatStyle = FlatStyle.Flat;
            cadastrarBtn.Location = new Point(3, 183);
            cadastrarBtn.Name = "cadastrarBtn";
            cadastrarBtn.Size = new Size(468, 53);
            cadastrarBtn.TabIndex = 10;
            cadastrarBtn.Text = "CADASTRAR";
            cadastrarBtn.UseVisualStyleBackColor = true;
            cadastrarBtn.Click += Cadastrar_Click;
            // 
            // ManageCliente
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 239);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Arial", 12F);
            Margin = new Padding(4);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ManageCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastrar cliente";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)honorarioNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)vencimentoNumber).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox emailTxt;
        private NumericUpDown honorarioNumber;
        private MaskedTextBox telefoneTxt;
        private TextBox nomeTxt;
        private Button cadastrarBtn;
        private NumericUpDown vencimentoNumber;
    }
}