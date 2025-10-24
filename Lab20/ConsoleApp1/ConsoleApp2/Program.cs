using System;
using System.IO;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        string folderPath = @"C:\Users\Public\Documents\Lab20";
        string fileName = "Shylo.txt";
        string filePath = Path.Combine(folderPath, fileName);

        if (!File.Exists(filePath))
        {
            MessageBox.Show($"Файл '{filePath}' не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            string allWriters = string.Join(Environment.NewLine, lines);

            MessageBox.Show(allWriters, "Зміст файлу", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка при читанні файлу: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}