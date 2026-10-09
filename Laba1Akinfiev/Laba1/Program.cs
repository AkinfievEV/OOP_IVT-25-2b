using System;

namespace App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("\nЗадание 1"); //Задание 1

            int m = ProvInt("Введите m: ");
            int n = ProvInt("Введите n: ");
            double x = ProvDouble("Введите x: ");

            int task1Res1 = n+++m;

            Console.WriteLine($"n+++m = {task1Res1}, m = {m}, n = {n}");

            bool task1Res2 = m-- > n;

            Console.WriteLine($"m = {m}, n = {n}, m-- > n = {task1Res2}");

            bool task1Res3 = n-- > m;

            Console.WriteLine($"m = {m}, n = {n}, n-- > m = {task1Res3}");

            double task1Res4 = Math.Sin(x) + Math.Pow(x, 3) + (1 / (Math.Pow(x, 2) + 1));

            Console.WriteLine($"sin(x) + x^3 + 1/(x^2 + 1) ={task1Res4}, при х = {x}");

            Console.WriteLine("\nЗадание 2"); //Задание 2

            double X = ProvDouble("Введите X: ");
            double Y = ProvDouble("Введите Y: ");

            bool task2Res = X >= 0 && X <= 5 && Y >= 0;

            if (task2Res)
            {
                Console.WriteLine("Точка принадлежит области.");
            }
            else
            {
                Console.WriteLine("Точка не принадлежит области.");
            }

            Console.WriteLine("\nЗадание 3"); //Задание 3

            float a = 1000;
            float b = 0.0001f;

            float Fsum = a + b;
            float Fsum2 = (float)Math.Pow(Fsum, 2);
            float FaKv = (float)Math.Pow(a, 2);
            float Fab2 = 2 * a * b;
            float Fchis = Fsum2 - (FaKv + Fab2);
            float FbKv = (float)Math.Pow(b, 2);
            float Ftask3Res1 = Fchis / FbKv;

            double A = 1000;
            double B = 0.0001;

            double Dsum = A + B;
            double Dsum2 = Math.Pow(Dsum, 2);
            double DaKv = Math.Pow(A, 2);
            double Dab2 = 2 * A * B;
            double Dchis = Dsum2 - (DaKv + Dab2);
            double DbKv = Math.Pow(B, 2);
            double Dtask3Res2 = Dchis / DbKv;

            Console.WriteLine($"Результат float: {Ftask3Res1:G9}");
            Console.WriteLine($"Результат double: {Dtask3Res2:G17}");
        }
        private static int ProvInt(string mess)
        {
            while (true)
            {
                Console.Write(mess);

                if (int.TryParse(Console.ReadLine(), out var val))
                {
                    return val;
                }
                Console.WriteLine("Ошибка! Введите целое число.");
            }
        }
        private static double ProvDouble(string mess)
        {
            while (true)
            {
                Console.Write(mess);

                if (double.TryParse(Console.ReadLine(), out var val)
                    && !double.IsNaN(val)
                    && !double.IsInfinity(val))
                {
                    return val;
                }
                Console.WriteLine("Ошибка! Введите корректное вещественное число.");
            }
        }
    }
}