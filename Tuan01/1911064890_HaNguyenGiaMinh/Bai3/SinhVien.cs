using System;

namespace Bai3
{
    class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string Khoa { get; set; }
        public double DiemTB { get; set; }

        public override string ToString()
        {
            return $"{MaSV},{HoTen},{Khoa},{DiemTB}";
        }
    }
}