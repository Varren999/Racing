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
        static void Main(string[] args)
        {
            SportCar vesta = new SportCar("Vesta Sport TCR", 4.6, 250);
            SUV landCruiser = new SUV("Land Cruiser Prado", 13.8, 165);
            Bus volgaBus = new Bus("VolgaBus", 0, 0);
            Lorry kamaz = new Lorry("Kamaz", 0, 0);
            vesta.Trassa();
            
            //car.Trassa();
        }
    }
}
