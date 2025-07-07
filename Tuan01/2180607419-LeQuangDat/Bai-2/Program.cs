using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


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
}

class QuanLySinhVien
{
    static List<SinhVien> danhSach = new List<SinhVien>();

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\n=== MENU QUẢN LÝ SINH VIÊN ===");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Hiển thị danh sách");
            Console.WriteLine("3. Tìm kiếm theo MSSV");
            Console.WriteLine("4. Thoát");
            Console.Write("Chọn chức năng (1-4): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": ThemMoiSinhVien(); break;
                case "2": HienThiDanhSach(); break;
                case "3": TimKiemSinhVien(); break;
                case "4": return;
                default: Console.WriteLine(">> Lựa chọn không hợp lệ."); break;
            }
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
        if (danhSach.Count == 0)
        {
            Console.WriteLine(">> Danh sách rỗng.");
            return;
        }

        Console.WriteLine("\n| {0,-10} | {1,-25} | {2,8} |", "MSSV", "Họ Tên", "Điểm TB");
        Console.WriteLine(new string('-', 50));
        foreach (var sv in danhSach)
        {
            sv.HienThiThongTin();
        }
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
}