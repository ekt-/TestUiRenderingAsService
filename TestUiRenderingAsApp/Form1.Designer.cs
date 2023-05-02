
namespace TestUiRenderingAsApp
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.myTestWinFormUserControl1 = new SharedProject.MyTestWinFormUserControl();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(30, 246);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(357, 39);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Ui has been rendered and saved as png in ";
            // 
            // myTestWinFormUserControl1
            // 
            this.myTestWinFormUserControl1.AutoScroll = true;
            this.myTestWinFormUserControl1.Location = new System.Drawing.Point(30, 27);
            this.myTestWinFormUserControl1.Margin = new System.Windows.Forms.Padding(6);
            this.myTestWinFormUserControl1.Name = "myTestWinFormUserControl1";
            this.myTestWinFormUserControl1.Size = new System.Drawing.Size(349, 194);
            this.myTestWinFormUserControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 297);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.myTestWinFormUserControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedProject.MyTestWinFormUserControl myTestWinFormUserControl1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

