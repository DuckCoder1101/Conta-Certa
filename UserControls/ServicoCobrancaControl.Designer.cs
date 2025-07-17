namespace Conta_Certa.UserControls
{
    partial class ServicoCobrancaControl
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
            nomeServicoTxt = new Label();
            quantidadeServicoNb = new NumericUpDown();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)quantidadeServicoNb).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(nomeServicoTxt, 0, 0);
            tableLayoutPanel1.Controls.Add(quantidadeServicoNb, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(200, 23);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // nomeServicoTxt
            // 
            nomeServicoTxt.AutoSize = true;
            nomeServicoTxt.Dock = DockStyle.Fill;
            nomeServicoTxt.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nomeServicoTxt.Location = new Point(3, 0);
            nomeServicoTxt.Name = "nomeServicoTxt";
            nomeServicoTxt.Size = new Size(134, 23);
            nomeServicoTxt.TabIndex = 0;
            nomeServicoTxt.Text = "label1";
            nomeServicoTxt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // quantidadeServicoNb
            // 
            quantidadeServicoNb.Dock = DockStyle.Fill;
            quantidadeServicoNb.Location = new Point(140, 0);
            quantidadeServicoNb.Margin = new Padding(0);
            quantidadeServicoNb.Name = "quantidadeServicoNb";
            quantidadeServicoNb.Size = new Size(60, 23);
            quantidadeServicoNb.TabIndex = 1;
            quantidadeServicoNb.ValueChanged += QuantidadeServicoNb_ValueChanged;
            // 
            // ServicoCobrancaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(0);
            Name = "ServicoCobrancaControl";
            Size = new Size(200, 23);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)quantidadeServicoNb).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label nomeServicoTxt;
        private NumericUpDown quantidadeServicoNb;
    }
}
