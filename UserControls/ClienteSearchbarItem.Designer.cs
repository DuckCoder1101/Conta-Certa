namespace Conta_Certa.UserControls
{
    partial class ClienteSearchbarItem
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
            clienteTxt = new Label();
            SuspendLayout();
            // 
            // clienteTxt
            // 
            clienteTxt.Dock = DockStyle.Fill;
            clienteTxt.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clienteTxt.Location = new Point(0, 0);
            clienteTxt.Name = "clienteTxt";
            clienteTxt.Size = new Size(480, 61);
            clienteTxt.TabIndex = 0;
            clienteTxt.Text = "label1";
            clienteTxt.TextAlign = ContentAlignment.MiddleCenter;
            clienteTxt.Click += Cliente_Click;
            // 
            // ClienteSearchbarItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(clienteTxt);
            Name = "ClienteSearchbarItem";
            Size = new Size(480, 61);
            ResumeLayout(false);
        }

        #endregion

        private Label clienteTxt;
    }
}
