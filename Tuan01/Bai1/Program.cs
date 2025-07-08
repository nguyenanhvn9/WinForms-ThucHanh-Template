Console.WriteLine("UNG DUNG MAY TINH ĐIEM TRUNG BINH");
Console.WriteLine("Chao mung ban ");
bool isContinue = true;
double diemTrungBinh = 0.0;
double diemToan = -1.0;
double diemVan = -1.0;
double diemAnh = -1.0;
while (isContinue)
{
    int choice = -1;
    while (choice != 0)
    {
        Console.WriteLine("Vui long chon mot trong cac lua chon sau: ");
        Console.WriteLine("1. Nhap diem Toan ");
        Console.WriteLine("2. Nhap diem Van ");
        Console.WriteLine("3. Nhap diem Anh ");
        Console.Write("Nhap 0 de thoat, nhap 4 de tinh diem trung binh: ");
        choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.Write("Nhap diem Toan: ");
                while (diemToan < 0 || diemToan > 10)
                {
                    diemToan = Convert.ToDouble(Console.ReadLine());
                    if (diemToan < 0 || diemToan > 10)
                    {
                        Console.WriteLine("Diem Toan phai trong khoang tu 0 den 10. Vui long nhap lai.");
                    }
                }
                break;
            case 2:
                Console.Write("Nhap diem Van: ");
                while (diemVan < 0 || diemVan > 10)
                {
                    diemVan = Convert.ToDouble(Console.ReadLine());
                    if (diemVan < 0 || diemVan > 10)
                    {
                        Console.WriteLine("Diem Van phai trong khoang tu 0 den 10. Vui long nhap lai.");
                    }
                }
                break;
            case 3:
                Console.Write("Nhap diem Anh: ");
                while (diemAnh < 0 || diemAnh > 10)
                {
                    diemAnh = Convert.ToDouble(Console.ReadLine());
                    if (diemAnh < 0 || diemAnh > 10)
                    {
                        Console.WriteLine("Diem Anh phai trong khoang tu 0 den 10. Vui long nhap lai.");
                    }
                }
                break;
            case 4:
                if (diemToan >= 0 && diemVan >= 0 && diemAnh >= 0)
                {
                    diemTrungBinh = (diemToan + diemVan + diemAnh) / 3;
                    Console.WriteLine($"Diem trung binh la: {diemTrungBinh:F2}");
                    if (diemTrungBinh >= 8.0)
                    {
                        Console.WriteLine("Ban da dat loai Gioi");
                    }
                    else if (diemTrungBinh >= 6.5)
                    {
                        Console.WriteLine("Ban da dat loai Kha");
                    }
                    else if (diemTrungBinh >= 5.0)
                    {
                        Console.WriteLine("Ban da dat loai Trung Binh");
                    }
                    else
                    {
                        Console.WriteLine("Ban da dat loai Yeu");
                    }
                }
                else
                {
                    Console.WriteLine("Ban chua nhap du cac diem.");
                }
                break;
            case 0:
                isContinue = false;
                Console.WriteLine("Cam on ban da su dung ung dung.");
                break;
            default:
                Console.WriteLine("Lua chon khong hop le, vui long chon lai.");
                break;
        }
    }
}