using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bai3
{
   
    

    internal class Program
    {
        static List<SinhVien> danhSach = new List<SinhVien>();
        static string filePath = "data.txt";

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            TaiDuLieu();

            int chon;
            do
            {
                HienThiMenu();
                Console.Write("\uD83D\uDC49 Chọn chức năng: ");
                chon = int.TryParse(Console.ReadLine(), out int kq) ? kq : -1;
                Console.Clear();

                switch (chon)
                {
                    case 1: TieuDe("1. Thêm sinh viên"); Them(); break;
                    case 2: TieuDe("2. Danh sách sinh viên"); Xuat(danhSach); break;
                    case 3: TieuDe("3. Sinh viên khoa CNTT"); Xuat(danhSach.Where(sv => sv.Khoa.Equals("CNTT", StringComparison.OrdinalIgnoreCase)).ToList()); break;
                    case 4: TieuDe("4. Sinh viên có điểm TB ≥ 5"); Xuat(danhSach.Where(sv => sv.DiemTB >= 5).ToList()); break;
                    case 5: TieuDe("5. Sắp xếp điểm TB tăng dần"); Xuat(danhSach.OrderBy(sv => sv.DiemTB).ToList()); break;
                    case 6: TieuDe("6. SV khoa CNTT & điểm ≥ 5"); Xuat(danhSach.Where(sv => sv.Khoa.Equals("CNTT", StringComparison.OrdinalIgnoreCase) && sv.DiemTB >= 5).ToList()); break;
                    case 7:
                        TieuDe("7. SV điểm cao nhất khoa CNTT");
                        double max = danhSach.Where(sv => sv.Khoa.Equals("CNTT", StringComparison.OrdinalIgnoreCase)).Max(sv => sv.DiemTB);
                        Xuat(danhSach.Where(sv => sv.Khoa.Equals("CNTT", StringComparison.OrdinalIgnoreCase) && sv.DiemTB == max).ToList());
                        break;
                    case 8: TieuDe("8. Thống kê xếp loại học lực"); ThongKe(); break;
                    case 0:
                        LuuDuLieu();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("💾 Dữ liệu đã được lưu. Thoát chương trình.");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("⚠️ Lựa chọn không hợp lệ.");
                        Console.ResetColor();
                        break;
                }

                if (chon != 0)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (chon != 0);
        }

        static void HienThiMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              HỆ THỐNG QUẢN LÝ SINH VIÊN FILE                     ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Thêm sinh viên                                                ║");
            Console.WriteLine("║ 2. Xuất danh sách sinh viên                                     ║");
            Console.WriteLine("║ 3. Xuất sinh viên khoa CNTT                                     ║");
            Console.WriteLine("║ 4. Xuất SV có điểm TB ≥ 5                                       ║");
            Console.WriteLine("║ 5. Sắp xếp SV theo điểm TB tăng dần                             ║");
            Console.WriteLine("║ 6. Xuất SV có điểm TB ≥ 5 và khoa CNTT                          ║");
            Console.WriteLine("║ 7. Xuất SV điểm cao nhất khoa CNTT                              ║");
            Console.WriteLine("║ 8. Thống kê số lượng SV theo xếp loại                           ║");
            Console.WriteLine("║ 0. Thoát và lưu dữ liệu                                         ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        static void TieuDe(string tieude)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n>>> {tieude.ToUpper()} <<<\n");
            Console.ResetColor();
        }

        static void TaiDuLieu()
        {
            if (!File.Exists(filePath)) return;
            try
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split(',');
                    if (parts.Length == 4 && double.TryParse(parts[3], out double diem))
                    {
                        danhSach.Add(new SinhVien
                        {
                            MaSV = parts[0].Trim(),
                            HoTen = parts[1].Trim(),
                            Khoa = parts[2].Trim(),
                            DiemTB = diem
                        });
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Đã tải dữ liệu từ file.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Lỗi khi đọc file: " + ex.Message);
                Console.ResetColor();
            }
        }

        static void LuuDuLieu()
        {
            try
            {
                File.WriteAllLines(filePath, danhSach.Select(sv => sv.ToString()));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Lỗi khi ghi file: " + ex.Message);
                Console.ResetColor();
            }
        }

        static void Them()
        {
            Console.Write("Nhập mã SV: ");
            string ma = Console.ReadLine() ?? "";
            if (danhSach.Any(s => s.MaSV == ma))
            {
                Console.WriteLine("❗ Mã sinh viên đã tồn tại.");
                return;
            }

            Console.Write("Nhập họ tên: ");
            string ten = Console.ReadLine() ?? "";

            Console.Write("Nhập khoa: ");
            string khoa = Console.ReadLine() ?? "";

            Console.Write("Nhập điểm TB: ");
            if (!double.TryParse(Console.ReadLine(), out double diem) || diem < 0 || diem > 10)
            {
                Console.WriteLine("❌ Điểm không hợp lệ.");
                return;
            }

            danhSach.Add(new SinhVien { MaSV = ma, HoTen = ten, Khoa = khoa, DiemTB = diem });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Thêm thành công.");
            Console.ResetColor();
        }

        static void Xuat(List<SinhVien> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("📭 Danh sách trống.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0,-10} │ {1,-25} │ {2,-10} │ {3,8}", "Mã SV", "Họ tên", "Khoa", "Điểm TB");
            Console.WriteLine(new string('─', 60));
            Console.ResetColor();
            foreach (var sv in list)
            {
                Console.WriteLine("{0,-10} │ {1,-25} │ {2,-10} │ {3,8:F2}", sv.MaSV, sv.HoTen, sv.Khoa, sv.DiemTB);
            }
        }

        static void ThongKe()
        {
            string XepLoai(double d) =>
                d >= 8 ? "Giỏi" :
                d >= 6.5 ? "Khá" :
                d >= 5 ? "Trung bình" : "Yếu";

            var thongKe = danhSach
                .GroupBy(s => XepLoai(s.DiemTB))
                .Select(g => new { Loai = g.Key, SoLuong = g.Count() });

            foreach (var item in thongKe)
            {
                Console.WriteLine($"📌 {item.Loai,-12}: {item.SoLuong} sinh viên");
            }
        }
    }
}