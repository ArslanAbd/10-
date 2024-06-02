using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10лаба
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //объявление двумерного массива
                int[,] C = new int[10, 10];
                // заполнение всего массива нулями
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        C[i, j] = 0;
                //заполнение заштрихованной области единицами
                for (int i = 9; i > 3; i--)
                    for (int j = 9 - i; j <= i; j++)
                        C[i, j] = 1;
                // вывод двумерного массива в виде матрицы
                //красным цветом элементы заштрихованной области
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.ForegroundColor = (C[i, j] == 1) ? ConsoleColor.Red :
                       ConsoleColor.DarkGreen;
                        Console.Write($"{C[i, j]} \t");
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                // Задание элементов двумерного массива случайным образом
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        C[i, j] = rnd.Next(-5, 15);
                // Вывод на экран
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write($"{C[i, j]} \t");
                    }
                    Console.WriteLine();
                }
                //1.Вычислить сумму положительных элементов в заштрихованной области матрицы
                int Sum = 0;
                for (int i = 9; i > 3; i--)
                    for (int j = 9 - i; j <= i; j++)
                        if (C[i, j] > 0)
                            Sum = Sum + C[i, j];
                Console.WriteLine($"Sum={Sum}");
                //2. Сформировать одномерный массив L из элементов заштрихованной области, меньших - 3
                //подсчет количества таких элементов
                int N = 0;
                for (int i = 9; i > 3; i--)
                    for (int j = 9 - i; j <= i; j++)
                        if (C[i, j] < -3)
                            N = N + 1;
                // объявление одномерного массива U
                int[] U = new int[N];
                int k = 0;
                for (int i = 9; i > 3; i--)
                    for (int j = 9 - i; j <= i; j++)
                        if (C[i, j] < -3)
                        {
                            U[k] = C[i, j];
                            k = k + 1;
                        }
                // вывод одномерного массива U на экран
                Console.Write("U: ");
                Console.WriteLine(String.Join(", ", U));
                //3.Сформировать одномерный массив Q из количеств отрицательных элементов в каждой строке заштрихованной области матрицы.

                int Minus = C[0, 0];
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        if (C[i, j] < 0)
                            Minus = C[i, j];
                Console.WriteLine($"Minus={Minus}");
                // объявление одномерного массива M
                int[] M = new int[10];
                k = 0;
                for (int i = 9; i > 3; i--)
                {
                    int CountMinus = 0;
                    for (int j = 9 - i; j <= i; j++)
                        if (C[i, j] == Minus)
                        {
                            CountMinus = CountMinus + 1;
                        }
                    M[k] = CountMinus;
                    k = k + 1;
                }
                // вывод одномерного массива M на экран
                Console.Write("M: ");
                Console.WriteLine(String.Join(", ", M));
                //4.Найти значение минимального отрицательного элемента в левой половине матрицы.
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.ForegroundColor = (i < 5) ? ConsoleColor.Red : ConsoleColor.White;
                        Console.Write($"{C[i, j]} \t");
                    }
                    Console.WriteLine();
                }
                //поиск минимума в верхней половине матрицы (1-4 строки)
                int Min = C[0, 0];
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        if (C[i, j] < Min && C[i, j] < 0)
                            Min = C[i, j];
                Console.WriteLine($"Min={Min}");
                Console.ReadLine();
            
            }
        }
    }
    
}
