namespace Conta_Certa.UserControls
{
    partial class CobrancaControl
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
            clienteTxt = new Label();
            honorarioBaseTxt = new Label();
            statusTxt = new Label();
            vencimentoTxt = new Label();
            pagoEmTxt = new Label();
            honorarioTotalTxt = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.Controls.Add(idTxt, 0, 0);
            tableLayoutPanel1.Controls.Add(clienteTxt, 1, 0);
            tableLayoutPanel1.Controls.Add(honorarioBaseTxt, 2, 0);
            tableLayoutPanel1.Controls.Add(statusTxt, 3, 0);
            tableLayoutPanel1.Controls.Add(vencimentoTxt, 4, 0);
            tableLayoutPanel1.Controls.Add(pagoEmTxt, 5, 0);
            tableLayoutPanel1.Controls.Add(honorarioTotalTxt, 6, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(768, 43);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // idTxt
            // 
            idTxt.AutoSize = true;
            idTxt.Dock = DockStyle.Fill;
            idTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            idTxt.Location = new Point(3, 0);
            idTxt.Name = "idTxt";
            idTxt.Size = new Size(103, 43);
            idTxt.TabIndex = 0;
            idTxt.Text = "ID";
            idTxt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clienteTxt
            // 
            clienteTxt.AutoSize = true;
            clienteTxt.Dock = DockStyle.Fill;
            clienteTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            clienteTxt.Location = new Point(112, 0);
            clienteTxt.Name = "clienteTxt";
            clienteTxt.Size = new Size(103, 43);
            clienteTxt.TabIndex = 1;
            clienteTxt.Text = "CLIENTE";
            clienteTxt.TextAlign = ContentAlignment.MiddleCenter;
            clienteTxt.MouseClick += CobrancaControl_MouseClick;
            // 
            // honorarioBaseTxt
            // 
            honorarioBaseTxt.AutoSize = true;
            honorarioBaseTxt.Dock = DockStyle.Fill;
            honorarioBaseTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            honorarioBaseTxt.Location = new Point(221, 0);
            honorarioBaseTxt.Name = "honorarioBaseTxt";
            honorarioBaseTxt.Size = new Size(103, 43);
            honorarioBaseTxt.TabIndex = 2;
            honorarioBaseTxt.Text = "HONORÁRIO (BASE)";
            honorarioBaseTxt.TextAlign = ContentAlignment.MiddleCenter;
            honorarioBaseTxt.MouseClick += CobrancaControl_MouseClick;
            // 
            // statusTxt
            // 
            statusTxt.AutoSize = true;
            statusTxt.Dock = DockStyle.Fill;
            statusTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            statusTxt.Location = new Point(330, 0);
            statusTxt.Name = "statusTxt";
            statusTxt.Size = new Size(103, 43);
            statusTxt.TabIndex = 3;
            statusTxt.Text = "STATUS";
            statusTxt.TextAlign = ContentAlignment.MiddleCenter;
            statusTxt.MouseClick += CobrancaControl_MouseClick;
            // 
            // vencimentoTxt
            // 
            vencimentoTxt.AutoSize = true;
            vencimentoTxt.Dock = DockStyle.Fill;
            vencimentoTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            vencimentoTxt.Location = new Point(439, 0);
            vencimentoTxt.Name = "vencimentoTxt";
            vencimentoTxt.Size = new Size(103, 43);
            vencimentoTxt.TabIndex = 4;
            vencimentoTxt.Text = "VENCIMENTO";
            vencimentoTxt.TextAlign = ContentAlignment.MiddleCenter;
            vencimentoTxt.MouseClick += CobrancaControl_MouseClick;
            // 
            // pagoEmTxt
            // 
            pagoEmTxt.AutoSize = true;
            pagoEmTxt.Dock = DockStyle.Fill;
            pagoEmTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            pagoEmTxt.Location = new Point(548, 0);
            pagoEmTxt.Name = "pagoEmTxt";
            pagoEmTxt.Size = new Size(103, 43);
            pagoEmTxt.TabIndex = 5;
            pagoEmTxt.Text = "PAGO EM";
            pagoEmTxt.TextAlign = ContentAlignment.MiddleCenter;
            pagoEmTxt.MouseClick += CobrancaControl_MouseClick;
            // 
            // honorarioTotalTxt
            // 
            honorarioTotalTxt.AutoSize = true;
            honorarioTotalTxt.Dock = DockStyle.Fill;
            honorarioTotalTxt.Font = new Font("Arial", 10F, FontStyle.Bold);
            honorarioTotalTxt.Location = new Point(657, 0);
            honorarioTotalTxt.Name = "honorarioTotalTxt";
            honorarioTotalTxt.Size = new Size(108, 43);
            honorarioTotalTxt.TabIndex = 6;
            honorarioTotalTxt.Text = "HONORÁRIO (TOTAL)";
            honorarioTotalTxt.TextAlign = ContentAlignment.MiddleCenter;
            honorarioTotalTxt.MouseClick += CobrancaControl_MouseClick;
            // 
            // CobrancaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel1);
            Name = "CobrancaControl";
            Size = new Size(768, 43);
            MouseClick += CobrancaControl_MouseClick;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label idTxt;
        private Label clienteTxt;
        private Label honorarioBaseTxt;
        private Label statusTxt;
        private Label vencimentoTxt;
        private Label pagoEmTxt;
        private Label honorarioTotalTxt;
    }
}
