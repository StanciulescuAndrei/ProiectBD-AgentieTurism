namespace AgentieTurismBackend.Administrare_Clienti
{
    partial class ManagementRzvForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.Avans = new System.Windows.Forms.NumericUpDown();
            this.Cazare_comboBox = new System.Windows.Forms.ComboBox();
            this.orderLabel = new System.Windows.Forms.Label();
            this.Excursie_comboBox = new System.Windows.Forms.ComboBox();
            this.stergeButton = new System.Windows.Forms.Button();
            this.modificaButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.Avans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "RON";
            // 
            // Avans
            // 
            this.Avans.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Avans.Location = new System.Drawing.Point(12, 325);
            this.Avans.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.Avans.Name = "Avans";
            this.Avans.Size = new System.Drawing.Size(99, 24);
            this.Avans.TabIndex = 49;
            // 
            // Cazare_comboBox
            // 
            this.Cazare_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cazare_comboBox.FormattingEnabled = true;
            this.Cazare_comboBox.Location = new System.Drawing.Point(263, 289);
            this.Cazare_comboBox.Name = "Cazare_comboBox";
            this.Cazare_comboBox.Size = new System.Drawing.Size(266, 26);
            this.Cazare_comboBox.TabIndex = 48;
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderLabel.Location = new System.Drawing.Point(688, 10);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(42, 20);
            this.orderLabel.TabIndex = 47;
            this.orderLabel.Text = "ASC";
            this.orderLabel.Click += new System.EventHandler(this.orderLabel_Click);
            // 
            // Excursie_comboBox
            // 
            this.Excursie_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Excursie_comboBox.FormattingEnabled = true;
            this.Excursie_comboBox.Location = new System.Drawing.Point(12, 289);
            this.Excursie_comboBox.Name = "Excursie_comboBox";
            this.Excursie_comboBox.Size = new System.Drawing.Size(245, 26);
            this.Excursie_comboBox.TabIndex = 44;
            // 
            // stergeButton
            // 
            this.stergeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stergeButton.Location = new System.Drawing.Point(622, 327);
            this.stergeButton.Name = "stergeButton";
            this.stergeButton.Size = new System.Drawing.Size(109, 26);
            this.stergeButton.TabIndex = 42;
            this.stergeButton.Text = "Sterge";
            this.stergeButton.UseVisualStyleBackColor = true;
            this.stergeButton.Click += new System.EventHandler(this.stergeButton_Click);
            // 
            // modificaButton
            // 
            this.modificaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificaButton.Location = new System.Drawing.Point(621, 289);
            this.modificaButton.Name = "modificaButton";
            this.modificaButton.Size = new System.Drawing.Size(109, 26);
            this.modificaButton.TabIndex = 41;
            this.modificaButton.Text = "Modifica";
            this.modificaButton.UseVisualStyleBackColor = true;
            this.modificaButton.Click += new System.EventHandler(this.modificaButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(573, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(109, 26);
            this.searchButton.TabIndex = 39;
            this.searchButton.Text = "Cauta";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(12, 6);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(555, 24);
            this.searchTextBox.TabIndex = 38;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 38);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(719, 245);
            this.dataGridView.TabIndex = 37;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_RowHeaderMouseClick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 357);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 51;
            // 
            // ManagementRzvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 394);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Avans);
            this.Controls.Add(this.Cazare_comboBox);
            this.Controls.Add(this.orderLabel);
            this.Controls.Add(this.Excursie_comboBox);
            this.Controls.Add(this.stergeButton);
            this.Controls.Add(this.modificaButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.dataGridView);
            this.Name = "ManagementRzvForm";
            this.Text = "ManagementRzvForm";
            this.Load += new System.EventHandler(this.ManagementRzvForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Avans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Avans;
        private System.Windows.Forms.ComboBox Cazare_comboBox;
        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.ComboBox Excursie_comboBox;
        private System.Windows.Forms.Button stergeButton;
        private System.Windows.Forms.Button modificaButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}