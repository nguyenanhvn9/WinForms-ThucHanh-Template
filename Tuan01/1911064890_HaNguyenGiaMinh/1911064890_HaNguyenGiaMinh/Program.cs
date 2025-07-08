using System;
using System.Globalization;

namespace Bai1_TinhDiemTrungBinh
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("==== CHƯƠNG TRÌNH TÍNH ĐIỂM TRUNG BÌNH ====");
            Console.WriteLine("Nhập điểm của các môn Toán, Văn, Anh để tính điểm trung bình và xếp loại.");
            Console.WriteLine("Gõ \"done\" để thoát.\n");

            while (true)
            {
                try
                {
                    Console.Write("→ Nhập điểm Toán: ");
                    string inputToan = Console.ReadLine();
                    if (inputToan.ToLower() == "done") break;
                    double toan = double.Parse(inputToan, CultureInfo.InvariantCulture);

                    Console.Write("→ Nhập điểm Văn: ");
                    string inputVan = Console.ReadLine();
                    if (inputVan.ToLower() == "done") break;
                    double van = double.Parse(inputVan, CultureInfo.InvariantCulture);

                    Console.Write("→ Nhập điểm Anh: ");
                    string inputAnh = Console.ReadLine();
                    if (inputAnh.ToLower() == "done") break;
                    double anh = double.Parse(inputAnh, CultureInfo.InvariantCulture);

                    double diemTB = (toan + van + anh) / 3;
                    string xepLoai;

                    if (diemTB >= 8.0)
                        xepLoai = "Giỏi";
                    else if (diemTB >= 6.5)
                        xepLoai = "Khá";
                    else if (diemTB >= 5.0)
                        xepLoai = "Trung bình";
                    else
                        xepLoai = "Yếu";

                    Console.WriteLine($"\n📌 Điểm trung bình: {diemTB:F2}");
                    Console.WriteLine($"📌 Xếp loại học lực: {xepLoai}\n");
                    Console.WriteLine(new string('-', 40));
                }
                catch (FormatException)
                {
                    Console.WriteLine("⚠️ Lỗi: Vui lòng nhập đúng định dạng số (sử dụng dấu chấm cho phần thập phân).\n");
                }
            }

            Console.WriteLine("\nChương trình kết thúc. Cảm ơn bạn đã sử dụng!");
        }
    }
}