using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Два садовника оформляют сад.");
            Garden garden = new Garden();
            garden.Print();
            Console.WriteLine("Задайте скорость первого садовника целым числом от 1 до 10");
            int s1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Задайте символ, в виде которого будет делать кусты первый садовник");
            char c1 = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Отлично! Теперь то же самое, но для второго садовника");
            Console.WriteLine("Задайте скорость второго садовника целым числом от 1 до 10");
            int s2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Задайте символ, в виде которого будет делать кусты второй садовник");
            char c2 = Convert.ToChar(Console.ReadLine());

            Gardener gardener1 = new Gardener(garden,s1,c1);
            Gardener gardener2 = new Gardener(garden, s2, c2, true);


            void Plant(Garden currentGarden, Gardener currentGardener)
            {
                while (!currentGarden.Finished())
                {
                    if (currentGarden.GetPlace(currentGardener.position[0], currentGardener.position[1]) == "0")
                    {
                        currentGarden.ChangePlace(currentGardener.position[0], currentGardener.position[1], currentGardener.Perform());
                        currentGardener.Move();
                        Thread.Sleep(currentGardener.Speed*100);
                    }
                    else
                    {
                        currentGardener.Move();
                    }
                }
            }

            void Plant1() => Plant(garden, gardener1);
            void Plant2() => Plant(garden, gardener2);

            ThreadStart threadStart1 = new ThreadStart(Plant1);
            ThreadStart threadStart2 = new ThreadStart(Plant2);
            Thread thread1 = new Thread(threadStart1);
            Thread thread2 = new Thread(threadStart2);
            thread1.Start();
            thread2.Start();

            while (!garden.Finished())
            {
                Console.Clear();
                garden.Print();
                Thread.Sleep(10);
            }

            Console.WriteLine("Работа над садом закончена!");
            Console.ReadKey();
        }
    }
}


