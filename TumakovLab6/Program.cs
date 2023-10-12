using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 6.1(Написать программу, которая вычисляет число гласных и согласных букв в файле)");
            string filename = @"C:\Users\user\Documents\Tumakov.txt";
            if (!File.Exists(filename))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }
            string content = File.ReadAllText(filename);
            char[] chars = content.ToCharArray();
            int vowelsCount, consonantsCount;
            CountVowelsAndConsonants(chars, out vowelsCount, out consonantsCount);
            Console.WriteLine($"Количество гласных букв: {vowelsCount}");
            Console.WriteLine($"Количество согласных букв: {consonantsCount}");
            
            Console.WriteLine("Упражнение 6.2(умножение двух матриц, заданных в виде двумерного массива)");
            int[,] matrix1 = new int[,]
            {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
            };
            int[,] matrix2 = new int[,]
            {
            { 1, 2 },
            { 3, 4 },
            { 5, 6 }
            };
            Console.WriteLine("Матрица 1:");
            PrintMatrix(matrix1);
            Console.WriteLine("Матрица 2:");
            PrintMatrix(matrix2);
            int[,] result = MultiplyMatrices(matrix1, matrix2);
            Console.WriteLine("Result:");
            PrintMatrix(result);

            Console.WriteLine("Упражнение 6.3(Написать программу, вычисляющую среднюю температуру за год с использованием двумерного массива)");
            int[,] temperature = GenerateTemperatureArray();
            int[] averageTemperatures = CalculateAverageTemperatures(temperature);
            Array.Sort(averageTemperatures);
            for (int month = 0; month < averageTemperatures.Length; month++)
            {
                Console.WriteLine($"Месяц {month + 1}: {averageTemperatures[month]}°C");
            }

            Console.WriteLine("Домашнее задание 6.1(Упражнение 6.1 выполнить с помощью коллекции List<T>)");
            string filename1 = @"C:\Users\user\Documents\Tumakov1.txt";
            if (!File.Exists(filename1))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }
            string content1 = File.ReadAllText(filename1);
            char[] chars1 = content1.ToCharArray();
            int vowelsCount1, consonantsCount1;
            CountVowelsAndConsonants1(chars1, out vowelsCount1, out consonantsCount1);
            Console.WriteLine($"Количество гласных букв: {vowelsCount1}");
            Console.WriteLine($"Количество согласных букв: {consonantsCount1}");

            Console.WriteLine("Домашнее задание 6.2(Упражнение 6.2 выполнить с помощью коллекций LinkedList<LinkedList<T>>)");
            LinkedList<LinkedList<int>> matrix3 = GenerateMatrix();
            LinkedList<LinkedList<int>> matrix4 = GenerateMatrix();
            Console.WriteLine("Матрица 1:");
            PrintMatrix1(matrix3);
            Console.WriteLine("Матрица 2:");
            PrintMatrix1(matrix4);
            LinkedList<LinkedList<int>> result1 = MultiplyMatrices1(matrix3, matrix4);
            Console.WriteLine("Результат: ");
            PrintMatrix1(result1);

            Console.WriteLine("Домашнее задание 6.3(Написать программу для упражнения 6.3, использовав класс Dictionary<TKey, TValue>)");
            int[,] Temperature = GenerateRandomTemperatures();
            double[] AverageTemperature = AverageTemperatures(Temperature);
            Array.Sort(AverageTemperature);

            Dictionary<string, double[]> monthlyTemperatures = new Dictionary<string, double[]>
        {
            { "Январь", GetMonthTemperatures(Temperature, 0) },
            { "Февраль", GetMonthTemperatures(Temperature, 1) },
            { "Март", GetMonthTemperatures(Temperature, 2) },
            { "Апрель", GetMonthTemperatures(Temperature, 3) },
            { "Май", GetMonthTemperatures(Temperature, 4) },
            { "Июнь", GetMonthTemperatures(Temperature, 5) },
            { "Июль", GetMonthTemperatures(Temperature, 6) },
            { "Август", GetMonthTemperatures(Temperature, 7) },
            { "Сентябрь", GetMonthTemperatures(Temperature, 8) },
            { "Октябрь", GetMonthTemperatures(Temperature, 9) },
            { "Ноябрь", GetMonthTemperatures(Temperature, 10) },
            { "Декабрь", GetMonthTemperatures(Temperature, 11) }
        };

            foreach (var monthlyTemperature in monthlyTemperatures)
            {
                Console.WriteLine($"{monthlyTemperature.Key}: {string.Join(", ", monthlyTemperature.Value)}");
            }

            Console.WriteLine("Средние температуры (отсортированные): ");
            foreach (double AverageTemperatures in AverageTemperature)
            {
                Console.WriteLine(AverageTemperatures);
            }
        }
        static void CountVowelsAndConsonants(char[] chars, out int vowelsCount, out int consonantsCount)
        {
            vowelsCount = 0;
            consonantsCount = 0;

            foreach (char c in chars)
            {
                if (char.IsLetter(c))
                {
                    if (IsVowel(c))
                    {
                        vowelsCount++;
                    }
                    else
                    {
                        consonantsCount++;
                    }
                }
            }
        }
        static bool IsVowel(char c)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            return Array.IndexOf(vowels, char.ToLower(c)) >= 0;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int rows2 = matrix2.GetLength(0);
            int cols2 = matrix2.GetLength(1);
            if (cols1 != rows2)
            {
                throw new ArgumentException("Номер столбца в первой матрице должен быть равен номеру строки во второй матрице!");
            }
            int[,] result = new int[rows1, cols2];
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }
        static int[,] GenerateTemperatureArray()
        {
            Random random = new Random();
            int[,] temperature = new int[12, 30];
            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    temperature[month, day] = random.Next(-28, 35);
                }
            }
            return temperature;
        }
        static int[] CalculateAverageTemperatures(int[,] temperature)
        {
            int[] averageTemperatures = new int[12];
            for (int month = 0; month < 12; month++)
            {
                int sum = 0;
                for (int day = 0; day < 30; day++)
                {
                    sum += temperature[month, day];
                }
                averageTemperatures[month] = sum / 30;
            }
            return averageTemperatures;
        }
        static void CountVowelsAndConsonants1(char[] chars1, out int vowelsCount1, out int consonantsCount1)
        {
            vowelsCount1 = 0;
            consonantsCount1 = 0;
            List<char> vowels1 = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            List<char> consonants1 = new List<char>()
            {
            'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm',
            'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'
            };
            foreach (char c in chars1)
            {
                if (char.IsLetter(c))
                {
                    if (vowels1.Contains(char.ToLower(c)))
                    {
                        vowelsCount1++;
                    }
                    else if (consonants1.Contains(char.ToLower(c)))
                    {
                        consonantsCount1++;
                    }
                }
            }
        }
        static LinkedList<LinkedList<int>> GenerateMatrix()
        {
            Random random1 = new Random();
            LinkedList<LinkedList<int>> matrix = new LinkedList<LinkedList<int>>();
            int rows = random1.Next(0, 3);
            int cols = random1.Next(4, 9);
            for (int i = 0; i < rows; i++)
            {
                LinkedList<int> row = new LinkedList<int>();

                for (int j = 0; j < cols; j++)
                {
                    row.AddLast(random1.Next(0, 10));
                }
                matrix.AddLast(row);
            }
            return matrix;
        }
        static void PrintMatrix1(LinkedList<LinkedList<int>> matrix)
        {
            foreach (LinkedList<int> row in matrix)
            {
                foreach (int element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
        }

        static LinkedList<LinkedList<int>> MultiplyMatrices1(LinkedList<LinkedList<int>> matrix3, LinkedList<LinkedList<int>> matrix4)
        {
            LinkedList<LinkedList<int>> result1 = new LinkedList<LinkedList<int>>();
            int rows1 = matrix3.Count;
            int cols1 = matrix3.First.Value.Count;
            int rows2 = matrix4.Count;
            int cols2 = matrix4.First.Value.Count;
            if (cols1 != rows2)
            {
                throw new ArgumentException("Номер столбца в первой матрице должен быть равен номеру строки во второй матрице!");
            }
            foreach (LinkedList<int> row in matrix3)
            {
                LinkedList<int> resultRow = new LinkedList<int>();
                for (int j = 0; j < cols2; j++)
                {
                    int sum = 0;

                    for (int k = 0; k < cols1; k++)
                    {
                        sum += row.ElementAt(k) * matrix4.ElementAt(k).ElementAt(j);
                    }
                    resultRow.AddLast(sum);
                }
                result1.AddLast(resultRow);
            }
            return result1;
        }
        static int[,] GenerateRandomTemperatures()
        {
            Random random = new Random();
            int[,] temperature = new int[12, 30];

            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    temperature[month, day] = random.Next(-20, 40);
                }
            }

            return temperature;
        }

        static double[] AverageTemperatures(int[,] temperature)
        {
            double[] AverageTemperature = new double[12];

            for (int month = 0; month < 12; month++)
            {
                double sum = 0;
                for (int day = 0; day < 30; day++)
                {
                    sum += temperature[month, day];
                }
                AverageTemperature[month] = sum / 30;
            }

            return AverageTemperature;
        }

        static double[] GetMonthTemperatures(int[,] temperature, int month)
        {
            double[] monthTemperatures = new double[30];

            for (int day = 0; day < 30; day++)
            {
                monthTemperatures[day] = temperature[month, day];
            }

            return monthTemperatures;
        }
    }
}
