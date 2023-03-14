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
            Random rand = new Random();
            float health1 = rand.Next(90, 100);
            int damage1 = rand.Next(7, 20);
            int armore1 = rand.Next(30, 60);

            float health2 = rand.Next(90, 100); 
            int damage2 = rand.Next(7, 20);
            int armore2 = rand.Next(30, 60);


            Console.WriteLine($"Первый гладиатор имеет {health1} здоровья, бьёт с силой в {damage1} единиц силы и имеет броню {armore1} ");
            Console.WriteLine($"Второй гладиатор имеет {health2} здоровья, бьёт с силой в {damage2} единиц силы и имеет броню {armore2} ");

            while (health1 > 0 && health2 > 0)
            {

                health1 -= Convert.ToSingle(rand.Next(0, damage2 + 1)) / 100 * armore1;
                health2 -= Convert.ToSingle(rand.Next(0, damage1 + 1)) / 100 * armore2;

                Console.WriteLine("Здоровье первого гладиатора  " + health1);
                Console.WriteLine("Здоровье второго гладиатора  " + health2);

            }

            if (health1 < 0 && health2 < 0)
            {
                Console.WriteLine("Ничья, все погибли");

            }
            else if (health1 <= 0)
            {
                Console.WriteLine("Гладиатор один пал");

            }
            else if (health2 <= 0)
            {
                Console.WriteLine("Гладиатор два пал");

            }
             //nhjbhjdiashidhasihjio
            Console.WriteLine("Git Блин");
            Console.ReadKey();










        }
    }
}
