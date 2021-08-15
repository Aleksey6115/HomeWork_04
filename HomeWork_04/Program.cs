using System;

namespace HomeWork_04
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Заполнение таблицы
            Random number = new Random(); // Генератор случайных чисел
            int[,] nums = new int[12, 4]; // Массив для таблицы
            int[] profit = new int[nums.GetLength(0)]; // Массив для прибыли 

            Console.WriteLine("Месяц\tДоходы\tРасходы\tПрибыль");
            for (int i = 0; i< nums.GetLength(0); i++) // Перебераем строки
            {
                nums[i, 0] = i + 1; // Номер меяца
                Console.Write($"{nums[i, 0]}\t"); // Выводим месяц
                for (int j = 1; j < nums.GetLength(1); j++) // Перебераем столбцы веутри строк
                {
                    if (j == nums.GetLength(1) - 1) // Условия для подсчёта прибыли
                    {
                        nums[i, j] = nums[i, j - 2] - nums[i, j - 1]; // Считаем прибыль
                        Console.Write($"{nums[i, j]}\t"); // Выводим прибыль
                        profit[i] = nums[i, j]; // Фиксируем прибыль в отдельный массив
                    }

                    else // Заполняем таблицу
                    {
                        nums[i, j] = number.Next(5, 20) * 1000;
                        Console.Write($"{nums[i, j]}\t");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            #endregion

            #region Вывод месяцев с худшей прибылью
            Array.Sort(profit); // Сортируем массив с прибылью
            int[] profit_NoRepeat = new int[3]; // Массив хранит в себе отсортированные значения прибыли без повторений
            int result = profit[0]; // Промежуточная переменная для хранения результата в цикле
            profit_NoRepeat[0] = result; // Присваиваем первое значение в массив, во избежании ошибки

            // Формируем массив profit_NoRepeat, который будет содержать три элемента с наименьшей прибылью
            // исключая повторения
            for (int i = 1, j = 1; i<profit.Length; i++) 
            {
                if (result == profit[i]) continue;
                else if (j == profit_NoRepeat.Length) break;
                else
                {
                    result = profit[i];
                    profit_NoRepeat[j] = result;
                    j++;
                }
            }

            // Выводим месяца с худшей прибылью
            Console.Write("Месяца с худшей прибылью: ");
            for (int i = 0; i<profit_NoRepeat.Length; i++)
            {
                for (int j = 0; j<nums.GetLength(0); j++)
                {
                    if (profit_NoRepeat[i] == nums[j, 3]) Console.Write($"{nums[j, 0]} ");
                }
            }
            #endregion

            #region Подсчёт меяцев с положительной прибылью
            int count = 0; // Переменная для подсчёта положительных месяцев

            // Считаем положительные месяца
            for (int i = 0; i<profit.Length; i++)
            {
                if (profit[i] > 0) count++;
            }

            Console.WriteLine($"\nМесяцев с положительной прибылью: {count}");
            #endregion

            Console.ReadKey();
        }
    }
}
