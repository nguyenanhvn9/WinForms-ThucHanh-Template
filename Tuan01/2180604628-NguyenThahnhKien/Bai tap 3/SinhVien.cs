public class SinhVien
{
    public string MaSV { get; set; }
    public string HoTen { get; set; }
    public double DiemTB { get; set; }

    public void HienThi()
    {
        Console.WriteLine($"| {MaSV,-10} | {HoTen,-25} | {DiemTB,8:F2} |");
    }

    public string ToCSV()
    {
        return $"{MaSV},{HoTen},{DiemTB}";
    }

    public static SinhVien FromCSV(string line)
    {
        var parts = line.Split(',');
        return new SinhVien
        {
            MaSV = parts[0],
            HoTen = parts[1],
            DiemTB = double.Parse(parts[2])
        };
    }
}

