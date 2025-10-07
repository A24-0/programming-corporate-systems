using System;

namespace MatrixCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для работы с матрицами");
            
            int[,] matrix1 = null;
            int[,] matrix2 = null;
            
            while (true)
            {
                ShowMenu();
                int choice = GetMenuChoice();
                
                switch (choice)
                {
                    case 1:
                        matrix1 = CreateMatrix("первой");
                        break;
                    case 2:
                        matrix2 = CreateMatrix("второй");
                        break;
                    case 3:
                        if (matrix1 != null && matrix2 != null)
                        {
                            Console.WriteLine("\n--- Сложение матриц ---");
                            AddMatrices(matrix1, matrix2);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Сначала создайте обе матрицы!");
                        }
                        break;
                    case 4:
                        if (matrix1 != null && matrix2 != null)
                        {
                            Console.WriteLine("\n--- Умножение матриц ---");
                            MultiplyMatrices(matrix1, matrix2);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Сначала создайте обе матрицы!");
                        }
                        break;
                    case 5:
                        if (matrix1 != null)
                        {
                            Console.WriteLine("\n--- Первая матрица ---");
                            PrintMatrix(matrix1);
                        }
                        else
                        {
                            Console.WriteLine("Первая матрица не создана!");
                        }
                        break;
                    case 6:
                        if (matrix2 != null)
                        {
                            Console.WriteLine("\n--- Вторая матрица ---");
                            PrintMatrix(matrix2);
                        }
                        else
                        {
                            Console.WriteLine("Вторая матрица не создана!");
                        }
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор! Попробуйте еще раз.");
                        break;
                }
                
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        // Метод для отображения меню
        static void ShowMenu()
        {
            Console.WriteLine("-------------- Меню ------------");
            Console.WriteLine("1. Создать первую матрицу");
            Console.WriteLine("2. Создать вторую матрицу");
            Console.WriteLine("3. Сложить матрицы");
            Console.WriteLine("4. Умножить матрицы");
            Console.WriteLine("5. Показать первую матрицу");
            Console.WriteLine("6. Показать вторую матрицу");
            Console.WriteLine("7. Выход");
            Console.WriteLine("--------------------------------");
        }
        
        // Метод для получения выбора пользователя
        static int GetMenuChoice()
        {
            int choice;
            while (true)
            {
                Console.Write("Выберите пункт меню (1-7): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 7)
                {
                    return choice;
                }
                Console.WriteLine("Неверный ввод! Введите число от 1 до 7.");
            }
        }
        
        // Метод для безопасного ввода целого числа
        static int ReadInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result > 0)
                {
                    return result;
                }
                Console.WriteLine("Неверный ввод! Введите положительное число.");
            }
        }
        
        // Метод для создания матрицы
        static int[,] CreateMatrix(string matrixName)
        {
            Console.WriteLine($"\n--- Создание {matrixName} матрицы ---");
            
            // Ввод размерности матрицы с проверкой
            int n = ReadInt("Введите количество строк (n): ");
            int m = ReadInt("Введите количество столбцов (m): ");
            
            // Создание двумерного массива
            int[,] matrix = new int[n, m];
            
            // Выбор способа заполнения
            Console.WriteLine("\nВыберите способ заполнения:");
            Console.WriteLine("1 - Ввод с клавиатуры");
            Console.WriteLine("2 - Случайные числа");
            Console.Write("Ваш выбор: ");
            
            int choice = int.Parse(Console.ReadLine());
            
            if (choice == 1)
            {
                // Заполнение с клавиатуры
                FillMatrixKeyboard(matrix);
            }
            else
            {
                // Заполнение случайными числами
                FillMatrixRandom(matrix);
            }
            
            // Вывод созданной матрицы
            Console.WriteLine($"\n{matrixName.ToUpper()} матрица ({n}x{m}):");
            PrintMatrix(matrix);
            
            return matrix;
        }
        
        // Метод для заполнения матрицы с клавиатуры
        static void FillMatrixKeyboard(int[,] matrix)
        {
            Console.WriteLine("\nВведите элементы матрицы:");
            
            // Двойной цикл для обхода всех элементов
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ReadInt($"Элемент [{i},{j}]: ");
                }
            }
        }
        
        // Метод для заполнения матрицы случайными числами
        static void FillMatrixRandom(int[,] matrix)
        {
            Console.WriteLine("\nВведите диапазон для случайных чисел:");
            int a = ReadInt("Нижняя граница (a): ");
            int b = ReadInt("Верхняя граница (b): ");
            
            // Проверка и коррекция диапазона
            if (a > b)
            {
                Console.WriteLine($"Внимание: Нижняя граница ({a}) больше верхней ({b})!");
                Console.WriteLine("Меняем местами для корректной работы.");
                int temp = a;
                a = b;
                b = temp;
                Console.WriteLine($"Новый диапазон: от {a} до {b}");
            }
            
            // Создание объекта Random для генерации случайных чисел
            Random random = new Random();
            
            // Заполнение матрицы случайными числами
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    // Генерация случайного числа в диапазоне [a, b]
                    matrix[i, j] = random.Next(a, b + 1);
                }
            }
            
            Console.WriteLine($"Матрица заполнена случайными числами от {a} до {b}");
        }
        
        // Метод для вывода матрицы на экран
        static void PrintMatrix(int[,] matrix)
        {
            // Циклы для обхода всех элементов матрицы
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    // Вывод элемента с выравниванием
                    Console.Write($"{matrix[i, j],4}");
                }
                // Переход на новую строку после вывода строки матрицы
                Console.WriteLine();
            }
        }
        
        // Метод для сложения матриц
        static void AddMatrices(int[,] matrix1, int[,] matrix2)
        {
            // Проверка возможности сложения (Складывать можно только матрицы одинаковой размерности.
            //  У матриц должна быть одинаковая размерность, или одинаковый порядок,
            //  если количество их столбцов и строк совпадает.)
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || 
                matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                Console.WriteLine("Ошибка: Матрицы нельзя сложить!");
                Console.WriteLine($"Размер первой матрицы: {matrix1.GetLength(0)}x{matrix1.GetLength(1)}");
                Console.WriteLine($"Размер второй матрицы: {matrix2.GetLength(0)}x{matrix2.GetLength(1)}");
                Console.WriteLine("Для сложения матрицы должны иметь одинаковые размеры.");
                return;
            }
            
            // Создание результирующей матрицы
            int[,] result = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            
            // Сложение соответствующих элементов
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            
            // Вывод результата
            Console.WriteLine("Результат сложения:");
            PrintMatrix(result);
        }
        
        // Метод для умножения матриц
        static void MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            // Проверка возможности умножения (Матрицы можно умножить только в том случае, 
            // если количество столбцов первой матрицы равно количеству строк второй матрицы.
            // Кроме того, результатом умножения матриц будет матрица,
            // размер которой равен количеству строк первой матрицы и количеству столбцов второй матрицы.)
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                Console.WriteLine("Ошибка: Матрицы нельзя умножить!");
                Console.WriteLine($"Размер первой матрицы: {matrix1.GetLength(0)}x{matrix1.GetLength(1)}");
                Console.WriteLine($"Размер второй матрицы: {matrix2.GetLength(0)}x{matrix2.GetLength(1)}");
                Console.WriteLine("Для умножения количество столбцов первой матрицы должно равняться количеству строк второй матрицы.");
                return;
            }
            
            // Создание результирующей матрицы
            int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            
            // Умножение матриц
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            
            // Вывод результата
            Console.WriteLine($"Результат умножения (размер: {result.GetLength(0)}x{result.GetLength(1)}):");
            PrintMatrix(result);
        }
    }
}