using System;

namespace calculator{
    internal class Program{
        static int choice = 1;
        static double num1, num2;
        static string result = "";
        static double memory = 0;

        static void Main(string[] args){
            Menu();
        }

        static void Menu(){
            while(choice != 0){
                Console.WriteLine("1. Сложение (+)" + 
                "\n2. Вычитание (-)" + 
                "\n3. Умножение (*)" + 
                "\n4. Деление (/)" + 
                "\n5. Остаток от деления (%)" + 
                "\n6. Обратное число (1/x)" +
                "\n7. Квадрат числа (x^2)" +
                "\n8. Квадратный корень (√x)" + 
                "\n9. M+ (добавить в память)" + 
                "\n10. M- (вычесть из памяти)" + 
                "\n11. MR (восстановить из памяти)" + 
                "\n12. MC (очистить память)" +
                "\n0. Выход" +
                "\nВыберите операцию: ");

                try {
                    choice = Convert.ToInt32(Console.ReadLine());
                } catch {
                    Console.WriteLine("Введите число от 0 до 12!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        if(InputTwoNumbers(out num1, out num2)){
                            Console.WriteLine("Результат: " + (num1 + num2));
                        }
                        break;
                    case 2:
                        if(InputTwoNumbers(out num1, out num2)){
                            Console.WriteLine("Результат: " + (num1 - num2));
                        }
                        break;
                    case 3:
                        if(InputTwoNumbers(out num1, out num2)){
                            Console.WriteLine("Результат: " + (num1 * num2));   
                        }
                        break;
                    case 4:
                        if(InputTwoNumbers(out num1, out num2)){
                            result = (num2 == 0) ? "На ноль делить нельзя" : "Результат: " + (num1 / num2);
                            Console.WriteLine(result);
                        }
                        break;
                    case 5:
                        if(InputTwoNumbers(out num1, out num2)){
                            if(num2 == 0){
                                Console.WriteLine("На ноль делить нельзя");
                            } else {
                                Console.WriteLine("Результат: " + (num1 % num2));
                            }
                        }
                        break;
                    case 6:
                        if(InputOneNumber(out num1)){
                            result = (num1 == 0) ? "На ноль делить нельзя" : "Результат: " + (1 / num1);
                            Console.WriteLine(result);
                        }
                        break;
                    case 7:
                        if(InputOneNumber(out num1)){
                            Console.WriteLine("Результат: " + (num1 * num1));
                        }
                        break;
                    case 8:
                        if(InputOneNumber(out num1)){
                            result = (num1 < 0) ? "Невозможно вычислить корень из отрицательного числа" 
                                : "Результат: " + Math.Sqrt(num1);
                            Console.WriteLine(result);
                        }
                        break;
                    case 9:
                        MemoryAdd();
                        break;
                    case 10:
                        MemorySubtract();
                        break;
                    case 11:
                        MemoryRecall();
                        break;
                    case 12:
                        MemoryClear();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Неверная операция");
                        break;
                }
            }
        }

        static bool CheckInput(out double num){
            string? input = Console.ReadLine();
            num = 0;
            
            if(string.IsNullOrWhiteSpace(input)){
                Console.WriteLine("Ошибка: пустой ввод!");
                return false;
            }
            
            if(input.Trim().Length < 1){
                Console.WriteLine("Ошибка: слишком короткий ввод!");
                return false;
            }
            
            if(!double.TryParse(input, out num)){
                Console.WriteLine("Ошибка: введите корректное число!");
                return false;
            }
            
            if(num > 10000 || num < -10000){
                Console.WriteLine("Ошибка: число должно быть от -10000 до 10000!");
                return false;
            }
            
            if(double.IsNaN(num) || double.IsInfinity(num)){
                Console.WriteLine("Ошибка: недопустимое значение!");
                return false;
            }
            
            return true;
        }

        static bool InputTwoNumbers(out double num1, out double num2)
        {
            num1 = num2 = 0;
            
            Console.WriteLine("Введите первое число: ");
            if(!CheckInput(out num1)){
                return false;
            }

            Console.WriteLine("Введите второе число: ");
            if(!CheckInput(out num2)){
                return false;
            }
            
            return true; 
        }

        static bool InputOneNumber(out double num1)
        {
            num1 = 0;
            
            Console.WriteLine("Введите число: ");
            if(!CheckInput(out num1)){
                return false;
            }
            
            return true;
        }

        static void MemoryAdd(){
            Console.WriteLine("Введите число для добавления в память: ");
            if(CheckInput(out double value)){
                memory += value;
                Console.WriteLine($"M+ {memory}.");
            }
        }

        static void MemorySubtract(){
            Console.WriteLine("Введите число для вычитания из памяти: ");
            if(CheckInput(out double value)){
                memory -= value;
                Console.WriteLine($"M- {memory}.");
            }
        }

        static void MemoryRecall(){
            Console.WriteLine($"MR {memory}.");
        }

        static void MemoryClear(){
            memory = 0;
            Console.WriteLine($"MC {memory}.");
        }
    }
}