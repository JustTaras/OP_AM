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
            if (int.TryParse(input, out int value))
                return value;
            else
                MessageBox.Show("Помилка! Введіть ціле число.", "Помилка вводу");
        }
    }

    static int BinarySearchRecursive(int[] array, int left, int right, int target)
    {
        if (left > right)
            return -1;

        int mid = (left + right) / 2;

        if (array[mid] == target)
            return mid;
        else if (array[mid] > target)
            return BinarySearchRecursive(array, left, mid - 1, target);
        else
            return BinarySearchRecursive(array, mid + 1, right, target);
    }

    [STAThread]
    static void Main()
    {
        int n = InputInt("Введіть розмір масиву:");

        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = InputInt($"Введіть елемент [{i + 1}] масиву:");
        }

        Array.Sort(arr);

        int target = InputInt("Введіть елемент, який потрібно знайти:");

        int index = BinarySearchRecursive(arr, 0, n - 1, target);

        string result = "Відсортований масив:\n" + string.Join(", ", arr) + "\n\n";

        if (index != -1)
            result += $"Елемент {target} знайдено! Індекс у масиві: {index}";
        else
            result += $"Елемент {target} не знайдено.";

        MessageBox.Show(result, "Результат");
    }
}