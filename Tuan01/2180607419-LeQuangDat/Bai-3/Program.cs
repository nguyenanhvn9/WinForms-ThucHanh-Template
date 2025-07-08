using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class SinhVien
{
    private string maSV;
    private string hoTen;
    private double diemTB;

    public string MaSV { get => maSV; set => maSV = value; }
    public string HoTen { get => hoTen; set => hoTen = value; }
    public double DiemTB { get => diemTB; set => diemTB = value; }

    public void HienThiThongTin()
    {
        Console.WriteLine($"| {MaSV,-10} | {HoTen,-25} | {DiemTB,8:F2} |");
    }

    public string ToCSV()
    {
        return $"{MaSV},{HoTen},{DiemTB}";
    }

    public static SinhVien FromCSV(string csvLine)
    {
        var parts = csvLine.Split(',');
        if (parts.Length != 3)
            throw new FormatException("Dòng CSV không hợp lệ");

        return new SinhVien
        {
            MaSV = parts[0],
            HoTen = parts[1],
            DiemTB = double.Parse(parts[2], CultureInfo.InvariantCulture)
        };
    }
}

class QuanLySinhVien
{
    static List<SinhVien> danhSach = new List<SinhVien>();
    const string FilePath = "data.txt";

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        TaiDuLieu();

        while (true)
        {
            Console.WriteLine("\n=== MENU QUẢN LÝ SINH VIÊN ===");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Hiển thị danh sách");
            Console.WriteLine("3. Tìm kiếm theo MSSV");
            Console.WriteLine("4. Sắp xếp theo điểm TB giảm dần");
            Console.WriteLine("5. Sắp xếp theo họ tên (A-Z)");
            Console.WriteLine("6. Liệt kê sinh viên họ 'Nguyen' và điểm > 8.0");
            Console.WriteLine("7. Thoát");
            Console.Write("Chọn chức năng (1-7): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": ThemMoiSinhVien(); break;
                case "2": HienThiDanhSach(); break;
                case "3": TimKiemSinhVien(); break;
                case "4": SapXepTheoDiemTB(); break;
                case "5": SapXepTheoHoTen(); break;
                case "6": LietKeSinhVienNguyen8(); break;
                case "7":
                    LuuDuLieu();
                    return;
                default:
                    Console.WriteLine(">> Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }

    static void TaiDuLieu()
    {
        if (!File.Exists(FilePath)) return;

        try
        {
            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                try
                {
                    danhSach.Add(SinhVien.FromCSV(line));
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($">> Bỏ qua dòng lỗi: {line} ({fe.Message})");
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($">> Lỗi đọc file: {ex.Message}");
        }
    }

    static void LuuDuLieu()
    {
        try
        {
            List<string> lines = new List<string>();
            foreach (var sv in danhSach)
            {
                lines.Add(sv.ToCSV());
            }
            File.WriteAllLines(FilePath, lines);
        }
        catch (IOException ex)
        {
            Console.WriteLine($">> Lỗi ghi file: {ex.Message}");
        }
    }

    static void ThemMoiSinhVien()
    {
        Console.Write("- Nhập MSSV: ");
        string ma = Console.ReadLine();

        if (danhSach.Any(sv => sv.MaSV == ma))
        {
            Console.WriteLine(">> MSSV đã tồn tại, không thể thêm.");
            return;
        }

        Console.Write("- Nhập họ tên: ");
        string ten = Console.ReadLine();

        Console.Write("- Nhập điểm TB: ");
        if (!double.TryParse(Console.ReadLine(), out double diem) || diem < 0 || diem > 10)
        {
            Console.WriteLine(">> Điểm không hợp lệ. Nhập lại trong khoảng 0-10.");
            return;
        }

        danhSach.Add(new SinhVien { MaSV = ma, HoTen = ten, DiemTB = diem });
        Console.WriteLine(">> Thêm sinh viên thành công!");
    }

    static void HienThiDanhSach()
    {
        XuatDanhSach(danhSach);
    }

    static void TimKiemSinhVien()
    {
        Console.Write("- Nhập MSSV cần tìm: ");
        string ma = Console.ReadLine();

        var sv = danhSach.FirstOrDefault(s => s.MaSV == ma);
        if (sv != null)
        {
            Console.WriteLine("\n| {0,-10} | {1,-25} | {2,8} |", "MSSV", "Họ Tên", "Điểm TB");
            Console.WriteLine(new string('-', 50));
            sv.HienThiThongTin();
        }
        else
        {
            Console.WriteLine(">> Không tìm thấy sinh viên với MSSV đã nhập.");
        }
    }

    static void SapXepTheoDiemTB()
    {
        var danhSachSapXep = danhSach.OrderByDescending(sv => sv.DiemTB).ToList();
        Console.WriteLine("\n>> Danh sách sắp xếp theo điểm TB giảm dần:");
        XuatDanhSach(danhSachSapXep);
    }

    static void SapXepTheoHoTen()
    {
        var danhSachSapXep = danhSach.OrderBy(sv => sv.HoTen).ToList();
        Console.WriteLine("\n>> Danh sách sắp xếp theo họ tên (A-Z):");
        XuatDanhSach(danhSachSapXep);
    }

    static void LietKeSinhVienNguyen8()
    {
        var ketQua = danhSach
            .Where(sv => sv.DiemTB > 8.0 && sv.HoTen.StartsWith("Nguyen", StringComparison.OrdinalIgnoreCase))
            .ToList();

        Console.WriteLine("\n>> Sinh viên họ 'Nguyen' và điểm TB > 8.0:");
        XuatDanhSach(ketQua);
    }

    static void XuatDanhSach(List<SinhVien> ds)
    {
        if (ds.Count == 0)
        {
            Console.WriteLine(">> Không có sinh viên nào.");
            return;
        }

        Console.WriteLine("\n| {0,-10} | {1,-25} | {2,8} |", "MSSV", "Họ Tên", "Điểm TB");
        Console.WriteLine(new string('-', 50));
        foreach (var sv in ds)
        {
            sv.HienThiThongTin();
        }
    }
}