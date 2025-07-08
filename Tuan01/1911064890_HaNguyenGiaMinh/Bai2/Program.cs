using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bai2
{
    internal class Program
    {
        static List<SinhVien> danhSach = new List<SinhVien>();

        static void Main()
        {
           
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int chon;
            do
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║     CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN        ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Thêm sinh viên                          ║");
                Console.WriteLine("║ 2. Hiển thị danh sách                      ║");
                Console.WriteLine("║ 3. Tìm kiếm sinh viên theo MSSV            ║");
                Console.WriteLine("║ 4. Xoá sinh viên theo MSSV                 ║");
                Console.WriteLine("║ 5. Cập nhật thông tin sinh viên            ║");
                Console.WriteLine("║ 6. Sắp xếp danh sách theo điểm TB (↓)      ║");
                Console.WriteLine("║ 7. Thoát                                   ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("👉 Chọn chức năng: ");
                chon = int.TryParse(Console.ReadLine(), out int tmp) ? tmp : 0;

                Console.Clear();
                switch (chon)
                {
                    case 1: Them(); break;
                    case 2: HienThi(); break;
                    case 3: Tim(); break;
                    case 4: Xoa(); break;
                    case 5: CapNhat(); break;
                    case 6: SapXep(); break;
                    case 7: Console.WriteLine("👋 Tạm biệt!"); break;
                    default: Console.WriteLine("⚠️ Lựa chọn không hợp lệ."); break;
                }

                if (chon != 7)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                    Console.ReadKey();
                }

            } while (chon != 7);
        }

        static void Them()
        {
            Console.WriteLine("== THÊM MỚI SINH VIÊN ==");
            Console.Write("Mã SV: ");
            string ma = Console.ReadLine()?.Trim();
            if (danhSach.Any(s => s.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("❌ MSSV đã tồn tại.");
                return;
            }

            Console.Write("Họ tên: ");
            string ten = Console.ReadLine()?.Trim();

            Console.Write("Điểm TB: ");
            if (!double.TryParse(Console.ReadLine(), out double diem) || diem < 0 || diem > 10)
            {
                Console.WriteLine("❌ Điểm không hợp lệ.");
                return;
            }

            danhSach.Add(new SinhVien { MaSV = ma, HoTen = ten, DiemTB = diem });
            Console.WriteLine("✅ Thêm thành công!");
        }

        static void HienThi()
        {
            Console.WriteLine("== DANH SÁCH SINH VIÊN ==");
            if (danhSach.Count == 0)
            {
                Console.WriteLine("📭 Danh sách trống.");
                return;
            }

            Console.WriteLine("{0,-10} | {1,-25} | {2,10}", "Mã SV", "Họ tên", "Điểm TB");
            Console.WriteLine(new string('-', 50));
            foreach (var sv in danhSach)
            {
                Console.WriteLine("{0,-10} | {1,-25} | {2,10:F2}", sv.MaSV, sv.HoTen, sv.DiemTB);
            }
        }

        static void Tim()
        {
            Console.WriteLine("== TÌM KIẾM SINH VIÊN ==");
            Console.Write("Nhập MSSV: ");
            string ma = Console.ReadLine();

            var sv = danhSach.Find(s => s.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (sv != null)
            {
                Console.WriteLine($"🔎 Họ tên: {sv.HoTen}, Điểm TB: {sv.DiemTB:F2}");
            }
            else
            {
                Console.WriteLine("❌ Không tìm thấy sinh viên.");
            }
        }

        static void Xoa()
        {
            Console.WriteLine("== XOÁ SINH VIÊN ==");
            Console.Write("Nhập MSSV: ");
            string ma = Console.ReadLine();
            var sv = danhSach.Find(s => s.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (sv != null)
            {
                danhSach.Remove(sv);
                Console.WriteLine("🗑️ Đã xoá thành công.");
            }
            else
            {
                Console.WriteLine("❌ Không tìm thấy MSSV.");
            }
        }

        static void CapNhat()
        {
            Console.WriteLine("== CẬP NHẬT SINH VIÊN ==");
            Console.Write("Nhập MSSV: ");
            string ma = Console.ReadLine();
            var sv = danhSach.Find(s => s.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (sv != null)
            {
                Console.Write("Tên mới (Enter để giữ nguyên): ");
                string tenMoi = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(tenMoi)) sv.HoTen = tenMoi;

                Console.Write("Điểm mới (Enter để giữ nguyên): ");
                string diemMoi = Console.ReadLine();
                if (double.TryParse(diemMoi, out double diem)) sv.DiemTB = diem;

                Console.WriteLine("✅ Cập nhật thành công.");
            }
            else
            {
                Console.WriteLine("❌ Không tìm thấy sinh viên.");
            }
        }

        static void SapXep()
        {
            Console.WriteLine("== DANH SÁCH SẮP XẾP THEO ĐIỂM TB (↓) ==");
            var sorted = danhSach.OrderByDescending(s => s.DiemTB).ToList();

            Console.WriteLine("{0,-10} | {1,-25} | {2,10}", "Mã SV", "Họ tên", "Điểm TB");
            Console.WriteLine(new string('-', 50));
            foreach (var sv in sorted)
            {
                Console.WriteLine("{0,-10} | {1,-25} | {2,10:F2}", sv.MaSV, sv.HoTen, sv.DiemTB);
            }
        }
    }
}