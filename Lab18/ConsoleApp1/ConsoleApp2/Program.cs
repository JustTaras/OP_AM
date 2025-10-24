using System;
using Microsoft.VisualBasic;
using System.Windows.Forms;

class Program
{
    static double InputDouble(string message)
    {
        while (true)
        {
            string input = Interaction.InputBox(message, "Ввід даних");
            if (double.TryParse(input, out double value) && value > 0)
                return value;
            else
                MessageBox.Show("Помилка! Введіть додатне число.", "Помилка вводу");
        }
    }

    static double CalculateThirdSide(double a, double b, double angleDegrees)
    {
        double angleRadians = angleDegrees * Math.PI / 180.0; 
        double c2 = a * a + b * b - 2 * a * b * Math.Cos(angleRadians);
        return Math.Sqrt(c2);
    }

    [STAThread]
    static void Main()
    {
        double a = InputDouble("Введіть довжину сторони a:");
        double b = InputDouble("Введіть довжину сторони b:");
        double angle = InputDouble("Введіть кут між сторонами a і b (у градусах):");

        double c = CalculateThirdSide(a, b, angle);

        MessageBox.Show(
            $"Результати обчислення:\n" +
            $"a = {a}\n" +
            $"b = {b}\n" +
            $"кут = {angle}°\n\n" +
            $"Довжина третьої сторони:\nc = {c:F4}",
            "Результат"
        );
    }
}