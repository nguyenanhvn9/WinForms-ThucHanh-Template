namespace Calculator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblDisplay;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblDisplay = new Label();
            SuspendLayout();
            // 
            // lblDisplay
            // 
            lblDisplay.Font = new Font("Segoe UI", 24F);
            lblDisplay.Location = new Point(14, 12);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(469, 67);
            lblDisplay.TabIndex = 0;
            lblDisplay.Text = "0";
            lblDisplay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 680);
            Controls.Add(lblDisplay);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Calculator";
            ResumeLayout(false);
        }
    }
}