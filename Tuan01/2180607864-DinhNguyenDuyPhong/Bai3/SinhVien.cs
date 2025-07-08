using System;

public class SinhVien
{
    public string MaSV { get; set; }
    public string HoTen { get; set; }
    public double DiemTB { get; set; }

    public SinhVien() { }

    public SinhVien(string maSV, string hoTen, double diemTB)
    {
        MaSV = maSV;
        HoTen = hoTen;
        DiemTB = diemTB;
    }

    // Chuyển đối tượng SinhVien thành chuỗi CSV
    public string ToCsv()
    {
        return $"{MaSV},{HoTen},{DiemTB}";
    }

    // Tạo đối tượng SinhVien từ chuỗi CSV
    public static SinhVien FromCsv(string csvLine)
    {
        var parts = csvLine.Split(',');
        if (parts.Length != 3)
            throw new FormatException("Dữ liệu không đúng định dạng CSV.");
        return new SinhVien(
            parts[0],
            parts[1],
            double.Parse(parts[2], System.Globalization.CultureInfo.InvariantCulture)
        );
    }
}