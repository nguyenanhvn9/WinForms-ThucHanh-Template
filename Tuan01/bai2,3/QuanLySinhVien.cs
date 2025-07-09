// File: QuanLySinhVien.cs
using System;
using System.Collections.Generic;
using System.IO;

public class QuanLySinhVien
{
    private List<SinhVien> danhSach = new List<SinhVien>();
    private const string FILE_PATH = "data.txt";

    public void Run()
    {
        TaiDuLieu();

        while (true)
        {
            Console.WriteLine("\n====== MENU ======");
            Console.WriteLine("1. Thêm mới sinh viên");
            Console.WriteLine("2. Hiển thị danh sách");
            Console.WriteLine("3. Tìm kiếm theo MSSV");
            Console.WriteLine("4. Thoát và lưu file");
            Console.Write("Chọn chức năng: ");
            string chon = Console.ReadLine();

            switch (chon)
            {
                case "1": ThemMoi(); break;
                case "2": HienThi(); break;
                case "3": TimKiem(); break;
                case "4": LuuDuLieu(); return;
                default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
            }
        }
    }

    private void ThemMoi()
    {
        Console.Write("Nhập mã SV: ");
        string ma = Console.ReadLine();
        if (danhSach.Exists(sv => sv.MaSV == ma))
        {
            Console.WriteLine("❌ Mã sinh viên đã tồn tại!");
            return;
        }

        Console.Write("Nhập họ tên: ");
        string ten = Console.ReadLine();
        Console.Write("Nhập điểm TB: ");
        double dtb;
        while (!double.TryParse(Console.ReadLine(), out dtb) || dtb < 0 || dtb > 10)
        {
            Console.Write("❌ Điểm không hợp lệ. Nhập lại (0 - 10): ");
        }

        danhSach.Add(new SinhVien { MaSV = ma, HoTen = ten, DiemTB = dtb });
        Console.WriteLine("✅ Đã thêm sinh viên thành công!");
    }

    private void HienThi()
    {
        Console.WriteLine("\nDANH SÁCH SINH VIÊN:");
        foreach (var sv in danhSach)
        {
            Console.WriteLine($"{sv.MaSV}, {sv.HoTen}, {sv.DiemTB:F2}");
        }
    }

    private void TimKiem()
    {
        Console.Write("Nhập MSSV cần tìm: ");
        string mssv = Console.ReadLine();
        var sv = danhSach.Find(s => s.MaSV == mssv);
        if (sv != null)
            Console.WriteLine($"✔️ Tìm thấy: {sv.MaSV}, {sv.HoTen}, {sv.DiemTB:F2}");
        else
            Console.WriteLine("❌ Không tìm thấy sinh viên.");
    }

    private void TaiDuLieu()
    {
        if (!File.Exists(FILE_PATH)) return;

        string[] lines = File.ReadAllLines(FILE_PATH);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length == 3 && double.TryParse(parts[2], out double diem))
            {
                danhSach.Add(new SinhVien
                {
                    MaSV = parts[0],
                    HoTen = parts[1],
                    DiemTB = diem
                });
            }
        }
    }

    private void LuuDuLieu()
    {
        List<string> lines = new List<string>();
        foreach (var sv in danhSach)
        {
            lines.Add($"{sv.MaSV},{sv.HoTen},{sv.DiemTB}");
        }
        File.WriteAllLines(FILE_PATH, lines);
        Console.WriteLine("💾 Đã lưu dữ liệu và thoát chương trình.");
    }
}
