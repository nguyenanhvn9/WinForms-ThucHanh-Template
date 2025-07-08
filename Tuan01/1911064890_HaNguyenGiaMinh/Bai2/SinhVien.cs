using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    internal class SinhVien
    {
        private string _maSV = "";
        private string _hoTen = "";
        private double _diemTB;

        public string MaSV
        {
            get { return _maSV; }
            set { _maSV = value; }
        }

        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }

        public double DiemTB
        {
            get { return _diemTB; }
            set { _diemTB = value; }
        }
    }
}
