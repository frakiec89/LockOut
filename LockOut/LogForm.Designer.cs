namespace LockOut
{
    partial class LogForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bt5 = new System.Windows.Forms.Button();
            this.bt10 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 399);
            this.dataGridView1.TabIndex = 0;
            // 
            // bt5
            // 
            this.bt5.Location = new System.Drawing.Point(13, 13);
            this.bt5.Name = "bt5";
            this.bt5.Size = new System.Drawing.Size(80, 23);
            this.bt5.TabIndex = 1;
            this.bt5.Text = "5 m";
            this.bt5.UseVisualStyleBackColor = true;
            this.bt5.Click += new System.EventHandler(this.bt5_Click);
            // 
            // bt10
            // 
            this.bt10.Location = new System.Drawing.Point(99, 13);
            this.bt10.Name = "bt10";
            this.bt10.Size = new System.Drawing.Size(80, 23);
            this.bt10.TabIndex = 2;
            this.bt10.Text = "10 m";
            this.bt10.UseVisualStyleBackColor = true;
            this.bt10.Click += new System.EventHandler(this.bt10_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt10);
            this.Controls.Add(this.bt5);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LogForm";
            this.Text = "LogForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt5;
        private System.Windows.Forms.Button bt10;
    }
}