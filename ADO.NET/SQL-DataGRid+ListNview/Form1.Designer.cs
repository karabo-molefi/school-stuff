namespace SQL_DataGRid_ListNview
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnDGV = new System.Windows.Forms.Button();
            this.btnLV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(44, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(480, 351);
            this.dataGridView1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(561, 32);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(211, 351);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnDGV
            // 
            this.btnDGV.Location = new System.Drawing.Point(46, 412);
            this.btnDGV.Name = "btnDGV";
            this.btnDGV.Size = new System.Drawing.Size(197, 22);
            this.btnDGV.TabIndex = 2;
            this.btnDGV.Text = "Show DGV";
            this.btnDGV.UseVisualStyleBackColor = true;
            this.btnDGV.Click += new System.EventHandler(this.btnDGV_Click);
            // 
            // btnLV
            // 
            this.btnLV.Location = new System.Drawing.Point(561, 412);
            this.btnLV.Name = "btnLV";
            this.btnLV.Size = new System.Drawing.Size(211, 22);
            this.btnLV.TabIndex = 3;
            this.btnLV.Text = "Show LV";
            this.btnLV.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLV);
            this.Controls.Add(this.btnDGV);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnDGV;
        private System.Windows.Forms.Button btnLV;
    }
}

