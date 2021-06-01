namespace PR_01
{
    partial class Menu
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
            this.btn_openfile = new System.Windows.Forms.Button();
            this.btn_newfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_openfile
            // 
            this.btn_openfile.Location = new System.Drawing.Point(33, 28);
            this.btn_openfile.Name = "btn_openfile";
            this.btn_openfile.Size = new System.Drawing.Size(235, 81);
            this.btn_openfile.TabIndex = 0;
            this.btn_openfile.Text = "Open File";
            this.btn_openfile.UseVisualStyleBackColor = true;
            this.btn_openfile.Click += new System.EventHandler(this.btn_openfile_Click);
            // 
            // btn_newfile
            // 
            this.btn_newfile.Location = new System.Drawing.Point(33, 158);
            this.btn_newfile.Name = "btn_newfile";
            this.btn_newfile.Size = new System.Drawing.Size(235, 81);
            this.btn_newfile.TabIndex = 1;
            this.btn_newfile.Text = "New File";
            this.btn_newfile.UseVisualStyleBackColor = true;
            this.btn_newfile.Click += new System.EventHandler(this.btn_newfile_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 284);
            this.Controls.Add(this.btn_newfile);
            this.Controls.Add(this.btn_openfile);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_openfile;
        private System.Windows.Forms.Button btn_newfile;
    }
}