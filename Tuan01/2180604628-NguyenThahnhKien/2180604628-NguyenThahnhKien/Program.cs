using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== CHUONG TRINH TINH DIEM TRUNG BINH ===");
        Console.WriteLine("Huong dan: Nhap diem cho tung mon hoc (Toan, Van, Anh).");
        Console.WriteLine("Hoac nhap 'done' de ket thuc khi mo rong danh sach diem.\n");

        List<double> diemSo = new List<double>();
        string[] monHoc = { "Toan", "Van", "Anh" };

        // Nhap diem 3 mon bat buoc
        for (int i = 0; i < monHoc.Length; i++)
        {
            while (true)
            {
                Console.Write($"Nhap diem mon {monHoc[i]}: ");
                string input = Console.ReadLine();

                try
                {
                    double diem = double.Parse(input);
                    if (diem < 0 || diem > 10)
                    {
                        Console.WriteLine("Diem phai nam trong khoang 0 den 10.");
                        continue;
                    }

                    diemSo.Add(diem);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Vui long nhap mot so hop le.");
                }
            }
        }

        // Nhap diem mo rong (tuy chon)
        Console.WriteLine("\nBan co the nhap them diem (hoac go 'done' de ket thuc):");
        while (true)
        {
            Console.Write("Nhap diem tiep theo (hoac 'done'): ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "done")
                break;

            try
            {
                double diem = double.Parse(input);
                if (diem < 0 || diem > 10)
                {
                    Console.WriteLine("Diem phai nam trong khoang 0 den 10.");
                    continue;
                }

                diemSo.Add(diem);
            }
            catch (FormatException)
            {
                Console.WriteLine("Khong dung dinh dang. Nhap lai.");
            }
        }

        // Tinh diem trung binh
        double tong = 0;
        foreach (var diem in diemSo)
        {
            tong += diem;
        }

        double diemTB = diemSo.Count > 0 ? tong / diemSo.Count : 0;

        // Xep loai
        string xepLoai;
        if (diemTB >= 8.0)
            xepLoai = "Gioi";
        else if (diemTB >= 6.5)
            xepLoai = "Kha";
        else if (diemTB >= 5.0)
            xepLoai = "Trung binh";
        else
            xepLoai = "Yeu";

        // Xuat ket qua
        Console.WriteLine($"\nDiem trung binh: {diemTB:F2}");
        Console.WriteLine($"Xep loai hoc luc: {xepLoai}");
        Console.WriteLine("\nCam on ban da su dung chuong trinh!");
    }
}
