using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    public class SinhVien
    {
        private string MaSV;
        public string getMaSV { get { return MaSV; } }
        public void setMaSV(string maSV) { MaSV = maSV; }


        private string HoTen;
        public string getHoTen { get { return HoTen; } }
        public void setHoTen(string hoTen) { HoTen = hoTen; }


        private double DiemTB;
        public double getDiemTB { get { return DiemTB; } }
        public void setDiemTB(double diemTB) { DiemTB = diemTB; }


        public SinhVien()
        {
            MaSV = string.Empty;
            HoTen = string.Empty;
            DiemTB = 0.0;
        }
        public SinhVien(string maSV, string hoTen, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            DiemTB = diemTB;
        }

        public void addSinhVien()
        {
            Console.Write("Nhap ma sinh vien: ");
            MaSV = Console.ReadLine();
            Console.Write("Nhap ho ten sinh vien: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap diem trung binh: ");
            DiemTB = Convert.ToDouble(Console.ReadLine());
            while (DiemTB < 0 || DiemTB > 10)
            {
                Console.Write("Diem trung binh phai trong khoang tu 0 den 10. Vui long nhap lai: ");
                DiemTB = Convert.ToDouble(Console.ReadLine());
            }
        }

        public void hienThiSinhVien()
        {
            Console.WriteLine(string.Format("{0,-10} | {1,-25} | {2,-5}", MaSV, HoTen, DiemTB));
            //Console.WriteLine($"Ma SV: {MaSV}\t| Ho Ten: {HoTen}\t| Diem TB: {DiemTB:F2}\t|");
        }


        public void capNhatSinhVien(string maSV)
        {
            if (MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Nhap ho ten moi: ");
                HoTen = Console.ReadLine();
                Console.Write("Nhap diem trung binh moi: ");
                DiemTB = Convert.ToDouble(Console.ReadLine());
                while (DiemTB < 0 || DiemTB > 10)
                {
                    Console.Write("Diem trung binh phai trong khoang tu 0 den 10. Vui long nhap lai:");
                    DiemTB = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine("Da cap nhat thong tin sinh vien thanh cong.");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien voi ma da nhap.");
            }
        }

    }
}
