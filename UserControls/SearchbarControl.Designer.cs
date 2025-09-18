namespace Conta_Certa.UserControls
{
    partial class SearchbarControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchbarControl));
            tableLayoutPanel2 = new TableLayoutPanel();
            searchboxTxt = new TextBox();
            searchBtn = new Button();
            addBtn = new Button();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = SystemColors.Window;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(searchboxTxt, 1, 0);
            tableLayoutPanel2.Controls.Add(searchBtn, 0, 0);
            tableLayoutPanel2.Controls.Add(addBtn, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(400, 28);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // searchboxTxt
            // 
            searchboxTxt.BorderStyle = BorderStyle.None;
            searchboxTxt.Dock = DockStyle.Fill;
            searchboxTxt.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchboxTxt.Location = new Point(42, 4);
            searchboxTxt.Margin = new Padding(0, 3, 0, 0);
            searchboxTxt.Name = "searchboxTxt";
            searchboxTxt.PlaceholderText = "Pesquisar";
            searchboxTxt.Size = new Size(316, 18);
            searchboxTxt.TabIndex = 0;
            searchboxTxt.WordWrap = false;
            searchboxTxt.TextChanged += SearchboxTxt_TextChanged;
            // 
            // searchBtn
            // 
            searchBtn.Cursor = Cursors.Hand;
            searchBtn.Dock = DockStyle.Fill;
            searchBtn.FlatAppearance.BorderColor = SystemColors.Window;
            searchBtn.FlatAppearance.BorderSize = 0;
            searchBtn.FlatStyle = FlatStyle.Flat;
            searchBtn.Image = (Image)resources.GetObject("searchBtn.Image");
            searchBtn.Location = new Point(1, 1);
            searchBtn.Margin = new Padding(0);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(40, 26);
            searchBtn.TabIndex = 1;
            searchBtn.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            addBtn.Cursor = Cursors.Hand;
            addBtn.Dock = DockStyle.Fill;
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Image = (Image)resources.GetObject("addBtn.Image");
            addBtn.Location = new Point(359, 1);
            addBtn.Margin = new Padding(0);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(40, 26);
            addBtn.TabIndex = 3;
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += AddBtn_Click;
            // 
            // SearchbarControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel2);
            Name = "SearchbarControl";
            Size = new Size(400, 28);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private TextBox searchboxTxt;
        private Button searchBtn;
        private Button addBtn;
    }
}
