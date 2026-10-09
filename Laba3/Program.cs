using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0.1;
            double b = 1.0;
            int n = 10;
            double eps = 0.0001;
            double step = (b - a) / 9;

            Console.WriteLine("Лабораторная работа №3. Вариант 1");
            Console.WriteLine("Вычисление функции y = 3^x\n");
            Console.WriteLine("X\t\tSN\t\tSE\t\tY");

            for (int i = 0; i < 10; i++)
            {
                double x = a + i * step;
                double sn = CalculateSumN(x, n);
                double se = CalculateSumToch(x, eps);
                double y = Math.Pow(3, x);

                Console.WriteLine($"{x:F1}\t\t{sn:F6}\t{se:F6}\t{y:F6}");
            }
        }
        // Вычисление значение суммы для заданного n
        static double CalculateSumN(double x, int n)
        {
            double sum = 1.0;
            double term = 1.0;
            double val = x * Math.Log(3);

            for (int i = 1; i <= n; i++)
            {
                term *= val / i;
                sum += term;
            }

            return sum;
        }
        // Вычисление значение суммы для заданной точности
        static double CalculateSumToch(double x, double eps)
        {
            double sum = 1.0;
            double term = 1.0;
            double val = x * Math.Log(3);
            int i = 1;

            do
            {
                term *= val / i;
                sum += term;
                i++;
            }
            while (Math.Abs(term) >= eps);

            return sum;
        }
    }
}