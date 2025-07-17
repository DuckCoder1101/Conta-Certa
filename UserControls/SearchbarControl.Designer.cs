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
            orderboxPanel = new TableLayoutPanel();
            orderCB = new ComboBox();
            pictureBox1 = new PictureBox();
            addBtn = new Button();
            tableLayoutPanel2.SuspendLayout();
            orderboxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = SystemColors.Window;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.Controls.Add(searchboxTxt, 1, 0);
            tableLayoutPanel2.Controls.Add(searchBtn, 0, 0);
            tableLayoutPanel2.Controls.Add(orderboxPanel, 2, 0);
            tableLayoutPanel2.Controls.Add(addBtn, 3, 0);
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
            searchboxTxt.BorderStyle = BorderStyle.FixedSingle;
            searchboxTxt.Dock = DockStyle.Fill;
            searchboxTxt.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchboxTxt.Location = new Point(43, 3);
            searchboxTxt.Name = "searchboxTxt";
            searchboxTxt.PlaceholderText = "Pesquisar por nome";
            searchboxTxt.Size = new Size(194, 22);
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
            searchBtn.Location = new Point(3, 3);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(34, 22);
            searchBtn.TabIndex = 1;
            searchBtn.UseVisualStyleBackColor = true;
            // 
            // orderboxPanel
            // 
            orderboxPanel.ColumnCount = 2;
            orderboxPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28F));
            orderboxPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            orderboxPanel.Controls.Add(orderCB, 1, 0);
            orderboxPanel.Controls.Add(pictureBox1, 0, 0);
            orderboxPanel.Dock = DockStyle.Fill;
            orderboxPanel.Location = new Point(240, 0);
            orderboxPanel.Margin = new Padding(0);
            orderboxPanel.Name = "orderboxPanel";
            orderboxPanel.RowCount = 1;
            orderboxPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            orderboxPanel.Size = new Size(120, 28);
            orderboxPanel.TabIndex = 2;
            // 
            // orderCB
            // 
            orderCB.Dock = DockStyle.Fill;
            orderCB.DropDownStyle = ComboBoxStyle.DropDownList;
            orderCB.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            orderCB.FormattingEnabled = true;
            orderCB.Items.AddRange(new object[] { "ID", "Nome", "Honorário", "Vencimento" });
            orderCB.Location = new Point(31, 3);
            orderCB.MaxDropDownItems = 4;
            orderCB.Name = "orderCB";
            orderCB.Size = new Size(86, 24);
            orderCB.TabIndex = 2;
            orderCB.SelectedIndexChanged += OrderCB_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(28, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // addBtn
            // 
            addBtn.Cursor = Cursors.Hand;
            addBtn.Dock = DockStyle.Fill;
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Image = (Image)resources.GetObject("addBtn.Image");
            addBtn.Location = new Point(360, 0);
            addBtn.Margin = new Padding(0);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(40, 28);
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
            orderboxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private TextBox searchboxTxt;
        private Button searchBtn;
        private TableLayoutPanel orderboxPanel;
        private ComboBox orderCB;
        private PictureBox pictureBox1;
        private Button addBtn;
    }
}
