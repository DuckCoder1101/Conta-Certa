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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCobranca));
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            label7 = new Label();
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
            searchbar = new Conta_Certa.UserControls.ClientesSearchbar();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)honorarioNb).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(label7, 0, 5);
            tableLayoutPanel2.Controls.Add(label3, 0, 1);
            tableLayoutPanel2.Controls.Add(honorarioNb, 1, 1);
            tableLayoutPanel2.Controls.Add(label4, 0, 2);
            tableLayoutPanel2.Controls.Add(statusCb, 1, 2);
            tableLayoutPanel2.Controls.Add(label5, 0, 3);
            tableLayoutPanel2.Controls.Add(vencimentoTxt, 1, 3);
            tableLayoutPanel2.Controls.Add(label6, 0, 4);
            tableLayoutPanel2.Controls.Add(pagoEmTxt, 1, 4);
            tableLayoutPanel2.Controls.Add(cadastrarBtn, 0, 6);
            tableLayoutPanel2.Controls.Add(servicosPanel, 1, 5);
            tableLayoutPanel2.Controls.Add(searchbar, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(572, 328);
            tableLayoutPanel2.TabIndex = 2;
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
            label1.TabIndex = 20;
            label1.Text = "CLIENTE";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Arial", 12F);
            label7.Location = new Point(8, 182);
            label7.Margin = new Padding(8, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(274, 70);
            label7.TabIndex = 18;
            label7.Text = "SERVIÇOS";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Arial", 12F);
            label3.Location = new Point(8, 36);
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
            honorarioNb.Location = new Point(290, 43);
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
            label4.Location = new Point(8, 72);
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
            statusCb.Location = new Point(290, 79);
            statusCb.Margin = new Padding(4, 7, 4, 7);
            statusCb.Name = "statusCb";
            statusCb.Size = new Size(278, 24);
            statusCb.TabIndex = 13;
            statusCb.SelectedValueChanged += StatusCb_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Arial", 12F);
            label5.Location = new Point(8, 110);
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
            vencimentoTxt.Location = new Point(290, 117);
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
            label6.Location = new Point(8, 146);
            label6.Margin = new Padding(8, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(274, 36);
            label6.TabIndex = 15;
            label6.Text = "*PAGO EM";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pagoEmTxt
            // 
            pagoEmTxt.BackColor = SystemColors.Window;
            pagoEmTxt.BorderStyle = BorderStyle.FixedSingle;
            pagoEmTxt.Dock = DockStyle.Fill;
            pagoEmTxt.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pagoEmTxt.Location = new Point(290, 153);
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
            cadastrarBtn.Anchor = AnchorStyles.None;
            cadastrarBtn.BackColor = SystemColors.Window;
            tableLayoutPanel2.SetColumnSpan(cadastrarBtn, 2);
            cadastrarBtn.Cursor = Cursors.Hand;
            cadastrarBtn.FlatStyle = FlatStyle.Flat;
            cadastrarBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cadastrarBtn.Location = new Point(196, 270);
            cadastrarBtn.Name = "cadastrarBtn";
            cadastrarBtn.Size = new Size(180, 40);
            cadastrarBtn.TabIndex = 10;
            cadastrarBtn.Text = "CADASTRAR";
            cadastrarBtn.UseVisualStyleBackColor = false;
            cadastrarBtn.Click += CadastrarBtn_Click;
            // 
            // servicosPanel
            // 
            servicosPanel.AutoScroll = true;
            servicosPanel.BorderStyle = BorderStyle.FixedSingle;
            servicosPanel.Dock = DockStyle.Fill;
            servicosPanel.Location = new Point(289, 185);
            servicosPanel.Name = "servicosPanel";
            servicosPanel.Size = new Size(280, 64);
            servicosPanel.TabIndex = 19;
            // 
            // searchbar
            // 
            searchbar.Dock = DockStyle.Fill;
            searchbar.Location = new Point(286, 0);
            searchbar.Margin = new Padding(0);
            searchbar.Name = "searchbar";
            searchbar.Size = new Size(286, 36);
            searchbar.TabIndex = 21;
            // 
            // ManageCobranca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 328);
            Controls.Add(tableLayoutPanel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ManageCobranca";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ManageCobranca";
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)honorarioNb).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Label label7;
        private Label label3;
        private NumericUpDown honorarioNb;
        private Label label4;
        private ComboBox statusCb;
        private Label label5;
        private MaskedTextBox vencimentoTxt;
        private Label label6;
        private MaskedTextBox pagoEmTxt;
        private Button cadastrarBtn;
        private Panel servicosPanel;
        private UserControls.ClientesSearchbar searchbar;
    }
}