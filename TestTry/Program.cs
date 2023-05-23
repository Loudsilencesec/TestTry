using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Random rand = new Random();
            //float health1 = rand.Next(90, 100);
            //int damage1 = rand.Next(7, 20);
            //int armore1 = rand.Next(30, 60);

            //float health2 = rand.Next(90, 100); 
            //int damage2 = rand.Next(7, 20);
            //int armore2 = rand.Next(30, 60);


            //Console.WriteLine($"Первый гладиатор имеет {health1} здоровья, бьёт с силой в {damage1} единиц силы и имеет броню {armore1} ");
            //Console.WriteLine($"Второй гладиатор имеет {health2} здоровья, бьёт с силой в {damage2} единиц силы и имеет броню {armore2} ");

            //while (health1 > 0 && health2 > 0)
            //{

            //    health1 -= Convert.ToSingle(rand.Next(0, damage2 + 1)) / 100 * armore1;
            //    health2 -= Convert.ToSingle(rand.Next(0, damage1 + 1)) / 100 * armore2;

            //    Console.WriteLine("Здоровье первого гладиатора  " + health1);
            //    Console.WriteLine("Здоровье второго гладиатора  " + health2);

            //}

            //if (health1 < 0 && health2 < 0)
            //{
            //    Console.WriteLine("Ничья, все погибли");

            //}
            //else if (health1 <= 0)
            //{
            //    Console.WriteLine("Гладиатор один пал");

            //}
            //else if (health2 <= 0)
            //{
            //    Console.WriteLine("Гладиатор два пал");

            //}

            //Console.WriteLine("Git Блять");
            //Console.ReadKey();

            bool exit = false;

            Console.WriteLine("Простой калькулятор");
            Console.WriteLine("-------------------");
            Console.WriteLine();

            while (!exit)
            {
                double num1, num2;
                string operand;

                Console.Write("Введите первое число: ");
                if (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Некорректный ввод!");
                    continue;
                }

                Console.Write("Введите оператор (+, -, *, /): ");
                operand = Console.ReadLine();

                Console.Write("Введите второе число: ");
                if (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Некорректный ввод!");
                    continue;
                }

                double result = 0;

                switch (operand)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                        {
                            Console.WriteLine("Деление на ноль невозможно!");
                            continue;
                        }
                        break;
                    default:
                        Console.WriteLine("Некорректный оператор");
                        continue;
                }

                Console.WriteLine();
                Console.WriteLine("Результат: " + result);
                Console.WriteLine();

                Console.Write("Хотите продолжить использовать калькулятор? (y/n): ");
                string choice = Console.ReadLine();

                if (choice.ToLower() == "n")
                    exit = true;

                Console.WriteLine();
            }

            Console.WriteLine("До свидания!");
            Console.ReadLine();






        }
    }
}
