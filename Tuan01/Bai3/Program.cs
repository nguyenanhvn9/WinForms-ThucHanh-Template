using Bai3;

Console.WriteLine("HE THONG QUAN LY SINH VIEN");
Console.WriteLine("Chao mung ban ");
bool isContinue = true;
List<SinhVien> danhSachSinhVien = new List<SinhVien>();
string filePath = "data.txt";
if (File.Exists(filePath))
{
    string[] lines = File.ReadAllLines(filePath);
    foreach (var line in lines)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 3)
        {
            string maSV = parts[0].Trim();
            string hoTen = parts[1].Trim();
            double diemTB;
            if (double.TryParse(parts[2].Trim(), out diemTB))
            {
                SinhVien sv = new SinhVien(maSV, hoTen, diemTB);
                danhSachSinhVien.Add(sv);
            }
        }
    }
}
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
                hienThiSinhVien();
                break;
            case 3:

                Console.Write("Nhap ma sinh vien can tim: ");
                string maSV = Console.ReadLine();
                timKiemSinhVien(maSV);
                break;
            case 4:
                thoatChuongTrinh();
                break;
            default:
                Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                break;
        }
    }
}

void ShowMenu()
{
    Console.WriteLine("Vui long chon mot trong cac lua chon sau: ");
    Console.WriteLine("1. Them moi 1 Sinh vien ");
    Console.WriteLine("2. Hien thi danh sach Sinh vien ");
    Console.WriteLine("3. Tim kiem Sinh vien theo MSSV");
    Console.WriteLine("4. Thoat chuong trinh ");
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
        Console.WriteLine($"Ma SV: {sv.getMaSV}/t| Ho Ten: {sv.getHoTen}/t| Diem TB: {sv.getDiemTB:F2}/t|");
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

void thoatChuongTrinh()
{
    isContinue = false;
    if (danhSachSinhVien.Count > 0)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var sv in danhSachSinhVien)
            {
                writer.WriteLine($"{sv.getMaSV} | {sv.getHoTen} | {sv.getDiemTB:F2}");
            }
        }
    }
    Console.WriteLine("Cam on ban da su dung chuong trinh. Hen gap lai!");
}