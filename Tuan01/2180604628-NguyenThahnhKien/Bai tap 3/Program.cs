using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static List<SinhVien> danhSach = new List<SinhVien>();
    static string filePath = "data.txt";

    static void Main()
    {
        TaiDuLieu();

        while (true)
        {
            Console.WriteLine("\n=== MENU CHUONG TRINH QUAN LY SINH VIEN ===");
            Console.WriteLine("1. Them moi sinh vien");
            Console.WriteLine("2. Hien thi danh sach sinh vien");
            Console.WriteLine("3. Tim kiem sinh vien theo MSSV");
            Console.WriteLine("4. Xoa sinh vien theo MSSV");
            Console.WriteLine("5. Cap nhat sinh vien theo MSSV");
            Console.WriteLine("6. Sap xep danh sach theo diem TB (giam dan)");
            Console.WriteLine("7. Thoat");
            Console.Write("Nhap lua chon (1-7): ");
            string chon = Console.ReadLine();

            switch (chon)
            {
                case "1": ThemMoiSinhVien(); break;
                case "2": HienThiDanhSach(); break;
                case "3": TimKiemSinhVien(); break;
                case "4": XoaSinhVien(); break;
                case "5": CapNhatSinhVien(); break;
                case "6": SapXepTheoDiemTB(); break;
                case "7":
                    LuuDuLieu();
                    Console.WriteLine("Da luu du lieu. Tam biet!");
                    return;
                default: Console.WriteLine("Lua chon khong hop le."); break;
            }
        }
    }

    static void TaiDuLieu()
    {
        try
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    danhSach.Add(SinhVien.FromCSV(line));
                }
                Console.WriteLine($"🔄 Da tai {danhSach.Count} sinh vien tu file.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("⚠️ File khong ton tai. Se tao moi sau khi luu.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"❌ Loi khi doc file: {e.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("❌ Loi dinh dang file. Kiem tra lai noi dung.");
        }
    }

    static void LuuDuLieu()
    {
        try
        {
            List<string> lines = danhSach.Select(sv => sv.ToCSV()).ToList();
            File.WriteAllLines(filePath, lines);
        }
        catch (IOException e)
        {
            Console.WriteLine($"❌ Loi khi ghi file: {e.Message}");
        }
    }

    static void ThemMoiSinhVien()
    {
        Console.Write("Nhap MSSV: ");
        string ma = Console.ReadLine();
        if (danhSach.Any(sv => sv.MaSV == ma))
        {
            Console.WriteLine("❌ MSSV da ton tai.");
            return;
        }

        Console.Write("Nhap ho ten: ");
        string ten = Console.ReadLine();

        Console.Write("Nhap diem TB: ");
        if (!double.TryParse(Console.ReadLine(), out double diem) || diem < 0 || diem > 10)
        {
            Console.WriteLine("❌ Diem khong hop le.");
            return;
        }

        danhSach.Add(new SinhVien { MaSV = ma, HoTen = ten, DiemTB = diem });
        Console.WriteLine("✅ Da them sinh vien.");
    }

    static void HienThiDanhSach()
    {
        Console.WriteLine("\n| {0,-10} | {1,-25} | {2,8} |", "MaSV", "Ho ten", "Diem TB");
        Console.WriteLine(new string('-', 50));
        foreach (var sv in danhSach)
        {
            sv.HienThi();
        }
    }

    static void TimKiemSinhVien()
    {
        Console.Write("Nhap MSSV can tim: ");
        string ma = Console.ReadLine();
        var sv = danhSach.FirstOrDefault(s => s.MaSV == ma);
        if (sv != null)
        {
            Console.WriteLine("✅ Tim thay:");
            Console.WriteLine("| MaSV       | Ho ten                  | Diem TB |");
            sv.HienThi();
        }
        else
        {
            Console.WriteLine("❌ Khong tim thay.");
        }
    }

    static void XoaSinhVien()
    {
        Console.Write("Nhap MSSV can xoa: ");
        string ma = Console.ReadLine();
        int count = danhSach.RemoveAll(sv => sv.MaSV == ma);
        Console.WriteLine(count > 0 ? "✅ Da xoa." : "❌ Khong tim thay.");
    }

    static void CapNhatSinhVien()
    {
        Console.Write("Nhap MSSV can cap nhat: ");
        string ma = Console.ReadLine();
        var sv = danhSach.FirstOrDefault(s => s.MaSV == ma);
        if (sv != null)
        {
            Console.Write("Nhap ten moi (bo qua neu giu nguyen): ");
            string ten = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ten)) sv.HoTen = ten;

            Console.Write("Nhap diem moi (bo qua neu giu nguyen): ");
            string diemStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(diemStr) && double.TryParse(diemStr, out double diemMoi))
            {
                if (diemMoi >= 0 && diemMoi <= 10)
                    sv.DiemTB = diemMoi;
            }

            Console.WriteLine("✅ Da cap nhat.");
        }
        else
        {
            Console.WriteLine("❌ Khong tim thay.");
        }
    }

    static void SapXepTheoDiemTB()
    {
        var sapXep = danhSach.OrderByDescending(sv => sv.DiemTB).ToList();
        Console.WriteLine("\n| {0,-10} | {1,-25} | {2,8} |", "MaSV", "Ho ten", "Diem TB");
        Console.WriteLine(new string('-', 50));
        foreach (var sv in sapXep)
        {
            sv.HienThi();
        }
    }
}
