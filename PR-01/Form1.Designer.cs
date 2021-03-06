using System;

namespace PR_01
{
    partial class Notepad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notepad));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_save = new System.Windows.Forms.Button();
            this.rtxt_codigo = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lb_numbers = new System.Windows.Forms.Label();
            this.print = new System.Windows.Forms.Label();
            this.btn_run = new System.Windows.Forms.Button();
            this.txt_simbolos = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_save.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(813, 475);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click_1);
            // 
            // rtxt_codigo
            // 
            this.rtxt_codigo.AcceptsTab = true;
            this.rtxt_codigo.BackColor = System.Drawing.SystemColors.InfoText;
            this.rtxt_codigo.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtxt_codigo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_codigo.ForeColor = System.Drawing.Color.Wheat;
            this.rtxt_codigo.Location = new System.Drawing.Point(3, 0);
            this.rtxt_codigo.Name = "rtxt_codigo";
            this.rtxt_codigo.Size = new System.Drawing.Size(533, 457);
            this.rtxt_codigo.TabIndex = 9;
            this.rtxt_codigo.Text = "";
            this.rtxt_codigo.VScroll += new System.EventHandler(this.rtxt_codigo_VScroll);
            this.rtxt_codigo.FontChanged += new System.EventHandler(this.rtxt_codigo_FontChanged);
            this.rtxt_codigo.TextChanged += new System.EventHandler(this.rtxt_codigo_TextChanged);
            this.rtxt_codigo.Resize += new System.EventHandler(this.rtxt_codigo_Resize);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainer1.Panel1.Controls.Add(this.lb_numbers);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.DeepPink;
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtxt_codigo);
            this.splitContainer1.Size = new System.Drawing.Size(579, 460);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 10;
            // 
            // lb_numbers
            // 
            this.lb_numbers.AutoSize = true;
            this.lb_numbers.Location = new System.Drawing.Point(-3, 3);
            this.lb_numbers.Name = "lb_numbers";
            this.lb_numbers.Size = new System.Drawing.Size(35, 13);
            this.lb_numbers.TabIndex = 0;
            this.lb_numbers.Text = "label1";
            // 
            // print
            // 
            this.print.AutoSize = true;
            this.print.Location = new System.Drawing.Point(60, 475);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(40, 13);
            this.print.TabIndex = 11;
            this.print.Text = "PRINT";
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // btn_run
            // 
            this.btn_run.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_run.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_run.Location = new System.Drawing.Point(732, 475);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 23);
            this.btn_run.TabIndex = 12;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = false;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // txt_simbolos
            // 
            this.txt_simbolos.BackColor = System.Drawing.SystemColors.InfoText;
            this.txt_simbolos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_simbolos.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.txt_simbolos.Location = new System.Drawing.Point(594, 12);
            this.txt_simbolos.Multiline = true;
            this.txt_simbolos.Name = "txt_simbolos";
            this.txt_simbolos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_simbolos.Size = new System.Drawing.Size(294, 460);
            this.txt_simbolos.TabIndex = 13;
            // 
            // Notepad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(900, 502);
            this.Controls.Add(this.txt_simbolos);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.print);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btn_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Notepad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notepad";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

       

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.RichTextBox rtxt_codigo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lb_numbers;
        private System.Windows.Forms.Label print;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.TextBox txt_simbolos;
    }
}

