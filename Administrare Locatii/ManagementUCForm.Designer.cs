namespace AgentieTurismBackend.Administrare_Locatii
{
    partial class ManagementUCForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Cazare = new System.Windows.Forms.TextBox();
            this.stergeButton = new System.Windows.Forms.Button();
            this.modificaButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Destinatie_comboBox = new System.Windows.Forms.ComboBox();
            this.Pret = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.orderLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pret)).BeginInit();
            this.SuspendLayout();
            // 
            // Cazare
            // 
            this.Cazare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cazare.Location = new System.Drawing.Point(178, 290);
            this.Cazare.Name = "Cazare";
            this.Cazare.Size = new System.Drawing.Size(264, 24);
            this.Cazare.TabIndex = 14;
            this.Cazare.TextChanged += new System.EventHandler(this.Cazare_TextChanged);
            // 
            // stergeButton
            // 
            this.stergeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stergeButton.Location = new System.Drawing.Point(448, 354);
            this.stergeButton.Name = "stergeButton";
            this.stergeButton.Size = new System.Drawing.Size(109, 26);
            this.stergeButton.TabIndex = 13;
            this.stergeButton.Text = "Sterge";
            this.stergeButton.UseVisualStyleBackColor = true;
            this.stergeButton.Click += new System.EventHandler(this.stergeButton_Click);
            // 
            // modificaButton
            // 
            this.modificaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificaButton.Location = new System.Drawing.Point(448, 322);
            this.modificaButton.Name = "modificaButton";
            this.modificaButton.Size = new System.Drawing.Size(109, 26);
            this.modificaButton.TabIndex = 12;
            this.modificaButton.Text = "Modifica";
            this.modificaButton.UseVisualStyleBackColor = true;
            this.modificaButton.Click += new System.EventHandler(this.modificaButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(448, 290);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(109, 26);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Adauga";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(376, 5);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(109, 26);
            this.searchButton.TabIndex = 10;
            this.searchButton.Text = "Cauta";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(12, 7);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(358, 24);
            this.searchTextBox.TabIndex = 9;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 39);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(545, 245);
            this.dataGridView.TabIndex = 8;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_RowHeaderMouseClick);
            // 
            // Destinatie_comboBox
            // 
            this.Destinatie_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Destinatie_comboBox.FormattingEnabled = true;
            this.Destinatie_comboBox.Location = new System.Drawing.Point(12, 290);
            this.Destinatie_comboBox.Name = "Destinatie_comboBox";
            this.Destinatie_comboBox.Size = new System.Drawing.Size(160, 26);
            this.Destinatie_comboBox.TabIndex = 15;
            this.Destinatie_comboBox.SelectedIndexChanged += new System.EventHandler(this.Destinatie_comboBox_SelectedIndexChanged);
            // 
            // Pret
            // 
            this.Pret.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pret.Location = new System.Drawing.Point(12, 317);
            this.Pret.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.Pret.Name = "Pret";
            this.Pret.Size = new System.Drawing.Size(99, 24);
            this.Pret.TabIndex = 16;
            this.Pret.ValueChanged += new System.EventHandler(this.Pret_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "RON";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderLabel.Location = new System.Drawing.Point(491, 8);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(42, 20);
            this.orderLabel.TabIndex = 18;
            this.orderLabel.Text = "ASC";
            this.orderLabel.Click += new System.EventHandler(this.orderLabel_Click);
            // 
            // ManagementUCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 389);
            this.Controls.Add(this.orderLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pret);
            this.Controls.Add(this.Destinatie_comboBox);
            this.Controls.Add(this.Cazare);
            this.Controls.Add(this.stergeButton);
            this.Controls.Add(this.modificaButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.dataGridView);
            this.Name = "ManagementUCForm";
            this.Text = "ManagementUCForm";
            this.Load += new System.EventHandler(this.ManagementUCForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pret)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Cazare;
        private System.Windows.Forms.Button stergeButton;
        private System.Windows.Forms.Button modificaButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox Destinatie_comboBox;
        private System.Windows.Forms.NumericUpDown Pret;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label orderLabel;
    }
}