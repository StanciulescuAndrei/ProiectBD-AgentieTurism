namespace AgentieTurismBackend.Administrare_Clienti
{
    partial class ManagementClientiForm
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
            this.Nume = new System.Windows.Forms.TextBox();
            this.stergeButton = new System.Windows.Forms.Button();
            this.modificaButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Prenume = new System.Windows.Forms.TextBox();
            this.CNP = new System.Windows.Forms.TextBox();
            this.Telefon = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderLabel.Location = new System.Drawing.Point(815, 12);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(42, 20);
            this.orderLabel.TabIndex = 47;
            this.orderLabel.Text = "ASC";
            this.orderLabel.Click += new System.EventHandler(this.orderLabel_Click);
            // 
            // Nume
            // 
            this.Nume.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nume.Location = new System.Drawing.Point(137, 299);
            this.Nume.Name = "Nume";
            this.Nume.Size = new System.Drawing.Size(260, 24);
            this.Nume.TabIndex = 43;
            // 
            // stergeButton
            // 
            this.stergeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stergeButton.Location = new System.Drawing.Point(748, 357);
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
            this.modificaButton.Location = new System.Drawing.Point(748, 325);
            this.modificaButton.Name = "modificaButton";
            this.modificaButton.Size = new System.Drawing.Size(109, 26);
            this.modificaButton.TabIndex = 41;
            this.modificaButton.Text = "Modifica";
            this.modificaButton.UseVisualStyleBackColor = true;
            this.modificaButton.Click += new System.EventHandler(this.modificaButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(748, 293);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(109, 26);
            this.addButton.TabIndex = 40;
            this.addButton.Text = "Adauga";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(700, 6);
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
            this.searchTextBox.Location = new System.Drawing.Point(12, 10);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(682, 24);
            this.searchTextBox.TabIndex = 38;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 42);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(845, 245);
            this.dataGridView.TabIndex = 37;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_RowHeaderMouseClick);
            // 
            // Prenume
            // 
            this.Prenume.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prenume.Location = new System.Drawing.Point(137, 327);
            this.Prenume.Name = "Prenume";
            this.Prenume.Size = new System.Drawing.Size(260, 24);
            this.Prenume.TabIndex = 48;
            // 
            // CNP
            // 
            this.CNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CNP.Location = new System.Drawing.Point(137, 355);
            this.CNP.Name = "CNP";
            this.CNP.Size = new System.Drawing.Size(260, 24);
            this.CNP.TabIndex = 49;
            // 
            // Telefon
            // 
            this.Telefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Telefon.Location = new System.Drawing.Point(137, 407);
            this.Telefon.Name = "Telefon";
            this.Telefon.Size = new System.Drawing.Size(260, 24);
            this.Telefon.TabIndex = 50;
            // 
            // Email
            // 
            this.Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.Location = new System.Drawing.Point(137, 435);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(260, 24);
            this.Email.TabIndex = 51;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(137, 383);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(260, 20);
            this.dateTimePicker1.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 54;
            this.label2.Text = "Prenume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = "CNP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 56;
            this.label4.Text = "Data nasterii";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 57;
            this.label5.Text = "Telefon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 436);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 58;
            this.label6.Text = "E-Mail";
            // 
            // ManagementClientiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 469);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Telefon);
            this.Controls.Add(this.CNP);
            this.Controls.Add(this.Prenume);
            this.Controls.Add(this.orderLabel);
            this.Controls.Add(this.Nume);
            this.Controls.Add(this.stergeButton);
            this.Controls.Add(this.modificaButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.dataGridView);
            this.Name = "ManagementClientiForm";
            this.Text = "ManagementClientiForm";
            this.Load += new System.EventHandler(this.ManagementClientiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.TextBox Nume;
        private System.Windows.Forms.Button stergeButton;
        private System.Windows.Forms.Button modificaButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox Prenume;
        private System.Windows.Forms.TextBox CNP;
        private System.Windows.Forms.TextBox Telefon;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}