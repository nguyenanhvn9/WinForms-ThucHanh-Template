using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2180607419_LeQuangDat
{
    internal class DiemTrungBinh
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== CHƯƠNG TRÌNH TÍNH ĐIỂM TRUNG BÌNH NÂNG CAO ===");
            Console.WriteLine("Nhập điểm các môn (theo thang điểm 10). Gõ 'done' để kết thúc.");

            List<double> diemSo = new List<double>();
            while (true)
            {
                Console.Write($"- Nhập điểm môn thứ {diemSo.Count + 1}: ");
                string input = Console.ReadLine();

                if (input.Trim().ToLower() == "done")
                    break;

                try
                {
                    double diem = double.Parse(input, CultureInfo.InvariantCulture);

                    if (diem < 0 || diem > 10)
                    {
                        Console.WriteLine(">> Điểm phải nằm trong khoảng 0 đến 10. Vui lòng nhập lại.");
                        continue;
                    }

                    diemSo.Add(diem);
                }
                catch (FormatException)
                {
                    Console.WriteLine(">> Lỗi: Vui lòng nhập một số hợp lệ hoặc 'done' để kết thúc.");
                }
            }

            if (diemSo.Count == 0)
            {
                Console.WriteLine(">> Không có điểm nào được nhập. Kết thúc chương trình.");
                return;
            }

            double tong = 0;
            foreach (double diem in diemSo)
            {
                tong += diem;
            }

            double diemTB = tong / diemSo.Count;

            string hocLuc;
            if (diemTB >= 8.0)
                hocLuc = "Giỏi";
            else if (diemTB >= 6.5)
                hocLuc = "Khá";
            else if (diemTB >= 5.0)
                hocLuc = "Trung bình";
            else
                hocLuc = "Yếu";

            Console.WriteLine($"\n>> Bạn đã nhập {diemSo.Count} môn.");
            Console.WriteLine($">> Điểm trung bình là: {diemTB:F2}");
            Console.WriteLine($">> Xếp loại học lực: {hocLuc}");
        }
    }
}
