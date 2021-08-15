using System;

namespace HomeWork_04_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Из скольки строк будем строить треугольник Паскаля? ");
            bool input_triangle_string; // Для проверки на правильность ввода
            int triangle_string; // Колличество строк в треугольнике
            int count_string = 0; // Считаем сколько строк нужно отступить для вывода треугольника

            do // Проверка ввода triangle_string
            {
                input_triangle_string = Int32.TryParse(Console.ReadLine(), out triangle_string);
                if (!input_triangle_string) Console.Write("Введите ещё раз: ");
                else if (triangle_string < 0 ^ triangle_string > 20)
                {
                    input_triangle_string = false;
                    Console.WriteLine("Такой треугольник мы не построим((( ");
                    Console.Write("Введите ещё раз: ");
                }
                count_string++;
            }
            while (!input_triangle_string);


            int triangle_number; // Начало строки
            int[][] Triangle_Pascal = new int[triangle_string][]; // Зубчатый массив, который хранит в себе значения строк треугольника


            // Создаём и формируем массивы
            for (int i = 0; i < Triangle_Pascal.Length; i++) 
            {
                Triangle_Pascal[i] = new int[i + 1]; // Создаём массивы нужной размерности
                triangle_number = 1; // Переменная для начала счёта строки

                for (int j = 0; j<=i; j++) // Формируем массив
                {
                    Triangle_Pascal[i][j] = triangle_number;
                    triangle_number = triangle_number * (i - j) / (j + 1);
                }
            }


            // Выводим треугольник на экран
            for (int i = 0, x = 0; i<Triangle_Pascal.Length; i++, x += 3)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - x, (count_string + 3) + i); // Устанавливаем курсор на начало строки
                for (int j = 0, c = 0; j < Triangle_Pascal[i].Length; j++, c+=6)
                {
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - x) + c, (count_string + 3) + i); // Перемещаем курсор с каждой интерацией
                    Console.Write($"{Triangle_Pascal[i][j]}");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
