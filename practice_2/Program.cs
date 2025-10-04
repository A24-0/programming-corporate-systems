using System;

namespace practice_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu(){
            int choice = 0;

            do{
                Console.WriteLine("\nВыберите задание:" +
                    "\n1. Задание 1 - Ряды Маклорена" +
                    "\n2. Задание 2 - Счастливый билет" +
                    "\n3. Задание 3 - Сокращение дроби" +
                    "\n4. Задание 4 - Угадай число" +
                    "\n5. Задание 5 - Кофейный аппарат" +
                    "\n6. Задание 6 - Лабораторный опыт" +
                    "\n7. Задание 7 - Колонизация Марса" +
                    "\n0. Выход");

                try {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if(choice < 0 || choice > 7){
                        Console.WriteLine("Неверный ввод");
                        continue;
                    }
                } catch {
                    Console.WriteLine("Введите число");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Task1_MaclaurenSeries();
                        break;
                    
                    case 2:
                        Task2_LuckyTicket();
                        break;
                    
                    case 3:
                        Task3_FractionReduction();
                        break;
                    
                    case 4:
                        Task4_GuessNumber();
                        break;
                    
                    case 5:
                        Task5_CoffeeMachine();
                        break;
                    
                    case 6:
                        Task6_BacteriaExperiment();
                        break;
                    
                    case 7:
                        Task7_MarsColonization();
                        break;
                    
                    case 0:
                        Console.WriteLine("До свидания!");
                        break;    
                }

            } while (choice != 0);
        }

        // вычисление ряда маклорена для e^x
        static void Task1_MaclaurenSeries(){
            Console.WriteLine("\nЗадание 1: Ряды Маклорена (e^x)");
            
            try {
                Console.Write("Введите x: ");
                double x = double.Parse(Console.ReadLine());
                
                Console.Write("Введите точность (e < 0.01): ");
                double epsilon = double.Parse(Console.ReadLine());
                
                // проверка на корректность точности
                if(epsilon >= 0.01){
                    Console.WriteLine("Точность должна быть меньше 0.01");
                    return;
                }
                
                if(epsilon <= 0){
                    Console.WriteLine("Точность должна быть больше нуля");
                    return;
                }
                
                double sum = 0;
                double term = 1;
                int n = 0;
                
                // вычисляем сумму ряда пока очередной член больше погрешности
                while(Math.Abs(term) > epsilon){
                    sum += term;
                    n++;
                    term = Math.Pow(x, n) / Factorial(n);
                    
                    // защита от бесконечного цикла
                    if(n > 1000){
                        Console.WriteLine("Превышено количество итераций");
                        return;
                    }
                }
                
                Console.WriteLine($"Значение функции с точностью {epsilon}: {sum}");
                Console.WriteLine($"Проверка через Math.Exp({x}): {Math.Exp(x)}");
                
                Console.Write("\nВведите номер члена ряда (n): ");
                int nthIndex = int.Parse(Console.ReadLine());
                
                // проверка на отрицательный номер
                if(nthIndex < 0){
                    Console.WriteLine("Номер члена ряда не может быть отрицательным");
                    return;
                }
                
                double nthTerm = Math.Pow(x, nthIndex) / Factorial(nthIndex);
                Console.WriteLine($"Значение {nthIndex}-го члена ряда: {nthTerm}");
            }
            catch(FormatException){
                Console.WriteLine("Ошибка: введено не число");
            }
            catch(OverflowException){
                Console.WriteLine("Ошибка: число слишком большое");
            }
            catch(Exception ex){
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // вычисление факториала
        static double Factorial(int n){
            if(n == 0) return 1;
            double result = 1;
            for(int i = 1; i <= n; i++)
                result *= i;
            return result;
        }

        // проверка счастливого билета
        static void Task2_LuckyTicket(){
            Console.WriteLine("\nЗадание 2: Счастливый билет");
            
            try {
                Console.Write("Введите шестизначный номер билета: ");
                int ticket = int.Parse(Console.ReadLine());
                
                // проверка диапазона номера билета
                if(ticket < 0 || ticket > 999999){
                    Console.WriteLine("Ошибка: введите корректный шестизначный номер");
                    return;
                }
                
                // извлекаем каждую цифру
                int d1 = ticket / 100000;
                int d2 = (ticket / 10000) % 10;
                int d3 = (ticket / 1000) % 10;
                int d4 = (ticket / 100) % 10;
                int d5 = (ticket / 10) % 10;
                int d6 = ticket % 10;
                
                // считаем суммы первых трех и последних трех цифр
                int sumFirst = d1 + d2 + d3;
                int sumLast = d4 + d5 + d6;
                
                if(sumFirst == sumLast){
                    Console.WriteLine("Билет счастливый!");
                }
                else{
                    Console.WriteLine("Билет обычный.");
                }
            }
            catch(FormatException){
                Console.WriteLine("Ошибка: введено не число");
            }
            catch(OverflowException){
                Console.WriteLine("Ошибка: число слишком большое");
            }
            catch(Exception ex){
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // сокращение дроби через нод
        static void Task3_FractionReduction(){
            Console.WriteLine("\nЗадание 3: Сокращение дроби");
            
            try {
                Console.Write("Введите числитель M: ");
                int m = int.Parse(Console.ReadLine());
                
                Console.Write("Введите знаменатель N: ");
                int n = int.Parse(Console.ReadLine());
                
                // проверка деления на ноль
                if(n == 0){
                    Console.WriteLine("Знаменатель не может быть равен нулю");
                    return;
                }
                
                // находим наибольший общий делитель
                int gcd = FindGCD(Math.Abs(m), Math.Abs(n));
                
                // сокращаем дробь
                int numerator = m / gcd;
                int denominator = n / gcd;
                
                Console.WriteLine($"Несократимая дробь: {numerator}/{denominator}");
            }
            catch(FormatException){
                Console.WriteLine("Ошибка: введено не число");
            }
            catch(OverflowException){
                Console.WriteLine("Ошибка: число слишком большое");
            }
            catch(Exception ex){
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // алгоритм евклида для нахождения нод
        static int FindGCD(int a, int b){
            while(b != 0){
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // угадывание числа
        static void Task4_GuessNumber(){
            Console.WriteLine("\nЗадание 4: Угадай число");

            Console.WriteLine("Загадайте число от 0 до 63");
            Console.WriteLine("Отвечайте '1' (да) или '0' (нет) на мои вопросы\n");
            
            try {
                int lower = 0;
                int upper = 63;
                int result = 0;
                
                // проверяем каждый бит числа от старшего к младшему
                for(int bit = 5; bit >= 0; bit--){
                    int mask = 1 << bit;
                    int mid = lower + mask;
                    
                    Console.Write($"Ваше число >= {mid}? (1/0): ");
                    string answer = Console.ReadLine();
                    
                    // проверка корректности ответа
                    if(answer != "1" && answer != "0"){
                        Console.WriteLine("Ошибка: введите только 1 или 0");
                        bit++; // повторяем текущий вопрос
                        continue;
                    }
                    
                    if(answer == "1"){
                        result |= mask; // устанавливаем бит
                        lower = mid;
                    }
                    else{
                        upper = mid - 1;
                    }
                }
                
                Console.WriteLine($"\nВаше число: {result}");
            }
            catch(Exception ex){
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // кофейный аппарат
        static void Task5_CoffeeMachine(){
            Console.WriteLine("\nЗадание 5: Кофейный аппарат");
            
            try {
                Console.Write("Сколько миллилитров молока залито в аппарат? ");
                int milk = int.Parse(Console.ReadLine());
                
                Console.Write("Сколько миллилитров воды залито в аппарат? ");
                int water = int.Parse(Console.ReadLine());
                
                // проверка на отрицательные значения
                if(milk < 0 || water < 0){
                    Console.WriteLine("Ошибка: количество не может быть отрицательным");
                    return;
                }
                
                int americanoCount = 0;
                int latteCount = 0;
                int totalRevenue = 0;
                bool canMakeAny = true;
                
                while(canMakeAny){
                    // проверяем возможность приготовления напитков
                    bool canAmericano = water >= 300;
                    bool canLatte = water >= 30 && milk >= 270;
                    
                    if(!canAmericano && !canLatte){
                        canMakeAny = false;
                        Console.WriteLine("\n=== Отчет ===");
                        Console.WriteLine("Ингредиенты подошли к концу");
                        Console.WriteLine($"Остаток воды: {water} мл");
                        Console.WriteLine($"Остаток молока: {milk} мл");
                        Console.WriteLine($"Приготовлено американо: {americanoCount} шт.");
                        Console.WriteLine($"Приготовлено латте: {latteCount} шт.");
                        Console.WriteLine($"Итоговый заработок: {totalRevenue} руб.");
                        break;
                    }
                    
                    Console.WriteLine("\nКакой напиток заказать?");
                    Console.WriteLine("1 - Американо (300 мл воды, 150 руб.)");
                    Console.WriteLine("2 - Латте (30 мл воды + 270 мл молока, 170 руб.)");
                    Console.Write("Ваш выбор: ");
                    
                    int choice;
                    try {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch(FormatException){
                        Console.WriteLine("Ошибка: введите число 1 или 2");
                        continue;
                    }
                    
                    if(choice == 1){
                        if(water >= 300){
                            water -= 300; // вычитаем использованную воду
                            americanoCount++;
                            totalRevenue += 150;
                            Console.WriteLine("Ваш напиток готов");
                        }
                        else{
                            Console.WriteLine("Не хватает воды");
                        }
                    }
                    else if(choice == 2){
                        if(water >= 30 && milk >= 270){
                            water -= 30; // вычитаем воду
                            milk -= 270; // вычитаем молоко
                            latteCount++;
                            totalRevenue += 170;
                            Console.WriteLine("Ваш напиток готов");
                        }
                        else if(water < 30){
                            Console.WriteLine("Не хватает воды");
                        }
                        else{
                            Console.WriteLine("Не хватает молока");
                        }
                    }
                    else{
                        Console.WriteLine("Неверный выбор");
                    }
                }
            }
            catch(FormatException){
                Console.WriteLine("Ошибка: введено не число");
            }
            catch(OverflowException){
                Console.WriteLine("Ошибка: число слишком большое");
            }
            catch(Exception ex){
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // моделирование опыта с бактериями и антибиотиком
        static void Task6_BacteriaExperiment(){
            Console.WriteLine("\nЗадание 6: Лабораторный опыт");
            
            try {
                Console.Write("Введите количество бактерий (N): ");
                int bacteria = int.Parse(Console.ReadLine());
                
                Console.Write("Введите количество капель антибиотика (X): ");
                int x = int.Parse(Console.ReadLine());
                
                // проверка на отрицательные значения
                if(bacteria < 0 || x < 0){
                    Console.WriteLine("Ошибка: значения не могут быть отрицательными");
                    return;
                }
                
                int hour = 0;
                int killPower = 10;
                
                Console.WriteLine("\nДинамика изменения количества бактерий:");
                
                while(killPower > 0 && bacteria > 0){
                    hour++;
                    
                    bacteria *= 2; // удваиваем количество бактерий
                    
                    int killed = x * killPower; // считаем сколько убито
                    bacteria -= killed;
                    
                    if(bacteria < 0) bacteria = 0;
                    
                    Console.WriteLine($"Час {hour}: Бактерий = {bacteria}, Убито = {killed}");
                    
                    killPower--; // уменьшаем силу антибиотика
                    
                    // защита от слишком долгого эксперимента
                    if(hour > 100){
                        Console.WriteLine("Эксперимент прерван: слишком много итераций");
                        break;
                    }
                }
                
                Console.WriteLine($"\nПроцесс завершен через {hour} часов");
                Console.WriteLine($"Конечное количество бактерий: {bacteria}");
            }
            catch(FormatException){
                Console.WriteLine("Ошибка: введено не число");
            }
            catch(OverflowException){
                Console.WriteLine("Ошибка: число слишком большое");
            }
            catch(Exception ex){
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // расчет максимальной толщины защиты модулей
        static void Task7_MarsColonization(){
            Console.WriteLine("\nЗадание 7: Колонизация Марса");
            
            try {
                Console.Write("Введите количество модулей (n): ");
                int n = int.Parse(Console.ReadLine());
                
                Console.Write("Введите размер модуля a (метров): ");
                int a = int.Parse(Console.ReadLine());
                
                Console.Write("Введите размер модуля b (метров): ");
                int b = int.Parse(Console.ReadLine());
                
                Console.Write("Введите высоту поля h (метров): ");
                int h = int.Parse(Console.ReadLine());
                
                Console.Write("Введите ширину поля w (метров): ");
                int w = int.Parse(Console.ReadLine());
                
                // проверка на корректность входных данных
                if(n <= 0 || a <= 0 || b <= 0 || h <= 0 || w <= 0){
                    Console.WriteLine("Ошибка: все значения должны быть положительными");
                    return;
                }
                
                if(a > h || a > w || b > h || b > w){
                    Console.WriteLine("Ошибка: модуль не помещается в поле");
                    return;
                }
                
                int maxD = 0;
                
                // перебираем возможные толщины защиты
                for(int d = 0; d <= Math.Min(h, w) / 2; d++){
                    int moduleA = a + 2 * d; // размер с защитой
                    int moduleB = b + 2 * d; // размер с защитой
                    
                    // проверяем первую ориентацию
                    int rows1 = h / moduleA;
                    int cols1 = w / moduleB;
                    
                    // проверяем вторую ориентацию
                    int rows2 = h / moduleB;
                    int cols2 = w / moduleA;
                    
                    // если помещается нужное количество модулей
                    if(rows1 * cols1 >= n || rows2 * cols2 >= n){
                        maxD = d;
                    }
                    else{
                        break;
                    }
                }
                
                Console.WriteLine($"Максимальная толщина защиты: {maxD} метров");
            }
            catch(FormatException){
                Console.WriteLine("Ошибка: введено не число");
            }
            catch(OverflowException){
                Console.WriteLine("Ошибка: число слишком большое");
            }
            catch(DivideByZeroException){
                Console.WriteLine("Ошибка: деление на ноль");
            }
            catch(Exception ex){
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}