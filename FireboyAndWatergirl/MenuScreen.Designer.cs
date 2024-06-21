namespace FireboyAndWatergirl
{
    partial class MenuScreen
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
            this.startButton = new System.Windows.Forms.Button();
            this.levelButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.Color.Black;
            this.startButton.Location = new System.Drawing.Point(607, 397);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(200, 75);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Play";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // levelButton
            // 
            this.levelButton.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelButton.ForeColor = System.Drawing.Color.Black;
            this.levelButton.Location = new System.Drawing.Point(607, 498);
            this.levelButton.Name = "levelButton";
            this.levelButton.Size = new System.Drawing.Size(200, 75);
            this.levelButton.TabIndex = 1;
            this.levelButton.Text = "Levels";
            this.levelButton.UseVisualStyleBackColor = true;
            this.levelButton.Click += new System.EventHandler(this.levelButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(607, 598);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 75);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Chiller", 96F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1400, 289);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fireboy And Watergirl";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Chiller", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1400, 120);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cave Adventures";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.levelButton);
            this.Controls.Add(this.startButton);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(1400, 900);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button levelButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
