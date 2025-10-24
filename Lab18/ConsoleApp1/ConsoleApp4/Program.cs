using System;
using Microsoft.VisualBasic;
using System.Windows.Forms;

class Program
{
    static int InputInt(string message)
    {
        while (true)
        {
            string input = Interaction.InputBox(message, "Ввід даних");
            if (int.TryParse(input, out int value) && value > 0)
                return value;
            else
                MessageBox.Show("Помилка! Введіть натуральне число (більше 0).", "Помилка вводу");
        }
    }

    static bool IsPrime(int number, int divisor = 2)
    {
        if (number < 2)
            return false;
        if (divisor * divisor > number)
            return true;
        if (number % divisor == 0)
            return false;

        return IsPrime(number, divisor + 1);
    }

    static string FindTwinPrimes(int n)
    {
        string result = "";
        int prevPrime = -1;

        for (int i = n; i <= 2 * n; i++)
        {
            if (IsPrime(i))
            {
                if (prevPrime != -1 && i - prevPrime == 2)
                {
                    result += $"({prevPrime}, {i})  ";
                }
                prevPrime = i;
            }
        }

        if (result == "")
            return "Близнюків не знайдено у діапазоні [" + n + "; " + (2 * n) + "].";
        else
            return "Знайдені пари близнюків:\n" + result;
    }

    [STAThread]
    static void Main()
    {
        int n = InputInt("Введіть натуральне число n:");

        string output = FindTwinPrimes(n);

        MessageBox.Show(
            $"Діапазон: [{n}; {2 * n}]\n\n{output}",
            "Результат"
        );
    }
}