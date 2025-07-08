using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("--- CHƯƠNG TRÌNH TÍNH ĐIỂM TRUNG BÌNH ---");
        Console.WriteLine("Vui lòng nhập điểm cho 3 môn học: Toán, Văn, Anh.");
        Console.WriteLine("-------------------------------------------");

        double diemToan = NhapDiem("Nhập điểm môn Toán: ");
        double diemVan = NhapDiem("Nhập điểm môn Văn: ");
        double diemAnh = NhapDiem("Nhập điểm môn Anh: ");

        double diemTrungBinh = (diemToan + diemVan + diemAnh) / 3;

        string xepLoai;
        if (diemTrungBinh >= 8.0)
        {
            xepLoai = "Giỏi";
        }
        else if (diemTrungBinh >= 6.5)
        {
            xepLoai = "Khá";
        }
        else if (diemTrungBinh >= 5.0)
        {
            xepLoai = "Trung bình";
        }
        else
        {
            xepLoai = "Yếu";
        }

        Console.WriteLine("\n--- KẾT QUẢ HỌC TẬP ---");
        Console.WriteLine($"Điểm trung bình của bạn là: {diemTrungBinh:F2}");
        Console.WriteLine($"Xếp loại học lực: {xepLoai}");

        Console.WriteLine("\nNhấn phím bất kỳ để thoát.");
        Console.ReadKey();
    }

    static double NhapDiem(string prompt)
    {
        double diem;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out diem) && diem >= 0 && diem <= 10)
            {
                return diem;
            }
            else
            {
                Console.WriteLine("Lỗi: Vui lòng nhập một số hợp lệ từ 0 đến 10.");
            }
        }
    }
}
