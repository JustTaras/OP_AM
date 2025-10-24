using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        string[] writers = new string[5];

        for (int i = 0; i < writers.Length; i++)
        {
            string input;
            do
            {
                Console.Write($"Введіть прізвище письменника №{i + 1}: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Рядок не може бути порожнім. Спробуйте ще раз.");
            }
            while (string.IsNullOrWhiteSpace(input));

            writers[i] = input;
        }

        string fileName = "Shylo.txt";
        string folderPath = @"C:\Users\Public\Documents\Lab20";
        Directory.CreateDirectory(folderPath);
        string filePath = Path.Combine(folderPath, fileName);

        File.WriteAllLines(filePath, writers);
        Console.WriteLine($"\nДані записано у файл: {filePath}");

        string flashPath = @"E:\Shylo.txt";
        try
        {
            File.Copy(filePath, flashPath, true);
            Console.WriteLine($"Файл успішно скопійовано на флешку ({flashPath}).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка копіювання файлу: {ex.Message}");
        }

        Console.WriteLine("\nВідкрийте створений файл у текстовому редакторі (наприклад, Notepad)");
        Console.WriteLine("та додайте ще одного письменника вручну.");
        Console.WriteLine("\nПрограма завершила роботу.");
    }
}