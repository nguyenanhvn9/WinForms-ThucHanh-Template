using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

class SinhVien
{
    public string MaSV { get; set; }
    public string HoTen { get; set; }
    public double DiemTB { get; set; }

    public override string ToString()
    {
        return string.Format("{0,-10} | {1,-25} | {2,6:F2}", MaSV, HoTen, DiemTB);
    }
}

class Program
{
    static List<SinhVien> danhSach = new List<SinhVien>();
    const string fileName = "data.txt";

    static void Main()
    {
        TaiDuLieu();
        while (true)
        {
            Console.WriteLine("\n===== QUAN LY DANH SACH SINH VIEN =====");
            Console.WriteLine("1. Them moi mot sinh vien");
            Console.WriteLine("2. Hien thi danh sach sinh vien");
            Console.WriteLine("3. Tim kiem sinh vien theo MSSV");
            Console.WriteLine("4. Xoa sinh vien theo MSSV");
            Console.WriteLine("5. Cap nhat thong tin sinh vien theo MSSV");
            Console.WriteLine("6. Sap xep danh sach sinh vien");
            Console.WriteLine("7. Thoat");
            Console.Write("Chon chuc nang (1-7): ");
            string chon = Console.ReadLine();

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
                case "6":
                    SapXepDanhSach();
                    break;
                case "7":
                    LuuDuLieu();
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }
        }
    }

    static void TaiDuLieu()
    {
        if (!File.Exists(fileName))
            return;
        try
        {
            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 3 && double.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double diem))
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
        catch (FileNotFoundException)
        {
            Console.WriteLine("Khong tim thay file du lieu.");
        }
        catch (IOException)
        {
            Console.WriteLine("Loi doc file du lieu.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Du lieu trong file khong dung dinh dang.");
        }
    }

    static void LuuDuLieu()
    {
        try
        {
            var lines = danhSach.Select(sv => $"{sv.MaSV},{sv.HoTen},{sv.DiemTB.ToString(CultureInfo.InvariantCulture)}").ToList();
            File.WriteAllLines(fileName, lines);
        }
        catch (IOException)
        {
            Console.WriteLine("Loi ghi file du lieu.");
        }
    }

    static void ThemMoiSinhVien()
    {
        Console.Write("Nhap ma so sinh vien: ");
        string maSV = Console.ReadLine();
        if (danhSach.Any(sv => sv.MaSV == maSV))
        {
            Console.WriteLine("Ma so sinh vien da ton tai!");
            return;
        }
        Console.Write("Nhap ho ten: ");
        string hoTen = Console.ReadLine();
        Console.Write("Nhap diem trung binh: ");
        if (!double.TryParse(Console.ReadLine(), out double diemTB))
        {
            Console.WriteLine("Diem trung binh khong hop le!");
            return;
        }
        danhSach.Add(new SinhVien { MaSV = maSV, HoTen = hoTen, DiemTB = diemTB });
        Console.WriteLine("Them sinh vien thanh cong!");
    }

    static void HienThiDanhSach()
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine("Danh sach sinh vien rong.");
            return;
        }
        Console.WriteLine("\n{0,-10} | {1,-25} | {2,6}", "MSSV", "Ho ten", "DiemTB");
        Console.WriteLine(new string('-', 47));
        foreach (var sv in danhSach)
        {
            Console.WriteLine(sv);
        }
    }

    static void TimKiemSinhVien()
    {
        Console.Write("Nhap MSSV can tim: ");
        string maSV = Console.ReadLine();
        var sv = danhSach.FirstOrDefault(s => s.MaSV == maSV);
        if (sv != null)
        {
            Console.WriteLine("\nThong tin sinh vien:");
            Console.WriteLine("{0,-10} | {1,-25} | {2,6}", "MSSV", "Ho ten", "DiemTB");
            Console.WriteLine(new string('-', 47));
            Console.WriteLine(sv);
        }
        else
        {
            Console.WriteLine("Khong tim thay sinh vien voi MSSV nay.");
        }
    }

    static void XoaSinhVien()
    {
        Console.Write("Nhap MSSV can xoa: ");
        string maSV = Console.ReadLine();
        var sv = danhSach.FirstOrDefault(s => s.MaSV == maSV);
        if (sv != null)
        {
            danhSach.Remove(sv);
            Console.WriteLine("Da xoa sinh vien thanh cong.");
        }
        else
        {
            Console.WriteLine("Khong tim thay sinh vien voi MSSV nay.");
        }
    }

    static void CapNhatSinhVien()
    {
        Console.Write("Nhap MSSV can cap nhat: ");
        string maSV = Console.ReadLine();
        var sv = danhSach.FirstOrDefault(s => s.MaSV == maSV);
        if (sv != null)
        {
            Console.Write("Nhap ho ten moi (bo trong neu khong doi): ");
            string hoTen = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(hoTen))
                sv.HoTen = hoTen;

            Console.Write("Nhap diem trung binh moi (bo trong neu khong doi): ");
            string diemStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(diemStr) && double.TryParse(diemStr, out double diemTB))
                sv.DiemTB = diemTB;

            Console.WriteLine("Cap nhat thong tin thanh cong.");
        }
        else
        {
            Console.WriteLine("Khong tim thay sinh vien voi MSSV nay.");
        }
    }

    static void SapXepDanhSach()
    {
        danhSach = danhSach
            .OrderByDescending(sv => sv.DiemTB)
            .ThenBy(sv => BoDauTiengViet(sv.HoTen))
            .ToList();
        Console.WriteLine("Da sap xep danh sach sinh vien theo diem trung binh giam dan va ten.");
        HienThiDanhSach();
    }

    // Ham bo dau tieng Viet de sap xep ten
    static string BoDauTiengViet(string input)
    {
        string[] viet = new string[] { "aAeEoOuUiIdDyY", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ", "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ", "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ", "úùụủũưứừựửữ", "ÚÙỤỦŨƯỨỪỰỬỮ", "íìịỉĩ", "ÍÌỊỈĨ", "đ", "Đ", "ýỳỵỷỹ", "ÝỲỴỶỸ" };
        string[] lat = new string[] { "aAeEoOuUiIdDyY", "a", "A", "e", "E", "o", "O", "u", "U", "i", "I", "d", "D", "y", "Y" };
        for (int i = 1; i < viet.Length; i++)
        {
            foreach (var c in viet[i])
                input = input.Replace(c, lat[i][0]);
        }
        return input;
    }
}

