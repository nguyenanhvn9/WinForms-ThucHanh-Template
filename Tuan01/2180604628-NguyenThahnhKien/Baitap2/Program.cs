class Program


{
    static List<SinhVien> danhSach = new List<SinhVien>();

    static void Main()
    {
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
                    SapXepTheoDiemTB();
                    break;
                case "7":
                    Console.WriteLine("Tam biet!");
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }
        }
    }

    static void ThemMoiSinhVien()
    {
        Console.Write("Nhap ma sinh vien: ");
        string ma = Console.ReadLine();

        // Kiem tra trung MSSV
        if (danhSach.Exists(sv => sv.MaSV == ma))
        {
            Console.WriteLine("❌ Ma sinh vien da ton tai.");
            return;
        }

        Console.Write("Nhap ho ten: ");
        string ten = Console.ReadLine();

        double diem;
        while (true)
        {
            Console.Write("Nhap diem trung binh: ");
            if (double.TryParse(Console.ReadLine(), out diem) && diem >= 0 && diem <= 10)
                break;
            Console.WriteLine("❌ Diem khong hop le. Nhap lai (0-10).");
        }

        danhSach.Add(new SinhVien { MaSV = ma, HoTen = ten, DiemTB = diem });
        Console.WriteLine("✅ Da them sinh vien thanh cong.");
    }

    static void HienThiDanhSach()
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine("Danh sach rong.");
            return;
        }

        Console.WriteLine("\n| {0,-10} | {1,-25} | {2,8} |", "MaSV", "Ho ten", "Diem TB");
        Console.WriteLine(new string('-', 50));

        foreach (var sv in danhSach)
        {
            sv.HienThi();
        }
    }

    static void TimKiemSinhVien()
    {
        Console.Write("Nhap ma sinh vien can tim: ");
        string ma = Console.ReadLine();

        var sv = danhSach.Find(s => s.MaSV == ma);
        if (sv != null)
        {
            Console.WriteLine("\n| {0,-10} | {1,-25} | {2,8} |", "MaSV", "Ho ten", "Diem TB");
            Console.WriteLine(new string('-', 50));
            sv.HienThi();
        }
        else
        {
            Console.WriteLine("❌ Khong tim thay sinh vien co ma: " + ma);
        }
    }
    static void XoaSinhVien()
    {
        Console.Write("Nhap MSSV can xoa: ");
        string ma = Console.ReadLine();

        int soLuongXoa = danhSach.RemoveAll(sv => sv.MaSV == ma);
        if (soLuongXoa > 0)
            Console.WriteLine("✅ Da xoa sinh vien co MSSV: " + ma);
        else
            Console.WriteLine("❌ Khong tim thay sinh vien co MSSV: " + ma);
    }
    static void CapNhatSinhVien()
    {
        Console.Write("Nhap MSSV can cap nhat: ");
        string ma = Console.ReadLine();

        var sv = danhSach.FirstOrDefault(s => s.MaSV == ma);
        if (sv != null)
        {
            Console.Write("Nhap ho ten moi (de trong neu khong doi): ");
            string tenMoi = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(tenMoi))
                sv.HoTen = tenMoi;

            Console.Write("Nhap diem TB moi (de trong neu khong doi): ");
            string diemStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(diemStr) && double.TryParse(diemStr, out double diemMoi))
            {
                if (diemMoi >= 0 && diemMoi <= 10)
                    sv.DiemTB = diemMoi;
                else
                    Console.WriteLine("⚠️ Diem khong hop le (0-10), giu nguyen diem cu.");
            }

            Console.WriteLine("✅ Cap nhat thanh cong.");
        }
        else
        {
            Console.WriteLine("❌ Khong tim thay sinh vien co MSSV: " + ma);
        }
    }

    static void SapXepTheoDiemTB()
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine("Danh sach rong.");
            return;
        }

        var sapXep = danhSach.OrderByDescending(sv => sv.DiemTB).ToList();

        Console.WriteLine("\n| {0,-10} | {1,-25} | {2,8} |", "MaSV", "Ho ten", "Diem TB");
        Console.WriteLine(new string('-', 50));
        foreach (var sv in sapXep)
        {
            sv.HienThi();
        }
    }

}
