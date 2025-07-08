using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    internal class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public double DiemTB { get; set; }

        // Add a parameterless constructor
        public SinhVien() { }

        // Existing constructor with parameters
        public SinhVien(string maSV, string hoTen, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            DiemTB = diemTB;
        }

        public override string ToString()
        {
            return $"{MaSV} - {HoTen} - {DiemTB:F2}";
        }
    }
}
