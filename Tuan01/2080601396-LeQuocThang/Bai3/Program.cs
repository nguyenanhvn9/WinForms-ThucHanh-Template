using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class SinhVien
{
    public string MaSV { get; set; }
    public string HoTen { get; set; }
    public double DiemTB { get; set; }

    public SinhVien(string maSV, string hoTen, double diemTB)
    {
        MaSV = maSV;
        HoTen = hoTen;
        DiemTB = diemTB;
    }

    public override string ToString()
    {
        return $"{MaSV},{HoTen},{DiemTB}";
    }

    public static SinhVien FromCsv(string csvLine)
    {
        var parts = csvLine.Split(',');
        return new SinhVien(parts[0], parts[1], double.Parse(parts[2]));
    }

    public void HienThi()
    {
        Console.WriteLine($"Mã SV: {MaSV} | Họ tên: {HoTen} | Điểm TB: {DiemTB:F2}");
    }
}

class Program
{
    static List<SinhVien> danhSachSV = new List<SinhVien>();
    const string fileName = "data.txt";

    static void Main()
    {
        TaiDuLieu();

        while (true)
        {
            Console.WriteLine("\n===== MENU QUẢN LÝ SINH VIÊN =====");
            Console.WriteLine("1. Thêm mới sinh viên");
            Console.WriteLine("2. Hiển thị danh sách sinh viên");
            Console.WriteLine("3. Tìm kiếm sinh viên theo MSSV");
            Console.WriteLine("4. Sắp xếp danh sách sinh viên");
            Console.WriteLine("5. Liệt kê sinh viên điểm TB > 8.0 và họ là 'Nguyen'");
            Console.WriteLine("6. Thoát");
            Console.Write("Chọn chức năng (1-6): ");
            string luaChon = Console.ReadLine();

            switch (luaChon)
            {
                case "1":
                    ThemSinhVien();
                    break;
                case "2":
                    HienThiDanhSach();
                    break;
                case "3":
                    TimKiemSinhVien();
                    break;
                case "4":
                    SapXepDanhSach();
                    break;
                case "5":
                    LietKeSinhVienLinq();
                    break;
                case "6":
                    LuuDuLieu();
                    Console.WriteLine("Đã lưu dữ liệu và kết thúc chương trình.");
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        }
    }

    static void TaiDuLieu()
    {
        danhSachSV.Clear();
        if (!File.Exists(fileName))
            return;
        try
        {
            foreach (var line in File.ReadAllLines(fileName))
            {
                if (!string.IsNullOrWhiteSpace(line))
                    danhSachSV.Add(SinhVien.FromCsv(line));
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Không tìm thấy file dữ liệu.");
        }
        catch (IOException)
        {
            Console.WriteLine("Lỗi đọc file dữ liệu.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Lỗi định dạng dữ liệu trong file.");
        }
    }

    static void LuuDuLieu()
    {
        try
        {
            var lines = danhSachSV.Select(sv => sv.ToString()).ToList();
            File.WriteAllLines(fileName, lines);
        }
        catch (IOException)
        {
            Console.WriteLine("Lỗi ghi file dữ liệu.");
        }
    }

    static void ThemSinhVien()
    {
        Console.Write("Nhập mã sinh viên: ");
        string maSV = Console.ReadLine() ?? "";

        Console.Write("Nhập họ tên: ");
        string hoTen = Console.ReadLine() ?? "";

        Console.Write("Nhập điểm trung bình: ");
        double diemTB;
        while (!double.TryParse(Console.ReadLine(), out diemTB))
        {
            Console.Write("Điểm không hợp lệ, nhập lại: ");
        }

        danhSachSV.Add(new SinhVien(maSV, hoTen, diemTB));
        Console.WriteLine("Đã thêm sinh viên thành công!");
    }

    static void HienThiDanhSach()
    {
        Console.WriteLine("\n--- Danh sách sinh viên ---");
        if (danhSachSV.Count == 0)
        {
            Console.WriteLine("Danh sách rỗng.");
            return;
        }
        foreach (var sv in danhSachSV)
        {
            sv.HienThi();
        }
    }

    static void TimKiemSinhVien()
    {
        Console.Write("Nhập mã sinh viên cần tìm: ");
        string maSV = Console.ReadLine() ?? "";
        var sv = danhSachSV.Find(s => s.MaSV == maSV);
        if (sv != null)
        {
            Console.WriteLine("Thông tin sinh viên:");
            sv.HienThi();
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên với mã này.");
        }
    }

    static void SapXepDanhSach()
    {
        Console.WriteLine("1. Sắp xếp theo điểm trung bình giảm dần");
        Console.WriteLine("2. Sắp xếp theo họ tên (A-Z)");
        Console.Write("Chọn kiểu sắp xếp (1-2): ");
        string kieu = Console.ReadLine();
        if (kieu == "1")
            danhSachSV = danhSachSV.OrderByDescending(sv => sv.DiemTB).ToList();
        else if (kieu == "2")
            danhSachSV = danhSachSV.OrderBy(sv => sv.HoTen).ToList();
        else
        {
            Console.WriteLine("Lựa chọn không hợp lệ.");
            return;
        }
        Console.WriteLine("Đã sắp xếp danh sách.");
        HienThiDanhSach();
    }

    static void LietKeSinhVienLinq()
    {
        var ketQua = danhSachSV
            .Where(sv => sv.DiemTB > 8.0 && sv.HoTen.Split(' ')[0].Equals("Nguyen", StringComparison.OrdinalIgnoreCase))
            .ToList();
        if (ketQua.Count == 0)
        {
            Console.WriteLine("Không có sinh viên nào thỏa điều kiện.");
            return;
        }
        Console.WriteLine("Các sinh viên có điểm TB > 8.0 và họ là 'Nguyen':");
        foreach (var sv in ketQua)
            sv.HienThi();
    }
}