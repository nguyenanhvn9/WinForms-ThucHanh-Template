using Bai2;
using System.Globalization;

class Program
{
    static List<SinhVien> danhSachSV = new List<SinhVien>();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("\n===== QUẢN LÝ DANH SÁCH SINH VIÊN =====");
            Console.WriteLine("1. Thêm mới sinh viên");
            Console.WriteLine("2. Hiển thị danh sách sinh viên");
            Console.WriteLine("3. Tìm kiếm sinh viên theo MSSV");
            Console.WriteLine("4. Xóa sinh viên theo MSSV");
            Console.WriteLine("5. Cập nhật thông tin sinh viên theo MSSV");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");
            string? chon = Console.ReadLine();

            switch (chon)
            {
                case "1":
                    ThemMoiSinhVien();
                    break;
                case "2":
                    HienThiDanhSach();
                    break;
                case "3":
                    TimKiemSinhVien();
                    break;
                case "4":
                    XoaSinhVien();
                    break;
                case "5":
                    CapNhatSinhVien();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        }
    }

    static void ThemMoiSinhVien()
    {
        Console.Write("Nhập mã số sinh viên: ");
        string? maSV = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(maSV))
        {
            Console.WriteLine("Mã số sinh viên không được để trống.");
            return;
        }
        if (danhSachSV.Exists(sv => sv.MaSV == maSV))
        {
            Console.WriteLine("Mã số sinh viên đã tồn tại!");
            return;
        }

        Console.Write("Nhập họ tên: ");
        string? hoTen = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(hoTen))
        {
            Console.WriteLine("Họ tên không được để trống.");
            return;
        }

        double diemTB;
        while (true)
        {
            Console.Write("Nhập điểm trung bình: ");
            string? input = Console.ReadLine();
            try
            {
                diemTB = double.Parse(input ?? "", CultureInfo.InvariantCulture);
                if (diemTB < 0 || diemTB > 10)
                {
                    Console.WriteLine("Điểm trung bình phải từ 0 đến 10.");
                    continue;
                }
                break;
            }
            catch
            {
                Console.WriteLine("Điểm trung bình không hợp lệ.");
            }
        }

        danhSachSV.Add(new SinhVien { MaSV = maSV, HoTen = hoTen, DiemTB = diemTB });
        Console.WriteLine("Thêm sinh viên thành công!");
    }

    static void HienThiDanhSach()
    {
        if (danhSachSV.Count == 0)
        {
            Console.WriteLine("Danh sách sinh viên rỗng.");
            return;
        }
        Console.WriteLine("\n{0,-15}|{1,-25}|{2,10}", "Mã SV", "Họ tên", "Điểm TB");
        Console.WriteLine(new string('-', 54));
        foreach (var sv in danhSachSV)
        {
            Console.WriteLine($"{sv.MaSV,-15}|{sv.HoTen,-25}|{sv.DiemTB,10:F2}");
        }
    }

    static void TimKiemSinhVien()
    {
        Console.Write("Nhập MSSV cần tìm: ");
        string? maSV = Console.ReadLine();
        var sv = danhSachSV.Find(s => s.MaSV == maSV);
        if (sv != null)
        {
            Console.WriteLine("\n{0,-15}|{1,-25}|{2,10}", "Mã SV", "Họ tên", "Điểm TB");
            Console.WriteLine(new string('-', 54));
            Console.WriteLine($"{sv.MaSV,-15}|{sv.HoTen,-25}|{sv.DiemTB,10:F2}");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên.");
        }
    }

    static void XoaSinhVien()
    {
        Console.Write("Nhập MSSV cần xóa: ");
        string? maSV = Console.ReadLine();
        var sv = danhSachSV.Find(s => s.MaSV == maSV);
        if (sv != null)
        {
            danhSachSV.Remove(sv);
            Console.WriteLine("Đã xóa sinh viên.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên.");
        }
    }

    static void CapNhatSinhVien()
    {
        Console.Write("Nhập MSSV cần cập nhật: ");
        string? maSV = Console.ReadLine();
        var sv = danhSachSV.Find(s => s.MaSV == maSV);
        if (sv != null)
        {
            Console.Write("Nhập họ tên mới (bỏ trống nếu không đổi): ");
            string? hoTen = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(hoTen))
                sv.HoTen = hoTen;

            Console.Write("Nhập điểm trung bình mới (bỏ trống nếu không đổi): ");
            string? diemStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(diemStr))
            {
                try
                {
                    double diemTB = double.Parse(diemStr, CultureInfo.InvariantCulture);
                    if (diemTB >= 0 && diemTB <= 10)
                        sv.DiemTB = diemTB;
                    else
                        Console.WriteLine("Điểm trung bình phải từ 0 đến 10.");
                }
                catch
                {
                    Console.WriteLine("Điểm trung bình không hợp lệ.");
                }
            }
            Console.WriteLine("Cập nhật thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên.");
        }
    }
}