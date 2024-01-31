using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{ 
    internal class Car
    {
        string name;
        double speed = 0;
        double mileage = 0;
        readonly double acceleration;
        readonly double maxspeed;

        string Name
        {
            get { return name; }
            set { name = value; }
        }

        double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        double Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }

        double Acceleration
        {
            get { return acceleration; }
        }

        double Maxspeed
        {
            get { return maxspeed; }
        }

        public Car(string Name, double Acceleration, double Maxspeed)
        {
            name = Name;
            maxspeed = Maxspeed;
            acceleration = 100 / Acceleration;
        }

        public void Drive(double Distance) 
        {
            var timer = new Stopwatch();
            timer.Start();
            var lastTime = timer.ElapsedMilliseconds;
            do
            {
                if ((timer.ElapsedMilliseconds - lastTime) > 1000)
                {
                    Console.WriteLine($"lastTime: {lastTime/1000} сек. \t speed: {(int)speed} км/ч\t mileage: {(int)mileage} м.");
                    if (speed < Maxspeed)
                    {
                        speed += acceleration;
                        if(speed >= Maxspeed)
                           speed = Maxspeed; 
                    }
                    lastTime = timer.ElapsedMilliseconds;
                    mileage += (speed / 3.6);
                }
            }
            while (mileage < Distance);
            timer.Stop();
            Console.WriteLine($"lastTime: {lastTime / 1000} сек. \t speed: {(int)speed} км/ч\t mileage: {(int)mileage} м.");
        }
    }
}
