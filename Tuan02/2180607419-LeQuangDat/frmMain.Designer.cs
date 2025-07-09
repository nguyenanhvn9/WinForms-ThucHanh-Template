namespace _2180607419_LeQuangDat
{
    partial class frmMain
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
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            txtDisplay = new TextBox();
            btnPlusMinus = new Button();
            btn0 = new Button();
            btnDecimal = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btnPlus = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btnMinus = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnMultiply = new Button();
            btnReciprocal = new Button();
            btnSquare = new Button();
            btnsqrt = new Button();
            btnDivide = new Button();
            btnPercent = new Button();
            btnClearEntry = new Button();
            btnClear = new Button();
            btnBackspace = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Font = new Font("Segoe UI", 14F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(95, 75);
            button1.Name = "button1";
            button1.Size = new Size(37, 32);
            button1.TabIndex = 0;
            button1.Text = "\t☰";
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(138, 79);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 1;
            label1.Text = "Standard";
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(370, 79);
            button2.Name = "button2";
            button2.Size = new Size(51, 32);
            button2.TabIndex = 2;
            button2.Text = "🕘";
            button2.UseVisualStyleBackColor = false;
            // 
            // txtDisplay
            // 
            txtDisplay.BackColor = Color.Black;
            txtDisplay.BorderStyle = BorderStyle.None;
            txtDisplay.Font = new Font("Segoe UI", 28F);
            txtDisplay.ForeColor = Color.White;
            txtDisplay.Location = new Point(95, 169);
            txtDisplay.Name = "txtDisplay";
            txtDisplay.ReadOnly = true;
            txtDisplay.Size = new Size(326, 50);
            txtDisplay.TabIndex = 3;
            txtDisplay.Text = "0";
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            // 
            // btnPlusMinus
            // 
            btnPlusMinus.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnPlusMinus.ForeColor = Color.Black;
            btnPlusMinus.Location = new Point(88, 599);
            btnPlusMinus.Name = "btnPlusMinus";
            btnPlusMinus.Size = new Size(84, 60);
            btnPlusMinus.TabIndex = 4;
            btnPlusMinus.Text = "+/-";
            btnPlusMinus.UseVisualStyleBackColor = true;
            btnPlusMinus.Click += btnPlusMinus_Click;
            // 
            // btn0
            // 
            btn0.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btn0.ForeColor = Color.Black;
            btn0.Location = new Point(178, 599);
            btn0.Name = "btn0";
            btn0.Size = new Size(77, 60);
            btn0.TabIndex = 4;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += btnNumber_Click;
            // 
            // btnDecimal
            // 
            btnDecimal.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnDecimal.ForeColor = Color.Black;
            btnDecimal.Location = new Point(261, 599);
            btnDecimal.Name = "btnDecimal";
            btnDecimal.Size = new Size(77, 60);
            btnDecimal.TabIndex = 4;
            btnDecimal.Text = ",";
            btnDecimal.UseVisualStyleBackColor = true;
            btnDecimal.Click += btnDecimal_Click;
            // 
            // btn1
            // 
            btn1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btn1.ForeColor = Color.Black;
            btn1.Location = new Point(88, 533);
            btn1.Name = "btn1";
            btn1.Size = new Size(84, 60);
            btn1.TabIndex = 4;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btnNumber_Click;
            // 
            // btn2
            // 
            btn2.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btn2.ForeColor = Color.Black;
            btn2.Location = new Point(178, 533);
            btn2.Name = "btn2";
            btn2.Size = new Size(77, 60);
            btn2.TabIndex = 4;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btnNumber_Click;
            // 
            // btn3
            // 
            btn3.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btn3.ForeColor = Color.Black;
            btn3.Location = new Point(261, 533);
            btn3.Name = "btn3";
            btn3.Size = new Size(77, 60);
            btn3.TabIndex = 4;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btnNumber_Click;
            // 
            // btnPlus
            // 
            btnPlus.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnPlus.ForeColor = Color.Black;
            btnPlus.Location = new Point(344, 533);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(77, 60);
            btnPlus.TabIndex = 4;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += btnOperator_Click;
            // 
            // btn4
            // 
            btn4.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btn4.ForeColor = Color.Black;
            btn4.Location = new Point(88, 467);
            btn4.Name = "btn4";
            btn4.Size = new Size(84, 60);
            btn4.TabIndex = 4;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btnNumber_Click;
            // 
            // btn5
            // 
            btn5.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btn5.ForeColor = Color.Black;
            btn5.Location = new Point(178, 467);
            btn5.Name = "btn5";
            btn5.Size = new Size(77, 60);
            btn5.TabIndex = 4;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btnNumber_Click;
            // 
            // btn6
            // 
            btn6.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btn6.ForeColor = Color.Black;
            btn6.Location = new Point(261, 467);
            btn6.Name = "btn6";
            btn6.Size = new Size(77, 60);
            btn6.TabIndex = 4;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btnNumber_Click;
            // 
            // btnMinus
            // 
            btnMinus.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnMinus.ForeColor = Color.Black;
            btnMinus.Location = new Point(344, 467);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(77, 60);
            btnMinus.TabIndex = 4;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += btnOperator_Click;
            // 
            // btn7
            // 
            btn7.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btn7.ForeColor = Color.Black;
            btn7.Location = new Point(88, 401);
            btn7.Name = "btn7";
            btn7.Size = new Size(84, 60);
            btn7.TabIndex = 4;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btnNumber_Click;
            // 
            // btn8
            // 
            btn8.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btn8.ForeColor = Color.Black;
            btn8.Location = new Point(178, 401);
            btn8.Name = "btn8";
            btn8.Size = new Size(77, 60);
            btn8.TabIndex = 4;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btnNumber_Click;
            // 
            // btn9
            // 
            btn9.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btn9.ForeColor = Color.Black;
            btn9.Location = new Point(261, 401);
            btn9.Name = "btn9";
            btn9.Size = new Size(77, 60);
            btn9.TabIndex = 4;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btnNumber_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnMultiply.ForeColor = Color.Black;
            btnMultiply.Location = new Point(344, 401);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(77, 60);
            btnMultiply.TabIndex = 4;
            btnMultiply.Text = "x";
            btnMultiply.UseVisualStyleBackColor = true;
            btnMultiply.Click += btnOperator_Click;
            // 
            // btnReciprocal
            // 
            btnReciprocal.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnReciprocal.ForeColor = Color.Black;
            btnReciprocal.Location = new Point(88, 335);
            btnReciprocal.Name = "btnReciprocal";
            btnReciprocal.Size = new Size(84, 60);
            btnReciprocal.TabIndex = 4;
            btnReciprocal.Text = "1/x";
            btnReciprocal.UseVisualStyleBackColor = true;
            btnReciprocal.Click += btnReciprocal_Click;
            // 
            // btnSquare
            // 
            btnSquare.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnSquare.ForeColor = Color.Black;
            btnSquare.Location = new Point(178, 335);
            btnSquare.Name = "btnSquare";
            btnSquare.Size = new Size(77, 60);
            btnSquare.TabIndex = 4;
            btnSquare.Text = "x²";
            btnSquare.UseVisualStyleBackColor = true;
            btnSquare.Click += btnSquare_Click;
            // 
            // btnsqrt
            // 
            btnsqrt.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnsqrt.ForeColor = Color.Black;
            btnsqrt.Location = new Point(261, 335);
            btnsqrt.Name = "btnsqrt";
            btnsqrt.Size = new Size(77, 60);
            btnsqrt.TabIndex = 4;
            btnsqrt.Text = "²√x";
            btnsqrt.UseVisualStyleBackColor = true;
            btnsqrt.Click += btnsqrt_Click;
            // 
            // btnDivide
            // 
            btnDivide.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDivide.ForeColor = Color.Black;
            btnDivide.Location = new Point(344, 335);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(77, 60);
            btnDivide.TabIndex = 4;
            btnDivide.Text = "÷";
            btnDivide.UseVisualStyleBackColor = true;
            btnDivide.Click += btnOperator_Click;
            // 
            // btnPercent
            // 
            btnPercent.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnPercent.ForeColor = Color.Black;
            btnPercent.Location = new Point(88, 269);
            btnPercent.Name = "btnPercent";
            btnPercent.Size = new Size(84, 60);
            btnPercent.TabIndex = 4;
            btnPercent.Text = "%";
            btnPercent.UseVisualStyleBackColor = true;
            btnPercent.Click += btnPercent_Click;
            // 
            // btnClearEntry
            // 
            btnClearEntry.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnClearEntry.ForeColor = Color.Black;
            btnClearEntry.Location = new Point(178, 269);
            btnClearEntry.Name = "btnClearEntry";
            btnClearEntry.Size = new Size(77, 60);
            btnClearEntry.TabIndex = 4;
            btnClearEntry.Text = "CE";
            btnClearEntry.UseVisualStyleBackColor = true;
            btnClearEntry.Click += btnClearEntry_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnClear.ForeColor = Color.Black;
            btnClear.Location = new Point(261, 269);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(77, 60);
            btnClear.TabIndex = 4;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnBackspace
            // 
            btnBackspace.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            btnBackspace.ForeColor = Color.Black;
            btnBackspace.Location = new Point(344, 269);
            btnBackspace.Name = "btnBackspace";
            btnBackspace.Size = new Size(77, 60);
            btnBackspace.TabIndex = 4;
            btnBackspace.Text = "⌫ ";
            btnBackspace.UseVisualStyleBackColor = true;
            btnBackspace.Click += btnBackspace_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(344, 599);
            button3.Name = "button3";
            button3.Size = new Size(77, 60);
            button3.TabIndex = 4;
            button3.Text = "=";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnEquals_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 821);
            Controls.Add(btnBackspace);
            Controls.Add(btnClear);
            Controls.Add(btnDivide);
            Controls.Add(btnsqrt);
            Controls.Add(btnMultiply);
            Controls.Add(btn9);
            Controls.Add(btnMinus);
            Controls.Add(btnClearEntry);
            Controls.Add(btn6);
            Controls.Add(btnSquare);
            Controls.Add(btnPlus);
            Controls.Add(btn8);
            Controls.Add(btn3);
            Controls.Add(btnPercent);
            Controls.Add(btn5);
            Controls.Add(btnReciprocal);
            Controls.Add(button3);
            Controls.Add(btn7);
            Controls.Add(btn2);
            Controls.Add(btn4);
            Controls.Add(btnDecimal);
            Controls.Add(btn1);
            Controls.Add(btn0);
            Controls.Add(btnPlusMinus);
            Controls.Add(txtDisplay);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            ForeColor = Color.White;
            Name = "frmMain";
            Text = "Bài tập 2 ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button button2;
        private TextBox txtDisplay;
        private Button btnPlusMinus;
        private Button btn0;
        private Button btnDecimal;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btnPlus;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btnMinus;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnMultiply;
        private Button btnReciprocal;
        private Button btnSquare;
        private Button btnsqrt;
        private Button btnDivide;
        private Button btnPercent;
        private Button btnClearEntry;
        private Button btnClear;
        private Button btnBackspace;
        private Button button3;
    }
}