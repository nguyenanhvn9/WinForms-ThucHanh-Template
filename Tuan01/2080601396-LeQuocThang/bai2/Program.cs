using System;
using System.Collections.Generic;

// Định nghĩa lớp SinhVien
class SinhVien
{
    private string maSV;
    private string hoTen;
    private double diemTB;

    public string MaSV
    {
        get => maSV;
        set => maSV = value;
    }

    public string HoTen
    {
        get => hoTen;
        set => hoTen = value;
    }

    public double DiemTB
    {
        get => diemTB;
        set => diemTB = value;
    }

    public SinhVien(string maSV, string hoTen, double diemTB)
    {
        MaSV = maSV;
        HoTen = hoTen;
        DiemTB = diemTB;
    }

    public void HienThi()
    {
        Console.WriteLine($"Mã SV: {MaSV} | Họ tên: {HoTen} | Điểm TB: {DiemTB:F2}");
    }
}

class Program
{
    static List<SinhVien> danhSachSV = new List<SinhVien>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== MENU QUẢN LÝ SINH VIÊN =====");
            Console.WriteLine("1. Thêm mới sinh viên");
            Console.WriteLine("2. Hiển thị danh sách sinh viên");
            Console.WriteLine("3. Tìm kiếm sinh viên theo MSSV");
            Console.WriteLine("4. Thoát");
            Console.Write("Chọn chức năng (1-4): ");
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
                    Console.WriteLine("Kết thúc chương trình.");
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
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
}