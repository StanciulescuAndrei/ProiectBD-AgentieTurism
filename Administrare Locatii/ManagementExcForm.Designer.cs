namespace AgentieTurismBackend.Administrare_Locatii
{
    partial class ManagementExcForm
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
            this.orderLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Durata = new System.Windows.Forms.NumericUpDown();
            this.Categorie_comboBox = new System.Windows.Forms.ComboBox();
            this.Denumire = new System.Windows.Forms.TextBox();
            this.stergeButton = new System.Windows.Forms.Button();
            this.modificaButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Destinatie_comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Pret = new System.Windows.Forms.NumericUpDown();
            this.Transport = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Participanti = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Durata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pret)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Participanti)).BeginInit();
            this.SuspendLayout();
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderLabel.Location = new System.Drawing.Point(688, 11);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(42, 20);
            this.orderLabel.TabIndex = 29;
            this.orderLabel.Text = "ASC";
            this.orderLabel.Click += new System.EventHandler(this.orderLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Zile";
            // 
            // Durata
            // 
            this.Durata.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Durata.Location = new System.Drawing.Point(12, 318);
            this.Durata.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.Durata.Name = "Durata";
            this.Durata.Size = new System.Drawing.Size(99, 24);
            this.Durata.TabIndex = 27;
            // 
            // Categorie_comboBox
            // 
            this.Categorie_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Categorie_comboBox.FormattingEnabled = true;
            this.Categorie_comboBox.Location = new System.Drawing.Point(12, 290);
            this.Categorie_comboBox.Name = "Categorie_comboBox";
            this.Categorie_comboBox.Size = new System.Drawing.Size(160, 26);
            this.Categorie_comboBox.TabIndex = 26;
            // 
            // Denumire
            // 
            this.Denumire.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Denumire.Location = new System.Drawing.Point(344, 290);
            this.Denumire.Name = "Denumire";
            this.Denumire.Size = new System.Drawing.Size(260, 24);
            this.Denumire.TabIndex = 25;
            // 
            // stergeButton
            // 
            this.stergeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stergeButton.Location = new System.Drawing.Point(622, 356);
            this.stergeButton.Name = "stergeButton";
            this.stergeButton.Size = new System.Drawing.Size(109, 26);
            this.stergeButton.TabIndex = 24;
            this.stergeButton.Text = "Sterge";
            this.stergeButton.UseVisualStyleBackColor = true;
            this.stergeButton.Click += new System.EventHandler(this.stergeButton_Click);
            // 
            // modificaButton
            // 
            this.modificaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificaButton.Location = new System.Drawing.Point(622, 324);
            this.modificaButton.Name = "modificaButton";
            this.modificaButton.Size = new System.Drawing.Size(109, 26);
            this.modificaButton.TabIndex = 23;
            this.modificaButton.Text = "Modifica";
            this.modificaButton.UseVisualStyleBackColor = true;
            this.modificaButton.Click += new System.EventHandler(this.modificaButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(622, 292);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(109, 26);
            this.addButton.TabIndex = 22;
            this.addButton.Text = "Adauga";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(573, 5);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(109, 26);
            this.searchButton.TabIndex = 21;
            this.searchButton.Text = "Cauta";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(12, 7);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(555, 24);
            this.searchTextBox.TabIndex = 20;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 39);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(719, 245);
            this.dataGridView.TabIndex = 19;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_RowHeaderMouseClick);
            // 
            // Destinatie_comboBox
            // 
            this.Destinatie_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Destinatie_comboBox.FormattingEnabled = true;
            this.Destinatie_comboBox.Location = new System.Drawing.Point(178, 290);
            this.Destinatie_comboBox.Name = "Destinatie_comboBox";
            this.Destinatie_comboBox.Size = new System.Drawing.Size(160, 26);
            this.Destinatie_comboBox.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "RON";
            // 
            // Pret
            // 
            this.Pret.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pret.Location = new System.Drawing.Point(12, 347);
            this.Pret.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.Pret.Name = "Pret";
            this.Pret.Size = new System.Drawing.Size(99, 24);
            this.Pret.TabIndex = 31;
            // 
            // Transport
            // 
            this.Transport.AutoSize = true;
            this.Transport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transport.Location = new System.Drawing.Point(178, 348);
            this.Transport.Name = "Transport";
            this.Transport.Size = new System.Drawing.Size(96, 24);
            this.Transport.TabIndex = 34;
            this.Transport.Text = "Transport";
            this.Transport.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(283, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Numar maxim de participanti";
            // 
            // Participanti
            // 
            this.Participanti.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Participanti.Location = new System.Drawing.Point(178, 318);
            this.Participanti.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.Participanti.Name = "Participanti";
            this.Participanti.Size = new System.Drawing.Size(99, 24);
            this.Participanti.TabIndex = 35;
            // 
            // ManagementExcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 394);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Participanti);
            this.Controls.Add(this.Transport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Pret);
            this.Controls.Add(this.Destinatie_comboBox);
            this.Controls.Add(this.orderLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Durata);
            this.Controls.Add(this.Categorie_comboBox);
            this.Controls.Add(this.Denumire);
            this.Controls.Add(this.stergeButton);
            this.Controls.Add(this.modificaButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.dataGridView);
            this.Name = "ManagementExcForm";
            this.Text = "ManagementExcForm";
            this.Load += new System.EventHandler(this.ManagementExcForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Durata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pret)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Participanti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Durata;
        private System.Windows.Forms.ComboBox Categorie_comboBox;
        private System.Windows.Forms.TextBox Denumire;
        private System.Windows.Forms.Button stergeButton;
        private System.Windows.Forms.Button modificaButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox Destinatie_comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Pret;
        private System.Windows.Forms.CheckBox Transport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Participanti;
    }
}