// See https://aka.ms/new-console-template for more information

// Hiển thị lời chào và hướng dẫn
Console.WriteLine("Chào mừng bạn đến với chương trình Tính Điểm Trung Bình!");
Console.WriteLine("Vui lòng nhập điểm cho các môn: Toán, Văn, Anh.");

// Nhập điểm cho từng môn
Console.Write("Nhập điểm Toán: ");
double diemToan = double.Parse(Console.ReadLine() ?? "0");

Console.Write("Nhập điểm Văn: ");
double diemVan = double.Parse(Console.ReadLine() ?? "0");

Console.Write("Nhập điểm Anh: ");
double diemAnh = double.Parse(Console.ReadLine() ?? "0");

// Tính điểm trung bình
double diemTrungBinh = Math.Round((diemToan + diemVan + diemAnh) / 3, 2);

// Xếp loại học lực
string xepLoai;
if (diemTrungBinh >= 8.0)
    xepLoai = "Giỏi";
else if (diemTrungBinh >= 6.5)
    xepLoai = "Khá";
else if (diemTrungBinh >= 5.0)
    xepLoai = "Trung bình";
else
    xepLoai = "Yếu";

// Xuất kết quả
Console.WriteLine($"\nĐiểm trung bình: {diemTrungBinh:F2}");
Console.WriteLine($"Xếp loại học lực: {xepLoai}");