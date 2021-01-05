namespace AgentieTurismBackend
{
    partial class Form1
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
            this.ConnectToDB = new System.Windows.Forms.Button();
            this.queryResult = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.disposeDB = new System.Windows.Forms.Button();
            this.testQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConnectToDB
            // 
            this.ConnectToDB.Location = new System.Drawing.Point(12, 12);
            this.ConnectToDB.Name = "ConnectToDB";
            this.ConnectToDB.Size = new System.Drawing.Size(150, 60);
            this.ConnectToDB.TabIndex = 0;
            this.ConnectToDB.Text = "Conectare BD";
            this.ConnectToDB.UseVisualStyleBackColor = true;
            this.ConnectToDB.Click += new System.EventHandler(this.ConnectToDB_Click);
            // 
            // queryResult
            // 
            this.queryResult.AcceptsTab = true;
            this.queryResult.Location = new System.Drawing.Point(12, 129);
            this.queryResult.Multiline = true;
            this.queryResult.Name = "queryResult";
            this.queryResult.Size = new System.Drawing.Size(475, 417);
            this.queryResult.TabIndex = 1;
            this.queryResult.WordWrap = false;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(9, 614);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(155, 18);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Status: Not connected";
            // 
            // disposeDB
            // 
            this.disposeDB.Location = new System.Drawing.Point(168, 12);
            this.disposeDB.Name = "disposeDB";
            this.disposeDB.Size = new System.Drawing.Size(150, 60);
            this.disposeDB.TabIndex = 3;
            this.disposeDB.Text = "Deconectare BD";
            this.disposeDB.UseVisualStyleBackColor = true;
            this.disposeDB.Click += new System.EventHandler(this.DisposeDB_Click);
            // 
            // testQuery
            // 
            this.testQuery.Location = new System.Drawing.Point(324, 85);
            this.testQuery.Name = "testQuery";
            this.testQuery.Size = new System.Drawing.Size(88, 29);
            this.testQuery.TabIndex = 4;
            this.testQuery.Text = "Cauta";
            this.testQuery.UseVisualStyleBackColor = true;
            this.testQuery.Click += new System.EventHandler(this.TestQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Oras:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 20);
            this.textBox1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 641);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testQuery);
            this.Controls.Add(this.disposeDB);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.queryResult);
            this.Controls.Add(this.ConnectToDB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectToDB;
        private System.Windows.Forms.TextBox queryResult;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button disposeDB;
        private System.Windows.Forms.Button testQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

