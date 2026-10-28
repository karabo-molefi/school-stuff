namespace SortNumbers
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
            this.btnRead = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.listViewRead = new System.Windows.Forms.ListView();
            this.listViewSort = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(67, 38);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(198, 78);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Read Data";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(310, 38);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(198, 78);
            this.btnSort.TabIndex = 1;
            this.btnSort.Text = "Sort Data";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // listViewRead
            // 
            this.listViewRead.HideSelection = false;
            this.listViewRead.Location = new System.Drawing.Point(67, 152);
            this.listViewRead.Name = "listViewRead";
            this.listViewRead.Size = new System.Drawing.Size(198, 271);
            this.listViewRead.TabIndex = 2;
            this.listViewRead.UseCompatibleStateImageBehavior = false;
            // 
            // listViewSort
            // 
            this.listViewSort.HideSelection = false;
            this.listViewSort.Location = new System.Drawing.Point(310, 152);
            this.listViewSort.Name = "listViewSort";
            this.listViewSort.Size = new System.Drawing.Size(198, 271);
            this.listViewSort.TabIndex = 3;
            this.listViewSort.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 450);
            this.Controls.Add(this.listViewSort);
            this.Controls.Add(this.listViewRead);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnRead);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.ListView listViewRead;
        private System.Windows.Forms.ListView listViewSort;
    }
}

