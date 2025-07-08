using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

class Program
{
    static List<SinhVien> danhSachSV = new List<SinhVien>();
    const string fileName = @"D:\test\data.txt";

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        TaiDuLieu();
        while (true)
        {
            Console.WriteLine("\n===== QUẢN LÝ DANH SÁCH SINH VIÊN =====");
            Console.WriteLine("1. Thêm mới sinh viên");
            Console.WriteLine("2. Hiển thị danh sách sinh viên");
            Console.WriteLine("3. Sắp xếp danh sách sinh viên theo điểm TB giảm dần");
            Console.WriteLine("4. Sắp xếp danh sách sinh viên theo họ tên (A-Z)");
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
                    SapXepTheoDiem();
                    break;
                case "4":
                    SapXepTheoTen();
                    break;
                case "0":
                    LuuDuLieu();
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        }
    }

    static void TaiDuLieu()
    {
        try
        {
            if (!File.Exists(fileName)) return;
            foreach (var line in File.ReadAllLines(fileName))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                danhSachSV.Add(SinhVien.FromCsv(line));
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Không tìm thấy file dữ liệu.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Lỗi đọc file: " + ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Lỗi định dạng dữ liệu trong file: " + ex.Message);
        }
    }

    static void LuuDuLieu()
    {
        try
        {
            var lines = new List<string>();
            foreach (var sv in danhSachSV)
            {
                lines.Add(sv.ToCsv());
            }
            File.WriteAllLines(fileName, lines);
        }
        catch (IOException ex)
        {
            Console.WriteLine("Lỗi ghi file: " + ex.Message);
        }
    }

    static void ThemMoiSinhVien()
    {
        Console.Write("Nhập mã số sinh viên: ");
        string? maSV = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(maSV) || danhSachSV.Exists(sv => sv.MaSV == maSV))
        {
            Console.WriteLine("Mã số sinh viên không hợp lệ hoặc đã tồn tại.");
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
            if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out diemTB) && diemTB >= 0 && diemTB <= 10)
                break;
            Console.WriteLine("Điểm trung bình không hợp lệ.");
        }
        danhSachSV.Add(new SinhVien(maSV, hoTen, diemTB));
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

    static void SapXepTheoDiem()
    {
        if (danhSachSV.Count == 0)
        {
            Console.WriteLine("Danh sách sinh viên rỗng.");
            return;
        }
        danhSachSV.Sort((a, b) => b.DiemTB.CompareTo(a.DiemTB));
        Console.WriteLine("Đã sắp xếp danh sách sinh viên theo điểm trung bình giảm dần:");
        HienThiDanhSach();
    }

    static void SapXepTheoTen()
    {
        if (danhSachSV.Count == 0)
        {
            Console.WriteLine("Danh sách sinh viên rỗng.");
            return;
        }
        danhSachSV.Sort((a, b) => string.Compare(a.HoTen, b.HoTen, StringComparison.CurrentCulture));
        Console.WriteLine("Đã sắp xếp danh sách sinh viên theo họ tên (A-Z):");
        HienThiDanhSach();
    }
}