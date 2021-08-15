using System;

namespace HomeWork_04_03
{
    class Program
    {
        /// <summary>
        /// Умножение матрицы на число, умножение/Сложение/Вычитание матриц
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Random random_num = new Random(); // Генератор случайных чисел
            int user_num; // Число которое вводит пользователь и на которое будет умножаться матрица
            int[,] matrix_array; // Массив будет содержать матрицу_1
            int[,] matrix_array_2; // Массив будет содержать матрицу_2
            int matrix_string; // Колличество строк в матрице
            int matrix_column; // Колличество столбцов в матрице
            int[,] result_array; // Результат действий с матрицами
            bool input_variable; // Переменная для проверки условий ввода
            int select = 1; // Переменная для выбора в меню
            int Cursor_top; // Текущие положение курсора по оси у
            int coordinate_x; // Точка отсчёта кординаты х для следующего массива

            while (select != 5) // Цикл позволяет зайти во все режимы и только потом закрыть программу
            {
                Console.WriteLine("Выберите то, что Вас интересует!\n" +
                    "1. Умножение числа на матрицу\t2. Умножение матриц\t3. Сложение матриц\t4. Вычитание матриц\n5. Закрыть программу\n");

                // Ввод select и проверка на правильность ввода
                do
                {
                    input_variable = Int32.TryParse(Console.ReadLine(), out select);
                    if (select < 1 ^ select > 5)
                    {
                        Console.Write("Введите ещё раз: ");
                        input_variable = false;
                    }
                    else if (!input_variable) Console.Write("Введите ещё раз: ");
                }
                while (!input_variable);

                switch (select)
                {
                    case 1:
                        #region Умножение числа на матрицу
                        // Ввод user_num и проверка на правильность ввода
                        Console.Write("\nВведите число (От 1 до 10) на которое будет умножаться матрица: ");
                        do
                        {
                            input_variable = Int32.TryParse(Console.ReadLine(), out user_num);
                            if (user_num < 1 ^ user_num > 10)
                            {
                                Console.Write("Введите ещё раз: ");
                                input_variable = false;
                            }
                            else if (!input_variable) Console.Write("Введите ещё раз: ");
                        }
                        while (!input_variable);

                        // Ввод matrix_string и проверка на правильность ввода
                        Console.Write("\nВведите колличество строк матрицы (От 2 до 10): ");
                        do
                        {
                            input_variable = Int32.TryParse(Console.ReadLine(), out matrix_string);
                            if (matrix_string < 2 ^ matrix_string > 10)
                            {
                                Console.Write("Введите ещё раз: ");
                                input_variable = false;
                            }
                            else if (!input_variable) Console.Write("Введите ещё раз: ");
                        }
                        while (!input_variable);

                        // Ввод matrix_column и проверка на правильность ввода
                        Console.Write("\nВведите колличество столбцов матрицы (Не меньше чем кол-во строк и не больше 10): ");
                        do
                        {
                            input_variable = Int32.TryParse(Console.ReadLine(), out matrix_column);
                            if (matrix_column < matrix_string ^ matrix_column > 10)
                            {
                                Console.Write("Введите ещё раз: ");
                                input_variable = false;
                            }
                            else if (!input_variable) Console.Write("Введите ещё раз: ");
                        }
                        while (!input_variable);

                        // Определим массивам нужный размер
                        matrix_array = new int[matrix_string, matrix_column];
                        result_array = new int[matrix_string, matrix_column];

                        // Заполняем массивы 
                        for (int i = 0; i < matrix_array.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix_array.GetLength(1); j++)
                            {
                                matrix_array[i, j] = random_num.Next(1, 11); // Генерируем матрицу
                                result_array[i, j] = matrix_array[i, j] * user_num; // Выполняем сложение на число и записываем в массив
                            }
                        }


                        Cursor_top = Console.CursorTop + 1; // Текущие положение курсора по оси у

                        Console.SetCursorPosition(0, matrix_string / 2 + Cursor_top); // Устонавливаем курсор 
                        Console.Write($"{user_num}  x"); // Выводим число и операцию

                        // Выводим массив matrix_array
                        for (int i = 0; i < matrix_array.GetLength(0); i++)
                        {
                            Console.SetCursorPosition(6, Cursor_top + i);
                            Console.Write("|");
                            for (int j = 0, x = 8; j < matrix_array.GetLength(1); j++, x += 3)
                            {
                                Console.SetCursorPosition(x, Cursor_top + i);
                                Console.Write(matrix_array[i, j]);
                            }
                            Console.SetCursorPosition(9 + matrix_column + ((matrix_column - 1) * 2), Cursor_top + i);
                            Console.WriteLine("|");
                        }

                        // Точка отсчёта кординаты х для вывода массива result_array
                        coordinate_x = 9 + matrix_column + ((matrix_column - 1) * 2) + 1;

                        Console.SetCursorPosition(coordinate_x + 2, matrix_string / 2 + Cursor_top); // Устонавливаем курсор 
                        Console.Write("=");

                        // Выводим массив result_array
                        for (int i = 0; i < result_array.GetLength(0); i++)
                        {
                            Console.SetCursorPosition(5 + coordinate_x, Cursor_top + i);
                            Console.Write("|");
                            for (int j = 0, x = 7; j < result_array.GetLength(1); j++, x += 3)
                            {
                                Console.SetCursorPosition(x + coordinate_x, Cursor_top + i);
                                Console.Write(result_array[i, j]);
                            }
                            Console.SetCursorPosition(8 + matrix_column + ((matrix_column - 1) * 2) + coordinate_x, Cursor_top + i);
                            Console.WriteLine("|");
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                        #endregion
                        break;
                   
                    case 2:
                        #region умножение матриц
                        // Ввод matrix_string и проверка на правильность ввода
                        Console.Write("\nВведите колличество строк матриц (От 2 до 10): ");
                        do
                        {
                            input_variable = Int32.TryParse(Console.ReadLine(), out matrix_string);
                            if (matrix_string < 2 ^ matrix_string > 10)
                            {
                                Console.Write("Введите ещё раз: ");
                                input_variable = false;
                            }
                            else if (!input_variable) Console.Write("Введите ещё раз: ");
                        }
                        while (!input_variable);


                        // Ввод matrix_column и проверка на правильность ввода
                        Console.Write("\nВведите колличество столбцов матрицы (Не меньше чем кол-во строк и не больше 10): ");
                        do
                        {
                            input_variable = Int32.TryParse(Console.ReadLine(), out matrix_column);
                            if (matrix_column < matrix_string ^ matrix_column > 10)
                            {
                                Console.Write("Введите ещё раз: ");
                                input_variable = false;
                            }
                            else if (!input_variable) Console.Write("Введите ещё раз: ");
                        }
                        while (!input_variable);

                        // Создаём массивы нужной размерности
                        matrix_array = new int[matrix_string, matrix_column];
                        matrix_array_2 = new int[matrix_column, matrix_string];
                        result_array = new int[matrix_string, matrix_string];

                        //Формируем и заполняем массивы
                        for (int i = 0; i < matrix_array_2.GetLength(0); i++)
                        {
                            // Формируем массив matrix_array_2
                            for (int c = 0; c < matrix_array_2.GetLength(1); c++)
                            {
                                matrix_array_2[i, c] = random_num.Next(1, 11);
                            }

                            if (i >= matrix_array.GetLength(0)) continue; // Для того чтобы не вылетела ошибка
                            else
                            {
                                // Формируем массив matrix_array
                                for (int j = 0; j < matrix_array.GetLength(1); j++)
                                {
                                    matrix_array[i, j] = random_num.Next(1, 11);
                                }
                            }
                        }

                        // Умножение
                        for (int i = 0; i < matrix_array.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix_array_2.GetLength(1); j++)
                            {
                                for (int x = 0; x < matrix_array.GetLength(1); x++)
                                {
                                    result_array[i, j] += matrix_array[i, x] * matrix_array_2[x, j]; 
                                }
                            }
                        }

                        Cursor_top = Console.CursorTop + 1; // Текущие положение курсора по оси у

                        // Выводим массив matrix_array
                        for (int i = 0; i < matrix_array.GetLength(0); i++)
                        {
                            Console.SetCursorPosition(1, Cursor_top + i);
                            Console.Write("|");
                            for (int j = 0, x = 3; j < matrix_array.GetLength(1); j++, x += 3)
                            {
                                Console.SetCursorPosition(x, Cursor_top + i);
                                Console.Write(matrix_array[i, j]);
                            }
                            Console.SetCursorPosition(4 + matrix_column + ((matrix_column - 1) * 2), Cursor_top + i);
                            Console.WriteLine("|");
                        }

                        // Точка отсчёта кординаты х для следующего вывода
                        coordinate_x = 5 + matrix_column + ((matrix_column - 1) * 2) + 1;

                        Console.SetCursorPosition(coordinate_x + 2, matrix_string / 2 + Cursor_top); // Устонавливаем курсор 
                        Console.Write("x");

                        // Выводим массив matrix_array_2
                        for (int i = 0; i < matrix_array_2.GetLength(0); i++)
                        {
                            Console.SetCursorPosition(6 + coordinate_x, Cursor_top + i);
                            Console.Write("|");
                            for (int j = 0, x = 7; j < matrix_array_2.GetLength(1); j++, x += 3)
                            {
                                Console.SetCursorPosition(x + coordinate_x, Cursor_top + i);
                                Console.Write(matrix_array_2[i, j]);
                            }
                            Console.SetCursorPosition(8 + matrix_string + ((matrix_string - 1) * 2) + coordinate_x, Cursor_top + i);
                            Console.WriteLine("|");
                        }

                        // Кордината x для следующего вывода
                        coordinate_x = coordinate_x + matrix_string + ((matrix_string - 1) * 2) + 5;

                        Console.SetCursorPosition(coordinate_x + 6, matrix_string / 2 + Cursor_top); // Устонавливаем курсор 
                        Console.Write("=");

                        // Выводим массив result_array
                        for (int i = 0; i < result_array.GetLength(0); i++)
                        {
                            Console.SetCursorPosition(10 + coordinate_x, Cursor_top + i);
                            Console.Write("|");
                            for (int j = 0, x = 11; j < result_array.GetLength(1); j++, x += 6)
                            {
                                Console.SetCursorPosition(x + coordinate_x, Cursor_top + i);
                                Console.Write(result_array[i, j]);
                            }
                            Console.SetCursorPosition(12 + result_array.GetLength(1) + ((result_array.GetLength(1) - 1) * 5) + coordinate_x, Cursor_top + i);
                            Console.WriteLine("|");
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                        #endregion
                        break;

                    case 3:
                        #region Сложение матриц
                        // Ввод matrix_string и проверка на правильность ввода
                        Console.Write("\nВведите колличество строк матриц (От 2 до 10): ");
                        do
                        {
                            input_variable = Int32.TryParse(Console.ReadLine(), out matrix_string);
                            if (matrix_string < 2 ^ matrix_string > 10)
                            {
                                Console.Write("Введите ещё раз: ");
                                input_variable = false;
                            }
                            else if (!input_variable) Console.Write("Введите ещё раз: ");
                        }
                        while (!input_variable);


                        // Ввод matrix_column и проверка на правильность ввода
                        Console.Write("\nВведите колличество столбцов матрицы (Не меньше чем кол-во строк и не больше 10): ");
                        do
                        {
                            input_variable = Int32.TryParse(Console.ReadLine(), out matrix_column);
                            if (matrix_column < matrix_string ^ matrix_column > 10)
                            {
                                Console.Write("Введите ещё раз: ");
                                input_variable = false;
                            }
                            else if (!input_variable) Console.Write("Введите ещё раз: ");
                        }
                        while (!input_variable);

                        // Создаём массивы нужной длинны
                        matrix_array = new int[matrix_string, matrix_column];
                        matrix_array_2 = new int[matrix_string, matrix_column];
                        result_array = new int[matrix_string, matrix_column];

                        // Формируем и заполняем массивы
                        for (int i = 0; i<matrix_array.GetLength(0); i++)
                        {
                            for (int j = 0; j<matrix_array.GetLength(1); j++)
                            {
                                matrix_array[i, j] = random_num.Next(1, 11); // Заполняем первый массив
                                matrix_array_2[i, j] = random_num.Next(1, 11); // Заполняем второй массив
                                result_array[i, j] = matrix_array[i, j] + matrix_array_2[i, j]; // Выполняем сложение
                            }
                        }

                        Cursor_top = Console.CursorTop + 1; // Текущие положение курсора по оси у

                        // Выводим массив matrix_array
                        for (int i = 0; i < matrix_array.GetLength(0); i++)
                        {
                            Console.SetCursorPosition(1, Cursor_top + i);
                            Console.Write("|");
                            for (int j = 0, x = 3; j < matrix_array.GetLength(1); j++, x += 3)
                            {
                                Console.SetCursorPosition(x, Cursor_top + i);
                                Console.Write(matrix_array[i, j]);
                            }
                            Console.SetCursorPosition(4 + matrix_column + ((matrix_column - 1) * 2), Cursor_top + i);
                            Console.WriteLine("|");
                        }

                        // Точка отсчёта кординаты х для вывода массива result_array
                        coordinate_x = 5 + matrix_column + ((matrix_column - 1) * 2) + 1;

                        Console.SetCursorPosition(coordinate_x + 2, matrix_string / 2 + Cursor_top); // Устонавливаем курсор 
                        Console.Write("+");

                        // Выводим массив matrix_array_2
                        for (int i = 0; i < matrix_array_2.GetLength(0); i++)
                        {
                            Console.SetCursorPosition(6 + coordinate_x, Cursor_top + i);
                            Console.Write("|");
                            for (int j = 0, x = 7; j < matrix_array_2.GetLength(1); j++, x += 3)
                            {
                                Console.SetCursorPosition(x + coordinate_x, Cursor_top + i);
                                Console.Write(matrix_array_2[i, j]);
                            }
                            Console.SetCursorPosition(8 + matrix_column + ((matrix_column - 1) * 2) + coordinate_x, Cursor_top + i);
                            Console.WriteLine("|");
                        }

                        coordinate_x *= 2;
                        Console.SetCursorPosition(coordinate_x + 6, matrix_string / 2 + Cursor_top); // Устонавливаем курсор 
                        Console.Write("=");

                        // Выводим массив result_array
                        for (int i = 0; i < result_array.GetLength(0); i++)
                        {
                            Console.SetCursorPosition(10 + coordinate_x, Cursor_top + i);
                            Console.Write("|");
                            for (int j = 0, x = 11; j < result_array.GetLength(1); j++, x += 3)
                            {
                                Console.SetCursorPosition(x + coordinate_x, Cursor_top + i);
                                Console.Write(result_array[i, j]);
                            }
                            Console.SetCursorPosition(12 + matrix_column + ((matrix_column - 1) * 2) + coordinate_x, Cursor_top + i);
                            Console.WriteLine("|");
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                        #endregion
                        break;

                    case 4:
                        #region Вычитание матриц
                        // Ввод matrix_string и проверка на правильность ввода
                        Console.Write("\nВведите колличество строк матриц (От 2 до 10): ");
                        do
                        {
                            input_variable = Int32.TryParse(Console.ReadLine(), out matrix_string);
                            if (matrix_string < 2 ^ matrix_string > 10)
                            {
                                Console.Write("Введите ещё раз: ");
                                input_variable = false;
                            }
                            else if (!input_variable) Console.Write("Введите ещё раз: ");
                        }
                        while (!input_variable);


                        // Ввод matrix_column и проверка на правильность ввода
                        Console.Write("\nВведите колличество столбцов матрицы (Не меньше чем кол-во строк и не больше 10): ");
                        do
                        {
                            input_variable = Int32.TryParse(Console.ReadLine(), out matrix_column);
                            if (matrix_column < matrix_string ^ matrix_column > 10)
                            {
                                Console.Write("Введите ещё раз: ");
                                input_variable = false;
                            }
                            else if (!input_variable) Console.Write("Введите ещё раз: ");
                        }
                        while (!input_variable);

                        // Создаём массивы нужной длинны
                        matrix_array = new int[matrix_string, matrix_column];
                        matrix_array_2 = new int[matrix_string, matrix_column];
                        result_array = new int[matrix_string, matrix_column];

                        // Формируем и заполняем массивы
                        for (int i = 0; i < matrix_array.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix_array.GetLength(1); j++)
                            {
                                matrix_array[i, j] = random_num.Next(1, 11); // Заполняем первый массив
                                matrix_array_2[i, j] = random_num.Next(1, 11); // Заполняем второй массив
                                result_array[i, j] = matrix_array[i, j] - matrix_array_2[i, j]; // Выполняем сложение
                            }
                        }

                        Cursor_top = Console.CursorTop + 1; // Текущие положение курсора по оси у

                        // Выводим массив matrix_array
                        for (int i = 0; i < matrix_array.GetLength(0); i++)
                        {
                            Console.SetCursorPosition(1, Cursor_top + i);
                            Console.Write("|");
                            for (int j = 0, x = 3; j < matrix_array.GetLength(1); j++, x += 3)
                            {
                                Console.SetCursorPosition(x, Cursor_top + i);
                                Console.Write(matrix_array[i, j]);
                            }
                            Console.SetCursorPosition(4 + matrix_column + ((matrix_column - 1) * 2), Cursor_top + i);
                            Console.WriteLine("|");
                        }

                        // Точка отсчёта кординаты х для вывода массива result_array
                        coordinate_x = 5 + matrix_column + ((matrix_column - 1) * 2) + 1;

                        Console.SetCursorPosition(coordinate_x + 2, matrix_string / 2 + Cursor_top); // Устонавливаем курсор 
                        Console.Write("-");

                        // Выводим массив matrix_array_2
                        for (int i = 0; i < matrix_array_2.GetLength(0); i++)
                        {
                            Console.SetCursorPosition(6 + coordinate_x, Cursor_top + i);
                            Console.Write("|");
                            for (int j = 0, x = 7; j < matrix_array_2.GetLength(1); j++, x += 3)
                            {
                                Console.SetCursorPosition(x + coordinate_x, Cursor_top + i);
                                Console.Write(matrix_array_2[i, j]);
                            }
                            Console.SetCursorPosition(8 + matrix_column + ((matrix_column - 1) * 2) + coordinate_x, Cursor_top + i);
                            Console.WriteLine("|");
                        }

                        coordinate_x *= 2;
                        Console.SetCursorPosition(coordinate_x + 6, matrix_string / 2 + Cursor_top); // Устонавливаем курсор 
                        Console.Write("=");

                        // Выводим массив result_array
                        for (int i = 0; i < result_array.GetLength(0); i++)
                        {
                            Console.SetCursorPosition(10 + coordinate_x, Cursor_top + i);
                            Console.Write("|");
                            for (int j = 0, x = 11; j < result_array.GetLength(1); j++, x += 4)
                            {
                                Console.SetCursorPosition(x + coordinate_x, Cursor_top + i);
                                Console.Write(result_array[i, j]);
                            }
                            Console.SetCursorPosition(13 + matrix_column + ((matrix_column - 1) * 3) + coordinate_x, Cursor_top + i);
                            Console.WriteLine("|");
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                        #endregion
                        break;
                }
            }
        }
    }
}
