using Bai2;

Console.WriteLine("HE THONG QUAN LY SINH VIEN");
Console.WriteLine("Chao mung ban ");
bool isContinue = true;
List<SinhVien> danhSachSinhVien = new List<SinhVien>();
while (isContinue)
{
    int choice = -1;
    while (choice != 0)
    {
        ShowMenu();
        choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                themSinhVien();
                break;
            case 2:
                Console.WriteLine("Danh sach sinh vien hien tai: ");
                Console.WriteLine(string.Format("{0,-10} | {1,-25} | {2,-5}", "Ma SV", "Ho Ten", "Diem TB"));
                hienThiSinhVien();
                break;
            case 3:
                Console.Write("Nhap ma sinh vien can tim: ");
                string maSV = Console.ReadLine();
                timKiemSinhVien(maSV);
                break;
            case 4:
                Console.Write("Nhap ma sinh vien can xoa: ");
                string maSVToDelete = Console.ReadLine();
                xoaSinhVien(maSVToDelete);
                break;
            case 5:
                Console.Write("Nhap ma sinh vien can cap nhat: ");
                string maSVToUpdate = Console.ReadLine();
                capNhatSinhVien(maSVToUpdate);
                break;
            case 6:
                isContinue = false;
                Console.WriteLine("Cam on ban da su dung chuong trinh. Hen gap lai!");
                break;
            default:
                Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                break;
        }
    }
}

void ShowMenu()
{
    //Console.WriteLine("Vui long chon mot trong cac lua chon sau: ");
    Console.WriteLine("1. Them moi 1 Sinh vien ");
    Console.WriteLine("2. Hien thi danh sach Sinh vien ");
    Console.WriteLine("3. Tim kiem Sinh vien theo MSSV");
    Console.WriteLine("4. Xoa Sinh vien theo MSSV");
    Console.WriteLine("5. Cap nhat thong tin Sinh vien theo MSSV");
    Console.WriteLine("6. Thoat chuong trinh ");
    Console.Write("Nhap lua chon cua ban: ");
}

void themSinhVien()
{
    SinhVien sv = new SinhVien();
    sv.addSinhVien();
    bool exists = danhSachSinhVien.Any(s => s.getMaSV == sv.getMaSV);
    if (!exists)
    {
        danhSachSinhVien.Add(sv);
        Console.WriteLine("Da them moi sinh vien thanh cong.");
    }
    else
    {
        Console.WriteLine("Sinh vien voi ma da ton tai. Them moi khong thanh cong.");
        return;
    }
}

void hienThiSinhVien()
{
    foreach (var sv in danhSachSinhVien)
    {
        sv.hienThiSinhVien();
    }
}

void timKiemSinhVien(string maSV)
{
    SinhVien foundSV = danhSachSinhVien.FirstOrDefault(s => s.getMaSV == maSV);
    if (foundSV != null)
    {
        Console.WriteLine($"Sinh vien tim thay: Ma SV: {foundSV.getMaSV}/t| Ho Ten: {foundSV.getHoTen}/t| Diem TB: {foundSV.getDiemTB:F2}/t|");
    }
    else
    {
        Console.WriteLine("Khong tim thay sinh vien voi ma SV da nhap.");
    }
}

void xoaSinhVien(string maSV)
{
    SinhVien svToRemove = danhSachSinhVien.FirstOrDefault(s => s.getMaSV == maSV);
    if (svToRemove != null)
    {
        danhSachSinhVien.Remove(svToRemove);
        Console.WriteLine("Da xoa sinh vien thanh cong.");
    }
    else
    {
        Console.WriteLine("Khong tim thay sinh vien voi ma SV da nhap.");
    }
}

void capNhatSinhVien(string maSV)
{
    SinhVien svToUpdate = danhSachSinhVien.FirstOrDefault(s => s.getMaSV == maSV);
    if (svToUpdate != null)
    {
        Console.WriteLine("Nhap thong tin moi cho sinh vien: ");
        svToUpdate.capNhatSinhVien(maSV);
        Console.WriteLine("Da cap nhat thong tin sinh vien thanh cong.");
    }
    else
    {
        Console.WriteLine("Khong tim thay sinh vien voi ma SV da nhap.");
    }
}