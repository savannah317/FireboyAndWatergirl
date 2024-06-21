namespace FireboyAndWatergirl
{
    partial class DeathScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.levelButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.replayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(332, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "You died";
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(600, 513);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 75);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // levelButton
            // 
            this.levelButton.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelButton.ForeColor = System.Drawing.Color.Black;
            this.levelButton.Location = new System.Drawing.Point(600, 413);
            this.levelButton.Name = "levelButton";
            this.levelButton.Size = new System.Drawing.Size(200, 75);
            this.levelButton.TabIndex = 4;
            this.levelButton.Text = "Levels";
            this.levelButton.UseVisualStyleBackColor = true;
            this.levelButton.Click += new System.EventHandler(this.levelButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Papyrus", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.Black;
            this.backButton.Location = new System.Drawing.Point(600, 312);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(200, 75);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Back To Menu";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // replayButton
            // 
            this.replayButton.Font = new System.Drawing.Font("Papyrus", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replayButton.ForeColor = System.Drawing.Color.Black;
            this.replayButton.Location = new System.Drawing.Point(600, 200);
            this.replayButton.Name = "replayButton";
            this.replayButton.Size = new System.Drawing.Size(200, 75);
            this.replayButton.TabIndex = 6;
            this.replayButton.Text = "Play Again";
            this.replayButton.UseVisualStyleBackColor = true;
            this.replayButton.Click += new System.EventHandler(this.replayButton_Click);
            // 
            // DeathScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.replayButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.levelButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label1);
            this.Name = "DeathScreen";
            this.Size = new System.Drawing.Size(1400, 900);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button levelButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button replayButton;
    }
}
