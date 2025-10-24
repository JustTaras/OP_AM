using System;
using Microsoft.VisualBasic;
using System.Windows.Forms;

class Program
{

    static double InputDouble(string message, double defaultValue)
    {
        while (true)
        {
            string input = Interaction.InputBox($"{message} (за замовчуванням {defaultValue}):", "Ввід даних", defaultValue.ToString());
            if (double.TryParse(input, out double value))
                return value;
            else
                MessageBox.Show("Помилка! Введіть коректне число.", "Помилка вводу");
        }
    }


static double CubeRoot(double value)
    {
        return Math.Pow(value, 1.0 / 3.0);
    }

    static double CalculateS(double x, double y)
    {
        double part1 = CubeRoot(2 + Math.Cos(x * x)) / 254;
        double part2 = 9.56 / CubeRoot(3 + Math.Cos(y * y));
        double part3 = CubeRoot(2 + Math.Cos(Math.Pow(x * y, 2))) / 7.4;

        return part1 + part2 + part3;
    }

    [STAThread]
    static void Main()
    {
        double x = InputDouble("Введіть x", 1.5);
        double y = InputDouble("Введіть y", 0.1);

        double S = CalculateS(x, y);

        MessageBox.Show($"Результат обчислення:\nS = {S:F5}", "Результат");
    }


}