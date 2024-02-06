//===================================================================================================
// Задание 1. Игра «Автомобильные гонки». 
// Разработать игру "Автомобильные гонки" с использованием делегатов.
// 1. В игре использовать несколько типов автомобилей: спортивные, легковые, грузовые и автобусы.
// 2. Реализовать игру «Гонки». Принцип игры: Автомобили двигаются от старта к финишу со скоростями,
// которые изменяются в установленных пределах случайным образом. Победителем считается автомобиль,
// пришедший к финишу первым.
//===================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    internal class Program
    {
        static void Sort(Car[] arr)
        {
            bool cycle = true;
            while(cycle)
            {
                cycle = false;
                for (int c = 0; c < arr.Length - 1; c++) 
                {
                    if(arr[c] > arr[c+1])
                    {
                        Car temp = arr[c + 1];
                        arr[c + 1] = arr[c];
                        arr[c] = temp;
                        cycle = true;
                    }
                }
            }
        }

        static void Main()
        {
            try
            {
                Console.WriteLine("Приложение гонки");
                Console.Write("Введите количество кругов: ");
                int lap = Convert.ToInt32(Console.ReadLine());

                Car[] car = new Car[] { new Bus("VolgaBus", 20, 130),
                                    new Lorry("Kamaz Sport", 16, 163),
                                    new SUV("Land Cruiser Prado", 13.8, 165),
                                    new SportCar("Vesta Sport TCR", 4.6, 250)};

                Race race = new Race();

                // 
                foreach (var item in car)
                {
                    race.startRace += item.Start;
                    race.stopRace += item.Finish;
                }

                //
                race.Start(lap);

                //
                race.Finish();

                //
                Console.Clear();
                Sort(car);
                for(int c = 0; c < car.Length; c++)
                {
                    Console.WriteLine("{0,-8}{1,-2}{2,-7}{3,-25}{4,-12}{5,3}{6,0}","Место: ", c+1, "Name: ", car[c].Name, "Total time: ", car[c].TotalTime / 1000, " сек");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
