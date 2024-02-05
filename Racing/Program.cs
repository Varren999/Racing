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
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    internal class Program
    {
        static void Main()
        {
            int lap = 3;
            Car[] car = new Car[] { new SportCar("Vesta Sport TCR", 4.6, 250),
                                    new SUV("Land Cruiser Prado", 13.8, 165),
                                    new Bus("VolgaBus", 20, 150),
                                    new Lorry("Kamaz", 20, 160)};

            Task[] task = new Task[car.Length];

            for(int c = 0; c < car.Length; c++)
            {
                task[c] = Task.Run(() => car[c].Start(lap));
            }

            //Task task1 = Task.Run(() => car[2].Start(lap));
            //Task task2 = Task.Run(() => car[3].Start(lap));
            //Task task3 = Task.Run(() => car[1].Start(lap));
            //Task task4 = Task.Run(() => car[0].Start(lap));
            Task.WaitAll(task);
            
            
        }
    }
}
