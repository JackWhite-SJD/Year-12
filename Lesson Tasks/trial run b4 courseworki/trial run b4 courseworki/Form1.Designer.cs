namespace trial_run_b4_courseworki
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
            this.redScrollBar = new System.Windows.Forms.HScrollBar();
            this.greenscrollbar = new System.Windows.Forms.HScrollBar();
            this.blue = new System.Windows.Forms.HScrollBar();
            this.l1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // redScrollBar
            // 
            this.redScrollBar.Location = new System.Drawing.Point(187, 80);
            this.redScrollBar.Name = "redScrollBar";
            this.redScrollBar.Size = new System.Drawing.Size(105, 44);
            this.redScrollBar.TabIndex = 0;
            this.redScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // greenscrollbar
            // 
            this.greenscrollbar.Location = new System.Drawing.Point(187, 149);
            this.greenscrollbar.Name = "greenscrollbar";
            this.greenscrollbar.Size = new System.Drawing.Size(105, 52);
            this.greenscrollbar.TabIndex = 1;
            this.greenscrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.green_Scroll);
            // 
            // blue
            // 
            this.blue.Location = new System.Drawing.Point(187, 227);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(105, 46);
            this.blue.TabIndex = 2;
            this.blue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.blue_Scroll);
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Location = new System.Drawing.Point(86, 94);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(22, 13);
            this.l1.TabIndex = 3;
            this.l1.Text = "red";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "green";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "blue";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.blue);
            this.Controls.Add(this.greenscrollbar);
            this.Controls.Add(this.redScrollBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar redScrollBar;
        private System.Windows.Forms.HScrollBar greenscrollbar;
        private System.Windows.Forms.HScrollBar blue;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

