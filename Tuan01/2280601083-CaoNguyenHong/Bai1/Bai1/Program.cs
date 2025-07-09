using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Chao mung ban! Chuong trinh nay se giup ban xep loai hoc luc.");
        Console.WriteLine("Ban se duoc yeu cau nhap diem cho cac mon: Toan, Van, Anh.");

        double math = ReadScore("Toan");
        double literature = ReadScore("Van");
        double english = ReadScore("Anh");

        double average = Math.Round((math + literature + english) / 3, 2);

        string classification = Classify(average);

        Console.WriteLine($"Diem trung binh cua ban la: {average:F2}");
        Console.WriteLine($"Xep loai hoc luc cua ban la: {classification}");
    }

    static double ReadScore(string subject)
    {
        double score;
        while (true)
        {
            Console.Write($"Nhap diem mon {subject}: ");
            string input = Console.ReadLine();
            try
            {
                score = double.Parse(input);
                if (score < 0 || score > 10)
                {
                    Console.WriteLine("Diem phai nam trong khoang tu 0 den 10. Vui long nhap lai.");
                    continue;
                }
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Du lieu khong hop le. Vui long nhap mot so.");
            }
        }
        return score;
    }

    static string Classify(double average)
    {
        if (average >= 8.0)
            return "Gioi";
        else if (average >= 6.5)
            return "Kha";
        else if (average >= 5.0)
            return "Trung binh";
        else
            return "Yeu";
    }
}
