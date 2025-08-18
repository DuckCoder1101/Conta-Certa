namespace Conta_Certa.UserControls
{
    partial class ClienteControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            nomeTxt = new Label();
            documentoTxt = new Label();
            telefoneTxt = new Label();
            emailTxt = new Label();
            honorarioTxt = new Label();
            vencimentoTxt = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(nomeTxt, 0, 0);
            tableLayoutPanel1.Controls.Add(documentoTxt, 1, 0);
            tableLayoutPanel1.Controls.Add(telefoneTxt, 2, 0);
            tableLayoutPanel1.Controls.Add(emailTxt, 3, 0);
            tableLayoutPanel1.Controls.Add(honorarioTxt, 4, 0);
            tableLayoutPanel1.Controls.Add(vencimentoTxt, 5, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(912, 47);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Click += ClienteUserControl_Click;
            // 
            // nomeTxt
            // 
            nomeTxt.AutoSize = true;
            nomeTxt.Dock = DockStyle.Fill;
            nomeTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            nomeTxt.Location = new Point(5, 2);
            nomeTxt.Name = "nomeTxt";
            nomeTxt.Size = new Size(143, 43);
            nomeTxt.TabIndex = 1;
            nomeTxt.Text = "NOME";
            nomeTxt.TextAlign = ContentAlignment.MiddleCenter;
            nomeTxt.Click += ClienteUserControl_Click;
            // 
            // documentoTxt
            // 
            documentoTxt.AutoSize = true;
            documentoTxt.Dock = DockStyle.Fill;
            documentoTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            documentoTxt.Location = new Point(156, 2);
            documentoTxt.Name = "documentoTxt";
            documentoTxt.Size = new Size(143, 43);
            documentoTxt.TabIndex = 6;
            documentoTxt.Text = "CPF/CPNJ";
            documentoTxt.TextAlign = ContentAlignment.MiddleCenter;
            documentoTxt.Click += ClienteUserControl_Click;
            // 
            // telefoneTxt
            // 
            telefoneTxt.AutoSize = true;
            telefoneTxt.Dock = DockStyle.Fill;
            telefoneTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            telefoneTxt.Location = new Point(307, 2);
            telefoneTxt.Name = "telefoneTxt";
            telefoneTxt.Size = new Size(143, 43);
            telefoneTxt.TabIndex = 2;
            telefoneTxt.Text = "TELEFONE";
            telefoneTxt.TextAlign = ContentAlignment.MiddleCenter;
            telefoneTxt.Click += ClienteUserControl_Click;
            // 
            // emailTxt
            // 
            emailTxt.AutoSize = true;
            emailTxt.Dock = DockStyle.Fill;
            emailTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            emailTxt.Location = new Point(458, 2);
            emailTxt.Name = "emailTxt";
            emailTxt.Size = new Size(143, 43);
            emailTxt.TabIndex = 3;
            emailTxt.Text = "EMAIL";
            emailTxt.TextAlign = ContentAlignment.MiddleCenter;
            emailTxt.Click += ClienteUserControl_Click;
            // 
            // honorarioTxt
            // 
            honorarioTxt.AutoSize = true;
            honorarioTxt.Dock = DockStyle.Fill;
            honorarioTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            honorarioTxt.Location = new Point(609, 2);
            honorarioTxt.Name = "honorarioTxt";
            honorarioTxt.Size = new Size(143, 43);
            honorarioTxt.TabIndex = 4;
            honorarioTxt.Text = "HONORÁRIO";
            honorarioTxt.TextAlign = ContentAlignment.MiddleCenter;
            honorarioTxt.Click += ClienteUserControl_Click;
            // 
            // vencimentoTxt
            // 
            vencimentoTxt.AutoSize = true;
            vencimentoTxt.Dock = DockStyle.Fill;
            vencimentoTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            vencimentoTxt.Location = new Point(760, 2);
            vencimentoTxt.Name = "vencimentoTxt";
            vencimentoTxt.Size = new Size(147, 43);
            vencimentoTxt.TabIndex = 5;
            vencimentoTxt.Text = "DIA VENCIMENTO";
            vencimentoTxt.TextAlign = ContentAlignment.MiddleCenter;
            vencimentoTxt.Click += ClienteUserControl_Click;
            // 
            // ClienteControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ClienteControl";
            Size = new Size(912, 47);
            Click += ClienteUserControl_Click;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label nomeTxt;
        private Label telefoneTxt;
        private Label emailTxt;
        private Label honorarioTxt;
        private Label vencimentoTxt;
        private Label documentoTxt;
    }
}
