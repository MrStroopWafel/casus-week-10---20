namespace Machi_Koro
{
    partial class InitScherm
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
            this.cmb_SpelerAantal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Begin = new System.Windows.Forms.Button();
            this.cmb_AiAantal = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmb_SpelerAantal
            // 
            this.cmb_SpelerAantal.AllowDrop = true;
            this.cmb_SpelerAantal.FormattingEnabled = true;
            this.cmb_SpelerAantal.Items.AddRange(new object[] {
            "1 speler",
            "2 spelers",
            "3 spelers",
            "4 spelers"});
            this.cmb_SpelerAantal.Location = new System.Drawing.Point(326, 100);
            this.cmb_SpelerAantal.Name = "cmb_SpelerAantal";
            this.cmb_SpelerAantal.Size = new System.Drawing.Size(121, 21);
            this.cmb_SpelerAantal.TabIndex = 0;
            this.cmb_SpelerAantal.Text = "1 speler";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(273, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hoeveel spelers?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_Begin
            // 
            this.btn_Begin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btn_Begin.Location = new System.Drawing.Point(326, 195);
            this.btn_Begin.Name = "btn_Begin";
            this.btn_Begin.Size = new System.Drawing.Size(121, 41);
            this.btn_Begin.TabIndex = 2;
            this.btn_Begin.Text = "Begin";
            this.btn_Begin.UseVisualStyleBackColor = true;
            this.btn_Begin.Click += new System.EventHandler(this.btn_Begin_Click);
            // 
            // cmb_AiAantal
            // 
            this.cmb_AiAantal.AllowDrop = true;
            this.cmb_AiAantal.FormattingEnabled = true;
            this.cmb_AiAantal.Items.AddRange(new object[] {
            "1 speler",
            "2 spelers",
            "3 spelers",
            "4 spelers"});
            this.cmb_AiAantal.Location = new System.Drawing.Point(326, 137);
            this.cmb_AiAantal.Name = "cmb_AiAantal";
            this.cmb_AiAantal.Size = new System.Drawing.Size(121, 21);
            this.cmb_AiAantal.TabIndex = 3;
            this.cmb_AiAantal.Text = "1 AI";
            // 
            // InitScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmb_AiAantal);
            this.Controls.Add(this.btn_Begin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_SpelerAantal);
            this.Name = "InitScherm";
            this.Text = "InitScherm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_SpelerAantal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Begin;
        private System.Windows.Forms.ComboBox cmb_AiAantal;
    }
}