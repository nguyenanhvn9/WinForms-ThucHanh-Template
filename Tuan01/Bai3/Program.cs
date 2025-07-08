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
        string[] parts = line.Split(',');
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
    Console.WriteLine("Da tai du lieu tu file data.txt thanh cong.");
}
else
{
    Console.WriteLine("Khong tim thay file data.txt. Bat dau voi danh sach rong.");
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
                sapXepDanhSach();
                break;
            case 7:
                locDanhSach();
                break;
            case 8:
                isContinue = false;
                thoatChuongTrinh();
                return;
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
    Console.WriteLine("4. Xoa Sinh vien theo MSSV");
    Console.WriteLine("5. Cap nhat thong tin Sinh vien theo MSSV");
    Console.WriteLine("6. Sap xep danh sach");
    Console.WriteLine("7. Loc danh sach Sinh vien");
    Console.WriteLine("8. Thoat chuong trinh ");
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
        //Console.WriteLine($"Ma SV: {sv.getMaSV}\t| Ho Ten: {sv.getHoTen}\t| Diem TB: {sv.getDiemTB:F2}\t|");
    }
}

void timKiemSinhVien(string maSV)
{
    SinhVien foundSV = danhSachSinhVien.FirstOrDefault(s => s.getMaSV == maSV);
    if (foundSV != null)
    {
        Console.WriteLine("Thong tin sinh vien tim thay: ");
        foundSV.hienThiSinhVien();
        //Console.WriteLine($"Sinh vien tim thay: Ma SV: {foundSV.getMaSV}\t| Ho Ten: {foundSV.getHoTen}\t| Diem TB: {foundSV.getDiemTB:F2}\t|");
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
        Console.WriteLine("Thong tin sinh vien tim thay: ");
        svToRemove.hienThiSinhVien();
        danhSachSinhVien.Remove(svToRemove);
        //Console.WriteLine("Da xoa sinh vien thanh cong.");
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
        //Console.WriteLine("Da cap nhat thong tin sinh vien thanh cong.");
    }
    else
    {
        Console.WriteLine("Khong tim thay sinh vien voi ma SV da nhap.");
    }
}

void taiDuLieu()
{
    if (File.Exists(filePath))
    {
        string[] lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] parts = line.Split(',');
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
        Console.WriteLine("Da tai du lieu tu file data.txt thanh cong.");
    }
    else
    {
        Console.WriteLine("Da tai du lieu tu file data.txt that bai.");
    }
}

void sapXepDanhSach()
{
    danhSachSinhVien.Sort((x, y) => x.getDiemTB.CompareTo(y.getDiemTB));
    Console.WriteLine("Da sap xep danh sach sinh vien theo diem trung binh.");
    hienThiSinhVien();
}

void locDanhSach()
{
    int tieuChi = -1;
    int luaChon = -1;
    double minDiem = -1;
    double maxDiem = 11;

    // Xac dinh diem Min
    Console.Write("(0 - 1) de xac nhan diem Min: ");
    tieuChi = Convert.ToInt32(Console.ReadLine());
    while (tieuChi != 0 && tieuChi != 1)
    {
        if (tieuChi != 0 && tieuChi != 1) Console.Write("Lua chon khong hop le. Vui long nhap lai (0 - 1): ");
        tieuChi = Convert.ToInt32(Console.ReadLine());
    }
    if (tieuChi == 1)
    {
        Console.Write("Nhap diem Min: ");
        minDiem = Convert.ToDouble(Console.ReadLine());
        while (minDiem < 0 || minDiem > 10)
        {
            Console.Write("Diem Min phai trong khoang tu 0 den 10. Vui long nhap lai: ");
            minDiem = Convert.ToDouble(Console.ReadLine());
        }
    }

    // Xac dinh diem Max
    tieuChi = -1;
    Console.Write("(0 - 1) de xac nhan diem Max: ");
    tieuChi = Convert.ToInt32(Console.ReadLine());
    while (tieuChi != 0 && tieuChi != 1)
    {
        if (tieuChi != 0 && tieuChi != 1) Console.Write("Lua chon khong hop le. Vui long nhap lai (0 - 1): ");
        tieuChi = Convert.ToInt32(Console.ReadLine());
    }
    if (tieuChi == 1)
    {
        Console.Write("Nhap diem Max: ");
        maxDiem = Convert.ToDouble(Console.ReadLine());
        while (maxDiem < 0 || minDiem > 10)
        {
            Console.Write("Diem Max phai trong khoang tu 0 den 10. Vui long nhap lai: ");
            maxDiem = Convert.ToDouble(Console.ReadLine());
        }
        if (maxDiem < minDiem)
        {
            Console.WriteLine("Diem Max phai lon hon diem Min. Vui long nhap lai.");
            luaChon = -1;
            Console.Write("(0 - 1) de nhap lai diem (Min - Max): ");
            luaChon = Convert.ToInt32(Console.ReadLine());
            while (luaChon != 0 && luaChon != 1)
            {
                if (luaChon != 0 || luaChon != 1) Console.Write("Lua chon khong hop le. Vui long nhap lai (0 - 1): ");
                luaChon = Convert.ToInt32(Console.ReadLine());
            }
            if (luaChon == 0)
            {
                Console.Write("Nhap diem Min: ");
                minDiem = Convert.ToDouble(Console.ReadLine());
                while (minDiem < 0 || minDiem > maxDiem)
                {
                    Console.Write($"Diem Min phai trong khoang tu 0 den {maxDiem}. Vui long nhap lai: ");
                    minDiem = Convert.ToDouble(Console.ReadLine());
                }
            } else
            {
                Console.Write("Nhap diem Max: ");
                maxDiem = Convert.ToDouble(Console.ReadLine());
                while (maxDiem < minDiem || maxDiem > 10)
                {
                    Console.Write($"Diem Max phai trong khoang tu {minDiem} den 10. Vui long nhap lai: ");
                    maxDiem = Convert.ToDouble(Console.ReadLine());
                }
            }
        }
    }

    string ten = String.Empty;
    tieuChi = -1;
    Console.Write("(0 - 1) de xac nhan loc theo ten: ");
    tieuChi = Convert.ToInt32(Console.ReadLine());
    while (tieuChi != 0 && tieuChi != 1)
    {
        if (tieuChi != 0 && tieuChi != 1) Console.Write("Lua chon khong hop le. Vui long nhap lai (0 - 1): ");
        tieuChi = Convert.ToInt32(Console.ReadLine());
    }
    if (tieuChi == 1)
    {
        Console.Write("Nhap ten sinh vien can loc: ");
        ten = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(ten))
        {
            Console.Write("Ten khong duoc de trong. Vui long nhap lai: ");
            ten = Console.ReadLine();
        }
    }

    // Loc danh sach
    List<SinhVien> danhSachLoc = new List<SinhVien>();

    danhSachLoc = danhSachSinhVien
        .Where(sv => (minDiem < 0 || sv.getDiemTB >= minDiem) &&
                     (maxDiem > 10 || sv.getDiemTB <= maxDiem) &&
                     (string.IsNullOrWhiteSpace(ten) || sv.getHoTen.Contains(ten, StringComparison.OrdinalIgnoreCase)))
        .ToList();
    
    if (danhSachLoc.Count == 0)
    {
        Console.WriteLine("Khong co sinh vien nao thoa man.");
        return;
    }
    Console.WriteLine("Danh sach sinh vien sau khi loc");
    Console.WriteLine(string.Format("{0,-10} | {1,-25} | {2,-5}", "Ma SV", "Ho Ten", "Diem TB"));
    foreach (var sv in danhSachLoc)
    {
        sv.hienThiSinhVien();
        //Console.WriteLine($"Ma SV: {sv.getMaSV}\t| Ho Ten: {sv.getHoTen}\t| Diem TB: {sv.getDiemTB:F2}\t|");
    }
}
void luuDuLieu()
{
    using (StreamWriter writer = new StreamWriter(filePath))
    {
        foreach (var sv in danhSachSinhVien)
        {
            writer.WriteLine($"{sv.getMaSV},{sv.getHoTen},{sv.getDiemTB:F2}");
        }
    }
    Console.WriteLine("Da luu du lieu vao file data.txt.");
}

void thoatChuongTrinh()
{
    
    if (danhSachSinhVien.Count > 0)
    {
        luuDuLieu();
    }
    Console.WriteLine("Cam on ban da su dung chuong trinh. Hen gap lai!");
}