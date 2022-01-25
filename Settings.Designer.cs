namespace Machi_Koro
{
    partial class Settings
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
            this.Cb_wachttijd = new System.Windows.Forms.CheckBox();
            this.Dd_moeilijkheid = new System.Windows.Forms.ComboBox();
            this.settingsLabel1 = new System.Windows.Forms.Label();
            this.settingsLabel2 = new System.Windows.Forms.Label();
            this.settingsLabel3 = new System.Windows.Forms.Label();
            this.settingsConfirm = new System.Windows.Forms.Button();
            this.Tb_wachttijd = new System.Windows.Forms.TextBox();
            this.testlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cb_wachttijd
            // 
            this.Cb_wachttijd.AutoSize = true;
            this.Cb_wachttijd.Location = new System.Drawing.Point(499, 139);
            this.Cb_wachttijd.Name = "Cb_wachttijd";
            this.Cb_wachttijd.Size = new System.Drawing.Size(15, 14);
            this.Cb_wachttijd.TabIndex = 0;
            this.Cb_wachttijd.UseVisualStyleBackColor = true;
            this.Cb_wachttijd.CheckStateChanged += new System.EventHandler(this.Cb_wachttijd_CheckStateChanged);
            // 
            // Dd_moeilijkheid
            // 
            this.Dd_moeilijkheid.FormattingEnabled = true;
            this.Dd_moeilijkheid.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.Dd_moeilijkheid.Location = new System.Drawing.Point(448, 215);
            this.Dd_moeilijkheid.Name = "Dd_moeilijkheid";
            this.Dd_moeilijkheid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dd_moeilijkheid.Size = new System.Drawing.Size(121, 21);
            this.Dd_moeilijkheid.TabIndex = 2;
            this.Dd_moeilijkheid.Text = "0";
            // 
            // settingsLabel1
            // 
            this.settingsLabel1.AutoSize = true;
            this.settingsLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.settingsLabel1.Location = new System.Drawing.Point(293, 139);
            this.settingsLabel1.Name = "settingsLabel1";
            this.settingsLabel1.Size = new System.Drawing.Size(149, 17);
            this.settingsLabel1.TabIndex = 3;
            this.settingsLabel1.Text = "Wachttijd uitschakelen";
            // 
            // settingsLabel2
            // 
            this.settingsLabel2.AutoSize = true;
            this.settingsLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.settingsLabel2.Location = new System.Drawing.Point(293, 177);
            this.settingsLabel2.Name = "settingsLabel2";
            this.settingsLabel2.Size = new System.Drawing.Size(110, 17);
            this.settingsLabel2.TabIndex = 4;
            this.settingsLabel2.Text = "Lengte wachttijd";
            // 
            // settingsLabel3
            // 
            this.settingsLabel3.AutoSize = true;
            this.settingsLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.settingsLabel3.Location = new System.Drawing.Point(293, 215);
            this.settingsLabel3.Name = "settingsLabel3";
            this.settingsLabel3.Size = new System.Drawing.Size(141, 17);
            this.settingsLabel3.TabIndex = 5;
            this.settingsLabel3.Text = "AI moeilijkheidsgraad";
            // 
            // settingsConfirm
            // 
            this.settingsConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.settingsConfirm.Location = new System.Drawing.Point(448, 270);
            this.settingsConfirm.Name = "settingsConfirm";
            this.settingsConfirm.Size = new System.Drawing.Size(121, 46);
            this.settingsConfirm.TabIndex = 6;
            this.settingsConfirm.Text = "Confirm";
            this.settingsConfirm.UseMnemonic = false;
            this.settingsConfirm.UseVisualStyleBackColor = true;
            this.settingsConfirm.UseWaitCursor = true;
            this.settingsConfirm.Click += new System.EventHandler(this.settingsConfirm_Click);
            // 
            // Tb_wachttijd
            // 
            this.Tb_wachttijd.Location = new System.Drawing.Point(448, 177);
            this.Tb_wachttijd.Name = "Tb_wachttijd";
            this.Tb_wachttijd.Size = new System.Drawing.Size(121, 20);
            this.Tb_wachttijd.TabIndex = 7;
            this.Tb_wachttijd.Text = "35";
            // 
            // testlabel
            // 
            this.testlabel.AutoSize = true;
            this.testlabel.Location = new System.Drawing.Point(429, 50);
            this.testlabel.Name = "testlabel";
            this.testlabel.Size = new System.Drawing.Size(0, 13);
            this.testlabel.TabIndex = 8;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 522);
            this.Controls.Add(this.testlabel);
            this.Controls.Add(this.Tb_wachttijd);
            this.Controls.Add(this.settingsConfirm);
            this.Controls.Add(this.settingsLabel3);
            this.Controls.Add(this.settingsLabel2);
            this.Controls.Add(this.settingsLabel1);
            this.Controls.Add(this.Dd_moeilijkheid);
            this.Controls.Add(this.Cb_wachttijd);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Cb_wachttijd;
        private System.Windows.Forms.ComboBox Dd_moeilijkheid;
        private System.Windows.Forms.Label settingsLabel1;
        private System.Windows.Forms.Label settingsLabel2;
        private System.Windows.Forms.Label settingsLabel3;
        private System.Windows.Forms.Button settingsConfirm;
        private System.Windows.Forms.TextBox Tb_wachttijd;
        private System.Windows.Forms.Label testlabel;
    }
}