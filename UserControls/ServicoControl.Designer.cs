namespace Conta_Certa.UserControls
{
    partial class ServicoControl
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
            valorTxt = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Controls.Add(idTxt, 0, 0);
            tableLayoutPanel1.Controls.Add(nomeTxt, 1, 0);
            tableLayoutPanel1.Controls.Add(valorTxt, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(770, 45);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // idTxt
            // 
            idTxt.AutoSize = true;
            idTxt.Dock = DockStyle.Fill;
            idTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            idTxt.Location = new Point(3, 0);
            idTxt.Name = "idTxt";
            idTxt.Size = new Size(250, 45);
            idTxt.TabIndex = 0;
            idTxt.Text = "ID";
            idTxt.TextAlign = ContentAlignment.MiddleCenter;
            idTxt.MouseClick += ServicoControl_MouseClick;
            // 
            // nomeTxt
            // 
            nomeTxt.AutoSize = true;
            nomeTxt.Dock = DockStyle.Fill;
            nomeTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            nomeTxt.Location = new Point(259, 0);
            nomeTxt.Name = "nomeTxt";
            nomeTxt.Size = new Size(250, 45);
            nomeTxt.TabIndex = 1;
            nomeTxt.Text = "NOME";
            nomeTxt.TextAlign = ContentAlignment.MiddleCenter;
            nomeTxt.MouseClick += ServicoControl_MouseClick;
            // 
            // valorTxt
            // 
            valorTxt.AutoSize = true;
            valorTxt.Dock = DockStyle.Fill;
            valorTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            valorTxt.Location = new Point(515, 0);
            valorTxt.Name = "valorTxt";
            valorTxt.Size = new Size(252, 45);
            valorTxt.TabIndex = 2;
            valorTxt.Text = "VALOR";
            valorTxt.TextAlign = ContentAlignment.MiddleCenter;
            valorTxt.MouseClick += ServicoControl_MouseClick;
            // 
            // ServicoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ServicoControl";
            Size = new Size(770, 45);
            MouseClick += ServicoControl_MouseClick;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label idTxt;
        private Label nomeTxt;
        private Label valorTxt;
    }
}
