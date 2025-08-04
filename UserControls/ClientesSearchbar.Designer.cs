namespace Conta_Certa.UserControls
{
    partial class ClientesSearch
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
            searchBar = new TextBox();
            clientesList = new Panel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(searchBar, 0, 0);
            tableLayoutPanel1.Controls.Add(clientesList, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(285, 150);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // searchBar
            // 
            searchBar.BorderStyle = BorderStyle.None;
            searchBar.Dock = DockStyle.Fill;
            searchBar.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchBar.Location = new Point(5, 5);
            searchBar.Margin = new Padding(3, 3, 3, 0);
            searchBar.Name = "searchBar";
            searchBar.PlaceholderText = "Pesquisar - Nome - ID - CPF/CNPJ";
            searchBar.Size = new Size(275, 15);
            searchBar.TabIndex = 0;
            searchBar.TextChanged += SearchBar_TextChanged;
            // 
            // clientesList
            // 
            clientesList.Dock = DockStyle.Fill;
            clientesList.Location = new Point(5, 25);
            clientesList.Name = "clientesList";
            clientesList.Size = new Size(275, 120);
            clientesList.TabIndex = 1;
            // 
            // ClientesSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ClientesSearch";
            Size = new Size(285, 150);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox searchBar;
        private Panel clientesList;
    }
}
