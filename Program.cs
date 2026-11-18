using System;

namespace DelegatesPractice
{
    // =========================================================================
    // ОГОЛОШЕННЯ ДЕЛЕГАТІВ
    // =========================================================================

    // Загальне завдання: делегат для бінарних арифметичних операцій
    delegate double MathOperation(double a, double b);

    // Домашнє завдання: делегат для перетворення одного елемента масиву
    delegate double NumberTransform(double x);

    class Program
    {
        // =====================================================================
        // МЕТОДИ ДЛЯ ЗАГАЛЬНОГО ЗАВДАННЯ (Арифметичні операції)
        // =====================================================================

        static double Add(double a, double b)
        {
            return a + b;
        }

        static double Subtract(double a, double b)
        {
            return a - b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }

        static double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Помилка: ділення на нуль!");
                return double.NaN;
            }
            return a / b;
        }

        // =====================================================================
        // МЕТОДИ ДЛЯ ДОМАШНЬОГО ЗАВДАННЯ (Обробка масиву через делегат)
        // =====================================================================

        // Метод приймає масив чисел та делегат і застосовує його до кожного елемента
        static void ProcessArray(double[] array, NumberTransform operation)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = operation(array[i]);
            }
        }

        static double Square(double x)
        {
            return x * x;
        }

        static double DoubleValue(double x)
        {
            return x * 2;
        }

        static void PrintArray(string message, double[] array)
        {
            Console.Write(message + ": ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + (i < array.Length - 1 ? ", " : ""));
            }
            Console.WriteLine();
        }

        // =====================================================================
        // ГОЛОВНИЙ МЕТОД ПРОГРАМИ
        // =====================================================================

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ: Арифметичні операції через делегат ===");

            double num1 = 12.0;
            double num2 = 4.0;

            // Створюємо змінну делегата і по черзі присвоюємо їй різні методи
            MathOperation operation;

            operation = Add;
            Console.WriteLine(num1 + " + " + num2 + " = " + operation(num1, num2));

            operation = Subtract;
            Console.WriteLine(num1 + " - " + num2 + " = " + operation(num1, num2));

            operation = Multiply;
            Console.WriteLine(num1 + " * " + num2 + " = " + operation(num1, num2));

            operation = Divide;
            Console.WriteLine(num1 + " / " + num2 + " = " + operation(num1, num2));

            Console.WriteLine("\n=== ДОМАШНЄ ЗАВДАННЯ: Обробка масиву через делегат ===");

            double[] numbers = new double[] { 2.0, 3.0, 4.0, 5.0 };
            PrintArray("Початковий масив", numbers);

            // Застосовуємо логіку подвоєння до кожного елемента
            ProcessArray(numbers, DoubleValue);
            PrintArray("Після подвоєння (DoubleValue)", numbers);

            // Застосовуємо логіку піднесення до квадрату до кожного елемента
            ProcessArray(numbers, Square);
            PrintArray("Після піднесення до квадрату (Square)", numbers);
        }
    }
}
