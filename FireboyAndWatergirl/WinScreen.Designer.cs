﻿namespace FireboyAndWatergirl
{
    partial class WinScreen
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
            this.titleButton = new System.Windows.Forms.Button();
            this.levelButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.winLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleButton
            // 
            this.titleButton.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleButton.ForeColor = System.Drawing.Color.Black;
            this.titleButton.Location = new System.Drawing.Point(546, 413);
            this.titleButton.Name = "titleButton";
            this.titleButton.Size = new System.Drawing.Size(326, 113);
            this.titleButton.TabIndex = 1;
            this.titleButton.Text = "Back to Title";
            this.titleButton.UseVisualStyleBackColor = true;
            this.titleButton.Click += new System.EventHandler(this.titleButton_Click);
            // 
            // levelButton
            // 
            this.levelButton.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelButton.ForeColor = System.Drawing.Color.Black;
            this.levelButton.Location = new System.Drawing.Point(546, 532);
            this.levelButton.Name = "levelButton";
            this.levelButton.Size = new System.Drawing.Size(326, 113);
            this.levelButton.TabIndex = 2;
            this.levelButton.Text = "Levels";
            this.levelButton.UseVisualStyleBackColor = true;
            this.levelButton.Click += new System.EventHandler(this.levelButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(546, 651);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(326, 113);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // winLabel
            // 
            this.winLabel.AutoSize = true;
            this.winLabel.Location = new System.Drawing.Point(666, 256);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(51, 13);
            this.winLabel.TabIndex = 4;
            this.winLabel.Text = "You Win!";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(592, 334);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(86, 13);
            this.scoreLabel.TabIndex = 5;
            this.scoreLabel.Text = "Your score was: ";
            // 
            // scoreOutput
            // 
            this.scoreOutput.AutoSize = true;
            this.scoreOutput.Location = new System.Drawing.Point(684, 334);
            this.scoreOutput.Name = "scoreOutput";
            this.scoreOutput.Size = new System.Drawing.Size(21, 13);
            this.scoreOutput.TabIndex = 6;
            this.scoreOutput.Text = "##";
            // 
            // WinScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scoreOutput);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.levelButton);
            this.Controls.Add(this.titleButton);
            this.Name = "WinScreen";
            this.Size = new System.Drawing.Size(1400, 900);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button titleButton;
        private System.Windows.Forms.Button levelButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label scoreOutput;
    }
}
