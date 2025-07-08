using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Chào mừng bạn đến với công cụ tính điểm trung bình!");
        Console.WriteLine("Vui lòng nhập điểm của bạn cho từng môn học.");
        Console.WriteLine("Nhập 'done' để kết thúc nhập điểm cho một môn.");

        double toan = ReadScoreList("Toán");
        double van = ReadScoreList("Văn");
        double anh = ReadScoreList("Tiếng Anh");

        double average = Math.Round((toan + van + anh) / 3, 2);

        string classification;
        if (average >= 8.0)
            classification = "Giỏi";
        else if (average >= 6.5)
            classification = "Khá";
        else if (average >= 5.0)
            classification = "Trung bình";
        else
            classification = "Yếu";

        Console.WriteLine($"Điểm trung bình: {average:F2}");
        Console.WriteLine($"Xếp loại: {classification}");
    }

    static double ReadScoreList(string subject)
    {
        List<double> scores = new List<double>();
        while (true)
        {
            Console.Write($"Nhập điểm {subject} (hoặc 'done' để kết thúc): ");
            string? input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Dữ liệu không hợp lệ. Vui lòng nhập số hoặc 'done' để kết thúc.");
                continue;
            }
            if (input.Trim().ToLower() == "done")
                break;
            try
            {
                double score = double.Parse(input, CultureInfo.InvariantCulture);
                if (score >= 0 && score <= 10)
                {
                    scores.Add(score);
                }
                else
                {
                    Console.WriteLine("Điểm phải nằm trong khoảng từ 0 đến 10.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Dữ liệu không hợp lệ. Vui lòng nhập số hoặc 'done' để kết thúc.");
            }
        }
        if (scores.Count == 0)
        {
            Console.WriteLine($"Bạn chưa nhập điểm nào cho môn {subject}, mặc định là 0.");
            return 0;
        }
        double avg = Math.Round(scores.Average(), 2);
        Console.WriteLine($"Điểm trung bình môn {subject}: {avg:F2}");
        return avg;
    }
}