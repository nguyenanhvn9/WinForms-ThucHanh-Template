using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class SinhVien
{
    public string MaSV { get; set; }
    public string HoTen { get; set; }
    public double DiemTB { get; set; }

    public void HienThiThongTin()
    {
        Console.WriteLine($"| {MaSV,-10} | {HoTen,-25} | {DiemTB,-10:F2} |");
    }
}

class Program
{
    static List<SinhVien> danhSachSinhVien = new List<SinhVien>();
    const string filePath = "data.txt";

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        TaiDuLieu();

        while (true)
        {
            HienThiMenu();
            Console.Write("Vui lòng chọn chức năng: ");
            string choice = Console.ReadLine();

            switch (choice)
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
                    LuuDuLieu();
                    Console.WriteLine("Dữ liệu đã được lưu. Đã thoát chương trình.");
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
            Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }
    }

    static void TaiDuLieu()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        SinhVien sv = new SinhVien
                        {
                            MaSV = parts[0],
                            HoTen = parts[1],
                            DiemTB = double.Parse(parts[2])
                        };
                        danhSachSinhVien.Add(sv);
                    }
                }
                Console.WriteLine($"Đã tải thành công {danhSachSinhVien.Count} sinh viên từ file {filePath}.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi tải dữ liệu: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void LuuDuLieu()
    {
        try
        {
            List<string> lines = new List<string>();
            foreach (var sv in danhSachSinhVien)
            {
                string line = $"{sv.MaSV},{sv.HoTen},{sv.DiemTB}";
                lines.Add(line);
            }
            File.WriteAllLines(filePath, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi lưu dữ liệu: {ex.Message}");
        }
    }

    static void HienThiMenu()
    {
        Console.Clear();
        Console.WriteLine("--- HỆ THỐNG QUẢN LÝ SINH VIÊN (CÓ LƯU FILE) ---");
        Console.WriteLine("1. Thêm mới một sinh viên.");
        Console.WriteLine("2. Hiển thị danh sách sinh viên.");
        Console.WriteLine("3. Tìm kiếm sinh viên theo MSSV.");
        Console.WriteLine("4. Lưu và Thoát.");
        Console.WriteLine("-------------------------------------------------");
    }

    static void ThemMoiSinhVien()
    {
        Console.WriteLine("\n--- THÊM MỚI SINH VIÊN ---");
        string maSV;
        while (true)
        {
            Console.Write("Nhập Mã số sinh viên (MSSV): ");
            maSV = Console.ReadLine();
            if (danhSachSinhVien.Any(sv => sv.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Lỗi: MSSV này đã tồn tại. Vui lòng nhập mã khác.");
            }
            else { break; }
        }
        Console.Write("Nhập Họ và tên: ");
        string hoTen = Console.ReadLine();
        double diemTB;
        while (true)
        {
            Console.Write("Nhập Điểm trung bình: ");
            if (double.TryParse(Console.ReadLine(), out diemTB) && diemTB >= 0 && diemTB <= 10)
            {
                break;
            }
            else { Console.WriteLine("Lỗi: Vui lòng nhập điểm hợp lệ (số từ 0-10)."); }
        }
        SinhVien svMoi = new SinhVien { MaSV = maSV, HoTen = hoTen, DiemTB = diemTB };
        danhSachSinhVien.Add(svMoi);
        Console.WriteLine("=> Đã thêm sinh viên thành công!");
    }

    static void HienThiDanhSach()
    {
        Console.WriteLine("\n--- DANH SÁCH SINH VIÊN ---");
        if (danhSachSinhVien.Count == 0)
        {
            Console.WriteLine("Danh sách trống.");
            return;
        }
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"| {"MSSV",-10} | {"Họ và Tên",-25} | {"Điểm TB",-10} |");
        Console.WriteLine("---------------------------------------------------");
        foreach (var sv in danhSachSinhVien)
        {
            sv.HienThiThongTin();
        }
        Console.WriteLine("---------------------------------------------------");
    }

    static void TimKiemSinhVien()
    {
        Console.WriteLine("\n--- TÌM KIẾM SINH VIÊN ---");
        Console.Write("Nhập MSSV cần tìm: ");
        string mssvCanTim = Console.ReadLine();
        SinhVien svTimThay = danhSachSinhVien.FirstOrDefault(sv => sv.MaSV.Equals(mssvCanTim, StringComparison.OrdinalIgnoreCase));
        if (svTimThay != null)
        {
            Console.WriteLine("=> Đã tìm thấy sinh viên:");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"| {"MSSV",-10} | {"Họ và Tên",-25} | {"Điểm TB",-10} |");
            Console.WriteLine("---------------------------------------------------");
            svTimThay.HienThiThongTin();
            Console.WriteLine("---------------------------------------------------");
        }
        else
        {
            Console.WriteLine($"=> Không tìm thấy sinh viên nào có MSSV là '{mssvCanTim}'.");
        }
    }
}
