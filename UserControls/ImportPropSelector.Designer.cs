namespace Conta_Certa.UserControls
{
    partial class ImportPropSelector
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportPropSelector));
            panel = new TableLayoutPanel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            importPropCheckbox = new CheckBox();
            indexNb = new NumericUpDown();
            tableLayoutPanel1 = new TableLayoutPanel();
            propNameTxt = new Label();
            toolTipBtn = new PictureBox();
            toolTip = new ToolTip(components);
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)indexNb).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)toolTipBtn).BeginInit();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BackColor = Color.DarkGray;
            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            panel.ColumnCount = 3;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panel.ColumnStyles.Add(new ColumnStyle());
            panel.ColumnStyles.Add(new ColumnStyle());
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            panel.Controls.Add(label3, 2, 0);
            panel.Controls.Add(label2, 1, 0);
            panel.Controls.Add(label1, 0, 0);
            panel.Controls.Add(importPropCheckbox, 2, 1);
            panel.Controls.Add(indexNb, 1, 1);
            panel.Controls.Add(tableLayoutPanel1, 0, 1);
            panel.Cursor = Cursors.Hand;
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(3, 3);
            panel.Margin = new Padding(0);
            panel.Name = "panel";
            panel.RowCount = 2;
            panel.RowStyles.Add(new RowStyle());
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panel.Size = new Size(564, 58);
            panel.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(501, 5);
            label3.Margin = new Padding(0, 3, 0, 3);
            label3.Name = "label3";
            label3.Size = new Size(61, 16);
            label3.TabIndex = 5;
            label3.Text = "Importar?";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(393, 5);
            label2.Margin = new Padding(0, 3, 0, 3);
            label2.Name = "label2";
            label2.Size = new Size(106, 16);
            label2.TabIndex = 4;
            label2.Text = "N.º Coluna";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 5);
            label1.Margin = new Padding(6, 3, 0, 3);
            label1.Name = "label1";
            label1.Size = new Size(383, 16);
            label1.TabIndex = 3;
            label1.Text = "Propriedade";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // importPropCheckbox
            // 
            importPropCheckbox.AutoSize = true;
            importPropCheckbox.CheckAlign = ContentAlignment.MiddleCenter;
            importPropCheckbox.Dock = DockStyle.Fill;
            importPropCheckbox.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            importPropCheckbox.Location = new Point(504, 29);
            importPropCheckbox.Name = "importPropCheckbox";
            importPropCheckbox.Size = new Size(55, 24);
            importPropCheckbox.TabIndex = 1;
            importPropCheckbox.UseVisualStyleBackColor = true;
            importPropCheckbox.CheckedChanged += ImportPropCheckbox_CheckedChanged;
            // 
            // indexNb
            // 
            indexNb.BorderStyle = BorderStyle.FixedSingle;
            indexNb.Enabled = false;
            indexNb.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            indexNb.Location = new Point(396, 29);
            indexNb.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            indexNb.Name = "indexNb";
            indexNb.Size = new Size(100, 22);
            indexNb.TabIndex = 2;
            indexNb.Value = new decimal(new int[] { 1, 0, 0, 0 });
            indexNb.ValueChanged += IndexNb_ValueChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(propNameTxt, 1, 0);
            tableLayoutPanel1.Controls.Add(toolTipBtn, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(2, 26);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(389, 30);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // propNameTxt
            // 
            propNameTxt.AutoSize = true;
            propNameTxt.Dock = DockStyle.Fill;
            propNameTxt.FlatStyle = FlatStyle.Flat;
            propNameTxt.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            propNameTxt.Location = new Point(32, 6);
            propNameTxt.Margin = new Padding(2, 6, 6, 6);
            propNameTxt.Name = "propNameTxt";
            propNameTxt.Size = new Size(351, 18);
            propNameTxt.TabIndex = 1;
            propNameTxt.Text = "label1";
            propNameTxt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolTipBtn
            // 
            toolTipBtn.BackColor = Color.Transparent;
            toolTipBtn.Image = (Image)resources.GetObject("toolTipBtn.Image");
            toolTipBtn.Location = new Point(2, 2);
            toolTipBtn.Margin = new Padding(2);
            toolTipBtn.Name = "toolTipBtn";
            toolTipBtn.Size = new Size(26, 26);
            toolTipBtn.SizeMode = PictureBoxSizeMode.CenterImage;
            toolTipBtn.TabIndex = 2;
            toolTipBtn.TabStop = false;
            // 
            // toolTip
            // 
            toolTip.AutomaticDelay = 200;
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            toolTip.ToolTipTitle = "Ajuda";
            toolTip.UseAnimation = false;
            toolTip.UseFading = false;
            // 
            // ImportPropSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panel);
            Margin = new Padding(0);
            Name = "ImportPropSelector";
            Padding = new Padding(3);
            Size = new Size(570, 64);
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)indexNb).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)toolTipBtn).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel panel;
        private CheckBox importPropCheckbox;
        private NumericUpDown indexNb;
        private Label label3;
        private Label label2;
        private Label label1;
        private ToolTip toolTip;
        private TableLayoutPanel tableLayoutPanel1;
        private Label propNameTxt;
        private PictureBox toolTipBtn;
    }
}
