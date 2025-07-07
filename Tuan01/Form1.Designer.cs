namespace TinhDiemWinForms_Ready
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtToan = new System.Windows.Forms.TextBox();
            this.txtVan = new System.Windows.Forms.TextBox();
            this.txtAnh = new System.Windows.Forms.TextBox();
            this.btnTinh = new System.Windows.Forms.Button();
            this.lblKQ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtToan
            // 
            this.txtToan.Location = new System.Drawing.Point(140, 30);
            this.txtToan.Name = "txtToan";
            this.txtToan.Size = new System.Drawing.Size(150, 22);
            this.txtToan.TabIndex = 0;
            // 
            // txtVan
            // 
            this.txtVan.Location = new System.Drawing.Point(140, 70);
            this.txtVan.Name = "txtVan";
            this.txtVan.Size = new System.Drawing.Size(150, 22);
            this.txtVan.TabIndex = 1;
            // 
            // txtAnh
            // 
            this.txtAnh.Location = new System.Drawing.Point(140, 110);
            this.txtAnh.Name = "txtAnh";
            this.txtAnh.Size = new System.Drawing.Size(150, 22);
            this.txtAnh.TabIndex = 2;
            // 
            // btnTinh
            // 
            this.btnTinh.Location = new System.Drawing.Point(140, 150);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(150, 30);
            this.btnTinh.TabIndex = 3;
            this.btnTinh.Text = "Tính điểm";
            this.btnTinh.UseVisualStyleBackColor = true;
            this.btnTinh.Click += new System.EventHandler(this.btnTinh_Click);
            // 
            // lblKQ
            // 
            this.lblKQ.AutoSize = true;
            this.lblKQ.Location = new System.Drawing.Point(140, 200);
            this.lblKQ.Name = "lblKQ";
            this.lblKQ.Size = new System.Drawing.Size(0, 16);
            this.lblKQ.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.lblKQ);
            this.Controls.Add(this.btnTinh);
            this.Controls.Add(this.txtAnh);
            this.Controls.Add(this.txtVan);
            this.Controls.Add(this.txtToan);
            this.Name = "Form1";
            this.Text = "Tính điểm trung bình";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtToan;
        private System.Windows.Forms.TextBox txtVan;
        private System.Windows.Forms.TextBox txtAnh;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.Label lblKQ;
    }
}