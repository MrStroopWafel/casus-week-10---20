namespace Machi_Koro
{
    partial class TafelScherm
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
            this.lb_Onder = new System.Windows.Forms.Label();
            this.lb_Links = new System.Windows.Forms.Label();
            this.lb_Boven = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Onder
            // 
            this.lb_Onder.AutoSize = true;
            this.lb_Onder.Location = new System.Drawing.Point(877, 899);
            this.lb_Onder.Name = "lb_Onder";
            this.lb_Onder.Size = new System.Drawing.Size(35, 13);
            this.lb_Onder.TabIndex = 0;
            this.lb_Onder.Text = "label1";
            // 
            // lb_Links
            // 
            this.lb_Links.AutoSize = true;
            this.lb_Links.Location = new System.Drawing.Point(12, 403);
            this.lb_Links.Name = "lb_Links";
            this.lb_Links.Size = new System.Drawing.Size(35, 13);
            this.lb_Links.TabIndex = 1;
            this.lb_Links.Text = "label1";
            // 
            // lb_Boven
            // 
            this.lb_Boven.AutoSize = true;
            this.lb_Boven.Location = new System.Drawing.Point(877, 9);
            this.lb_Boven.Name = "lb_Boven";
            this.lb_Boven.Size = new System.Drawing.Size(35, 13);
            this.lb_Boven.TabIndex = 2;
            this.lb_Boven.Text = "label1";
            // 
            // TafelScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1783, 939);
            this.Controls.Add(this.lb_Boven);
            this.Controls.Add(this.lb_Links);
            this.Controls.Add(this.lb_Onder);
            this.Name = "TafelScherm";
            this.Text = "Tafel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Onder;
        private System.Windows.Forms.Label lb_Links;
        private System.Windows.Forms.Label lb_Boven;
    }
}