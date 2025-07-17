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
            idTxt = new Label();
            nomeTxt = new Label();
            telefoneTxt = new Label();
            emailTxt = new Label();
            honorarioTxt = new Label();
            vencimentoTxt = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Controls.Add(idTxt, 0, 0);
            tableLayoutPanel1.Controls.Add(nomeTxt, 1, 0);
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
            tableLayoutPanel1.Size = new Size(770, 45);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Click += ClienteUserControl_Click;
            // 
            // idTxt
            // 
            idTxt.AutoSize = true;
            idTxt.Dock = DockStyle.Fill;
            idTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            idTxt.Location = new Point(3, 0);
            idTxt.Name = "idTxt";
            idTxt.Size = new Size(122, 45);
            idTxt.TabIndex = 0;
            idTxt.Text = "ID";
            idTxt.TextAlign = ContentAlignment.MiddleCenter;
            idTxt.Click += ClienteUserControl_Click;
            // 
            // clienteTxt
            // 
            nomeTxt.AutoSize = true;
            nomeTxt.Dock = DockStyle.Fill;
            nomeTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            nomeTxt.Location = new Point(131, 0);
            nomeTxt.Name = "nomeTxt";
            nomeTxt.Size = new Size(122, 45);
            nomeTxt.TabIndex = 1;
            nomeTxt.Text = "NOME";
            nomeTxt.TextAlign = ContentAlignment.MiddleCenter;
            nomeTxt.Click += ClienteUserControl_Click;
            // 
            // telefoneTxt
            // 
            telefoneTxt.AutoSize = true;
            telefoneTxt.Dock = DockStyle.Fill;
            telefoneTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            telefoneTxt.Location = new Point(259, 0);
            telefoneTxt.Name = "telefoneTxt";
            telefoneTxt.Size = new Size(122, 45);
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
            emailTxt.Location = new Point(387, 0);
            emailTxt.Name = "emailTxt";
            emailTxt.Size = new Size(122, 45);
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
            honorarioTxt.Location = new Point(515, 0);
            honorarioTxt.Name = "honorarioTxt";
            honorarioTxt.Size = new Size(122, 45);
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
            vencimentoTxt.Location = new Point(643, 0);
            vencimentoTxt.Name = "vencimentoTxt";
            vencimentoTxt.Size = new Size(124, 45);
            vencimentoTxt.TabIndex = 5;
            vencimentoTxt.Text = "DIA VENCIMENTO";
            vencimentoTxt.TextAlign = ContentAlignment.MiddleCenter;
            vencimentoTxt.Click += ClienteUserControl_Click;
            // 
            // ClienteControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel1);
            Name = "ClienteControl";
            Size = new Size(770, 45);
            Click += ClienteUserControl_Click;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label idTxt;
        private Label nomeTxt;
        private Label telefoneTxt;
        private Label emailTxt;
        private Label honorarioTxt;
        private Label vencimentoTxt;
    }
}
