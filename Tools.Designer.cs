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
            this.Bezier = new System.Windows.Forms.Button();
            this.FillAdapt = new System.Windows.Forms.Button();
            this.FillPattern = new System.Windows.Forms.Button();
            this.Eazier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Line
            // 
            this.Line.Location = new System.Drawing.Point(50, 13);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(86, 67);
            this.Line.TabIndex = 0;
            this.Line.Text = "Прямая";
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // Circle
            // 
            this.Circle.Location = new System.Drawing.Point(142, 12);
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(86, 67);
            this.Circle.TabIndex = 1;
            this.Circle.Text = "Окружность";
            this.Circle.UseVisualStyleBackColor = true;
            this.Circle.Click += new System.EventHandler(this.Circle_Click);
            // 
            // Fill
            // 
            this.Fill.Location = new System.Drawing.Point(234, 12);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(86, 67);
            this.Fill.TabIndex = 2;
            this.Fill.Text = "Заливка";
            this.Fill.UseVisualStyleBackColor = true;
            this.Fill.Click += new System.EventHandler(this.Fill_Click);
            // 
            // Bezier
            // 
            this.Bezier.Location = new System.Drawing.Point(326, 13);
            this.Bezier.Name = "Bezier";
            this.Bezier.Size = new System.Drawing.Size(86, 67);
            this.Bezier.TabIndex = 3;
            this.Bezier.Text = "Безье";
            this.Bezier.UseVisualStyleBackColor = true;
            this.Bezier.Click += new System.EventHandler(this.Bezier_Click);
            // 
            // FillAdapt
            // 
            this.FillAdapt.Location = new System.Drawing.Point(418, 14);
            this.FillAdapt.Name = "FillAdapt";
            this.FillAdapt.Size = new System.Drawing.Size(86, 67);
            this.FillAdapt.TabIndex = 4;
            this.FillAdapt.Text = "Улучшенная Заливка";
            this.FillAdapt.UseVisualStyleBackColor = true;
            this.FillAdapt.Click += new System.EventHandler(this.FillAdapt_Click);
            // 
            // FillPattern
            // 
            this.FillPattern.Location = new System.Drawing.Point(510, 14);
            this.FillPattern.Name = "FillPattern";
            this.FillPattern.Size = new System.Drawing.Size(86, 67);
            this.FillPattern.TabIndex = 5;
            this.FillPattern.Text = "Заливка узором";
            this.FillPattern.UseVisualStyleBackColor = true;
            this.FillPattern.Click += new System.EventHandler(this.FillPattern_Click);
            // 
            // Eazier
            // 
            this.Eazier.Location = new System.Drawing.Point(602, 14);
            this.Eazier.Name = "Eazier";
            this.Eazier.Size = new System.Drawing.Size(86, 67);
            this.Eazier.TabIndex = 6;
            this.Eazier.Text = "Стереть";
            this.Eazier.UseVisualStyleBackColor = true;
            this.Eazier.Click += new System.EventHandler(this.Eazier_Click);
            // 
            // Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 92);
            this.Controls.Add(this.Eazier);
            this.Controls.Add(this.FillPattern);
            this.Controls.Add(this.FillAdapt);
            this.Controls.Add(this.Bezier);
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
        private System.Windows.Forms.Button Bezier;
        private System.Windows.Forms.Button FillAdapt;
        private System.Windows.Forms.Button FillPattern;
        private System.Windows.Forms.Button Eazier;
    }
}