namespace Conta_Certa.UserControls
{
    partial class ClientesSearchbar
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
            clientesCB = new ComboBox();
            searchbar = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(clientesCB, 1, 0);
            tableLayoutPanel1.Controls.Add(searchbar, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(332, 34);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // clientesCB
            // 
            clientesCB.DropDownHeight = 105;
            clientesCB.DropDownStyle = ComboBoxStyle.DropDownList;
            clientesCB.DropDownWidth = 285;
            clientesCB.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clientesCB.FormattingEnabled = true;
            clientesCB.IntegralHeight = false;
            clientesCB.Location = new Point(178, 5);
            clientesCB.Name = "clientesCB";
            clientesCB.Size = new Size(149, 24);
            clientesCB.Sorted = true;
            clientesCB.TabIndex = 1;
            clientesCB.SelectedIndexChanged += ClientesCB_SelectedIndexChanged;
            // 
            // searchbar
            // 
            searchbar.BorderStyle = BorderStyle.FixedSingle;
            searchbar.Dock = DockStyle.Fill;
            searchbar.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchbar.Location = new Point(5, 6);
            searchbar.Margin = new Padding(3, 4, 3, 3);
            searchbar.Name = "searchbar";
            searchbar.PlaceholderText = "Pesquisar:";
            searchbar.Size = new Size(165, 22);
            searchbar.TabIndex = 0;
            searchbar.WordWrap = false;
            searchbar.TextChanged += Searchbar_TextChanged;
            // 
            // ClientesSearchbar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ClientesSearchbar";
            Size = new Size(332, 34);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox clientesCB;
        private TextBox searchbar;
    }
}
