using System;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    static int[,] matrix = new int[0, 0];
    static int[][] jaggedArray = Array.Empty<int[]>();
    static string text = "";
    static Random random = new Random();

    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\n=== ЛАБАРАТОРНАЯ РАБОТА №5–6 ===");
            Console.WriteLine("Вариант 1");
            Console.WriteLine("1. Двумерный массив");
            Console.WriteLine("2. Рваный массив");
            Console.WriteLine("3. Обработка строки");
            Console.WriteLine("0. Выход");

            int choice = ReadInt("Выберите задачу: ", 0, 3);

            try
            {
                switch (choice)
                {
                    case 1:
                        MatrixMenu();
                        break;
                    case 2:
                        JaggedMenu();
                        break;
                    case 3:
                        StringMenu();
                        break;
                    case 0:
                        return;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Ошибка: {exception.Message}");
            }
        }
    }

    static int ReadInt(string message, int min, int max)
    {
        while (true)
        {
            Console.Write(message);
            var input = Console.ReadLine();

            if (int.TryParse(input, out int number)
                && number >= min && number <= max)
            {
                return number;
            }

            Console.WriteLine($"Введите целое число от {min} до {max}.");
        }
    }
                                                               // ДВУМЕРНЫЙ МАССИВ
    static void MatrixMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- ДВУМЕРНЫЙ МАССИВ ---");
            Console.WriteLine("1. Создать массив вручную");
            Console.WriteLine("2. Создать случайный массив");
            Console.WriteLine("3. Добавить строку");
            Console.WriteLine("4. Вывести массив");
            Console.WriteLine("0. Назад");

            int choice = ReadInt("Выберите действие: ", 0, 4);

            switch (choice)
            {
                case 1:
                    CreateMatrix(false);
                    break;
                case 2:
                    CreateMatrix(true);
                    break;
                case 3:
                    AddMatrixRow();
                    break;
                case 4:
                    PrintMatrix();
                    break;
                case 0:
                    return;
            }
        }
    }

    static void CreateMatrix(bool isRandom)
    {
        int rows = ReadInt("Количество строк (1–20): ", 1, 20);
        int columns = ReadInt("Количество столбцов (1–20): ", 1, 20);

        var newMatrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                newMatrix[i, j] = isRandom
                    ? random.Next(-9, 10)
                    : ReadInt($"Элемент [{i + 1},{j + 1}]: ",
                        -1000000, 1000000);
            }
        }

        matrix = newMatrix;
        Console.WriteLine("Массив создан.");
        PrintMatrix();
    }

    static void AddMatrixRow()
    {
        if (matrix.Length == 0)
        {
            Console.WriteLine("Сначала создайте массив.");
            return;
        }

        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        int position = ReadInt(
            $"Номер новой строки (1–{rows + 1}): ", 1, rows + 1);

        var newMatrix = new int[rows + 1, columns];

        for (int i = 0; i < rows + 1; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (i < position - 1)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
                else if (i == position - 1)
                {
                    newMatrix[i, j] = ReadInt(
                        $"Введите элемент новой строки [{j + 1}]: ",
                        -1000000, 1000000);
                }
                else
                {
                    newMatrix[i, j] = matrix[i - 1, j];
                }
            }
        }

        matrix = newMatrix;
        Console.WriteLine("Строка добавлена.");
        PrintMatrix();
    }

    static void PrintMatrix()
    {
        if (matrix.Length == 0)
        {
            Console.WriteLine("Массив пуст.");
            return;
        }

        Console.WriteLine("\nРезультат:");

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],6}");
            }

            Console.WriteLine();
        }
    }
                                                                //РВАНЫЙ МАССИВ
    static void JaggedMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- РВАНЫЙ МАССИВ ---");
            Console.WriteLine("1. Создать массив вручную");
            Console.WriteLine("2. Создать случайный массив");
            Console.WriteLine("3. Удалить самую длинную строку");
            Console.WriteLine("4. Вывести массив");
            Console.WriteLine("0. Назад");

            int choice = ReadInt("Выберите действие: ", 0, 4);

            switch (choice)
            {
                case 1:
                    CreateJaggedArray(false);
                    break;
                case 2:
                    CreateJaggedArray(true);
                    break;
                case 3:
                    RemoveLongestRow();
                    break;
                case 4:
                    PrintJaggedArray();
                    break;
                case 0:
                    return;
            }
        }
    }

    static void CreateJaggedArray(bool isRandom)
    {
        int rows = ReadInt("Количество строк (1–20): ", 1, 20);
        var newArray = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            int columns = ReadInt(
                $"Количество элементов в строке {i + 1} (1–20): ",
                1, 20);

            newArray[i] = new int[columns];

            for (int j = 0; j < columns; j++)
            {
                newArray[i][j] = isRandom
                    ? random.Next(-9, 10)
                    : ReadInt($"Элемент [{i + 1},{j + 1}]: ",
                        -1000000, 1000000);
            }
        }

        jaggedArray = newArray;
        Console.WriteLine("Рваный массив создан.");
        PrintJaggedArray();
    }

    static void RemoveLongestRow()
    {
        if (jaggedArray.Length == 0)
        {
            Console.WriteLine("Массив пуст.");
            return;
        }

        int longestIndex = 0;

        for (int i = 1; i < jaggedArray.Length; i++)
        {
            if (jaggedArray[i].Length
                > jaggedArray[longestIndex].Length)
            {
                longestIndex = i;
            }
        }

        var newArray = new int[jaggedArray.Length - 1][];
        int newIndex = 0;

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            if (i != longestIndex)
            {
                newArray[newIndex] = jaggedArray[i];
                newIndex++;
            }
        }

        jaggedArray = newArray;

        Console.WriteLine(
            $"Удалена строка № {longestIndex + 1}.");
        PrintJaggedArray();
    }

    static void PrintJaggedArray()
    {
        if (jaggedArray.Length == 0)
        {
            Console.WriteLine("Массив пуст.");
            return;
        }

        Console.WriteLine("\nРезультат:");

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Console.Write($"Строка {i + 1}: ");

            foreach (int number in jaggedArray[i])
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
        }
    }
                                                                //ОБРАБОТКА СТРОКИ
    static void StringMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- ОБРАБОТКА СТРОКИ ---");
            Console.WriteLine("1. Ввести строку");
            Console.WriteLine("2. Использовать тестовую строку");
            Console.WriteLine("3. Перевернуть нечётные предложения");
            Console.WriteLine("4. Вывести строку");
            Console.WriteLine("0. Назад");

            int choice = ReadInt("Выберите действие: ", 0, 4);

            switch (choice)
            {
                case 1:
                    Console.Write("Введите текст: ");
                    text = Console.ReadLine() ?? "";
                    break;
                case 2:
                    text = "В лесу родилась елочка."
                        + "В лесу она росла."
                        + "Зимой и летом стройная, зеленая была.";
                    Console.WriteLine($"Тестовая строка:\n{text}");
                    break;
                case 3:
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        Console.WriteLine("Строка пуста.");
                        break;
                    }

                    text = ReverseOddSentences(text);
                    Console.WriteLine($"Результат:\n{text}");
                    break;
                case 4:
                    Console.WriteLine(string.IsNullOrEmpty(text)
                        ? "Строка пуста."
                        : text);
                    break;
                case 0:
                    return;
            }
        }
    }

    static string ReverseOddSentences(string source)
    {
        int sentenceNumber = 0;

        return Regex.Replace(
            source,
            @"[^.!?]*[.!?]|[^.!?]+$",
            match =>
            {
                string sentence = match.Value;
                string trimmed = sentence.Trim();

                if (trimmed.Length == 0)
                {
                    return sentence;
                }

                sentenceNumber++;

                if (sentenceNumber % 2 == 0)
                {
                    return sentence;
                }

                int start = sentence.IndexOf(trimmed);
                string prefix = sentence.Substring(0, start);
                string suffix = sentence.Substring(
                    start + trimmed.Length);

                char ending = '\0';

                if (".!?".Contains(trimmed[trimmed.Length - 1]))
                {
                    ending = trimmed[trimmed.Length - 1];
                    trimmed = trimmed.Substring(0, trimmed.Length - 1);
                }

                var words = Regex.Split(trimmed.Trim(), @"\s+");
                Array.Reverse(words);

                string result = string.Join(" ", words);

                if (ending != '\0')
                {
                    result += ending;
                }

                return prefix + result + suffix;
            });
    }
}