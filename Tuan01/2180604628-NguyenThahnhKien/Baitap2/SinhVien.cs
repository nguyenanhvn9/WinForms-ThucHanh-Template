using System;
using System.Collections.Generic;
using System.Linq;

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

    public void HienThi()
    {
        Console.WriteLine($"| {MaSV,-10} | {HoTen,-25} | {DiemTB,8:F2} |");
    }
}
