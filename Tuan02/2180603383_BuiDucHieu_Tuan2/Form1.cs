using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateCalculatorButtons(); // Gọi hàm tạo nút ở đây
        }

        private void CreateCalculatorButtons()
        {
            string[,] buttons = {
                { "MC", "MR", "M+", "M-", "MS", "Mv" },
                { "%", "CE", "C", "⌫", "", "" },
                { "1/x", "x²", "√x", "/", "", "" },
                { "7", "8", "9", "*", "", "" },
                { "4", "5", "6", "-", "", "" },
                { "1", "2", "3", "+", "", "" },
                { "±", "0", ".", "=", "", "" }
            };

            int startX = 12, startY = 70;
            int btnWidth = 60, btnHeight = 45;
            int spacing = 10;
            int tabIndex = 1;

            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    string text = buttons[i, j];
                    if (string.IsNullOrEmpty(text)) continue;

                    var btn = new Button();
                    btn.Font = new System.Drawing.Font("Segoe UI", 12F);
                    btn.Size = new System.Drawing.Size(btnWidth, btnHeight);
                    btn.Location = new System.Drawing.Point(startX + j * (btnWidth + spacing), startY + i * (btnHeight + spacing));
                    btn.Name = "btn" + text.Replace("/", "Div").Replace("*", "Mul").Replace("+", "Plus")
                                           .Replace("-", "Minus").Replace("=", "Equal").Replace(".", "Dot")
                                           .Replace("±", "Neg").Replace("⌫", "Back").Replace("x²", "Sqr")
                                           .Replace("√x", "Sqrt").Replace("1/x", "Inv");
                    btn.TabIndex = tabIndex++;
                    btn.Text = text;
                    btn.UseVisualStyleBackColor = true;

                    // Bạn có thể gán sự kiện click ở đây nếu muốn
                    // btn.Click += Btn_Click;

                    this.Controls.Add(btn);
                }
            }
        }
    }
}
