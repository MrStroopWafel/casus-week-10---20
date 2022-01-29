namespace Machi_Koro
{
    partial class StartPagina
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
            this.startGameButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.hoofdschermLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startGameButton
            // 
            this.startGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.startGameButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startGameButton.Location = new System.Drawing.Point(400, 183);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(173, 57);
            this.startGameButton.TabIndex = 0;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.settingsButton.Location = new System.Drawing.Point(400, 256);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(173, 59);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // hoofdschermLabel
            // 
            this.hoofdschermLabel.AutoSize = true;
            this.hoofdschermLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hoofdschermLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.hoofdschermLabel.Location = new System.Drawing.Point(88, 120);
            this.hoofdschermLabel.Name = "hoofdschermLabel";
            this.hoofdschermLabel.Size = new System.Drawing.Size(821, 33);
            this.hoofdschermLabel.TabIndex = 2;
            this.hoofdschermLabel.Text = "Welkom bij Machi Koro, klik op een knop hieronder om te beginnen!\r\n";
            // 
            // StartPagina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 520);
            this.Controls.Add(this.hoofdschermLabel);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.startGameButton);
            this.Name = "StartPagina";
            this.Text = "Machi Koro";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Label hoofdschermLabel;
    }
}

