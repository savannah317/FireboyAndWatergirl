namespace FireboyAndWatergirl
{
    partial class LevelScreen
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
            this.level1Button = new System.Windows.Forms.Button();
            this.level2Button = new System.Windows.Forms.Button();
            this.level3Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Chiller", 96F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1400, 148);
            this.label1.TabIndex = 4;
            this.label1.Text = "Level Selector";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // level1Button
            // 
            this.level1Button.Font = new System.Drawing.Font("Tempus Sans ITC", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.level1Button.ForeColor = System.Drawing.Color.Black;
            this.level1Button.Location = new System.Drawing.Point(366, 211);
            this.level1Button.Name = "level1Button";
            this.level1Button.Size = new System.Drawing.Size(666, 148);
            this.level1Button.TabIndex = 5;
            this.level1Button.Text = "1";
            this.level1Button.UseVisualStyleBackColor = true;
            this.level1Button.Click += new System.EventHandler(this.level1Button_Click);
            // 
            // level2Button
            // 
            this.level2Button.Enabled = false;
            this.level2Button.Font = new System.Drawing.Font("Tempus Sans ITC", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.level2Button.ForeColor = System.Drawing.Color.Black;
            this.level2Button.Location = new System.Drawing.Point(366, 404);
            this.level2Button.Name = "level2Button";
            this.level2Button.Size = new System.Drawing.Size(666, 148);
            this.level2Button.TabIndex = 6;
            this.level2Button.Text = "2";
            this.level2Button.UseVisualStyleBackColor = true;
            this.level2Button.Click += new System.EventHandler(this.level2Button_Click);
            // 
            // level3Button
            // 
            this.level3Button.Enabled = false;
            this.level3Button.Font = new System.Drawing.Font("Tempus Sans ITC", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.level3Button.ForeColor = System.Drawing.Color.Black;
            this.level3Button.Location = new System.Drawing.Point(353, 619);
            this.level3Button.Name = "level3Button";
            this.level3Button.Size = new System.Drawing.Size(679, 148);
            this.level3Button.TabIndex = 7;
            this.level3Button.Text = "3";
            this.level3Button.UseVisualStyleBackColor = true;
            this.level3Button.Click += new System.EventHandler(this.level3Button_Click);
            // 
            // LevelScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FireboyAndWatergirl.Properties.Resources.bkgdFbWg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.level3Button);
            this.Controls.Add(this.level2Button);
            this.Controls.Add(this.level1Button);
            this.Controls.Add(this.label1);
            this.Name = "LevelScreen";
            this.Size = new System.Drawing.Size(1400, 900);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button level1Button;
        private System.Windows.Forms.Button level2Button;
        private System.Windows.Forms.Button level3Button;
    }
}
