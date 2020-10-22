namespace Paint
{
    partial class Tools
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
            this.Line = new System.Windows.Forms.Button();
            this.Circle = new System.Windows.Forms.Button();
            this.Fill = new System.Windows.Forms.Button();
            this.Besye = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Line
            // 
            this.Line.Location = new System.Drawing.Point(73, 12);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(86, 67);
            this.Line.TabIndex = 0;
            this.Line.Text = "Прямая";
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // Circle
            // 
            this.Circle.Location = new System.Drawing.Point(165, 11);
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(86, 67);
            this.Circle.TabIndex = 1;
            this.Circle.Text = "Окружность";
            this.Circle.UseVisualStyleBackColor = true;
            this.Circle.Click += new System.EventHandler(this.Circle_Click);
            // 
            // Fill
            // 
            this.Fill.Location = new System.Drawing.Point(257, 11);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(86, 67);
            this.Fill.TabIndex = 2;
            this.Fill.Text = "Заливка";
            this.Fill.UseVisualStyleBackColor = true;
            this.Fill.Click += new System.EventHandler(this.Fill_Click);
            // 
            // Besye
            // 
            this.Besye.Location = new System.Drawing.Point(349, 12);
            this.Besye.Name = "Besye";
            this.Besye.Size = new System.Drawing.Size(86, 67);
            this.Besye.TabIndex = 3;
            this.Besye.Text = "Безье";
            this.Besye.UseVisualStyleBackColor = true;
            this.Besye.Click += new System.EventHandler(this.Besye_Click);
            // 
            // Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 92);
            this.Controls.Add(this.Besye);
            this.Controls.Add(this.Fill);
            this.Controls.Add(this.Circle);
            this.Controls.Add(this.Line);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Tools";
            this.Text = "Tools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.Button Circle;
        private System.Windows.Forms.Button Fill;
        private System.Windows.Forms.Button Besye;
    }
}