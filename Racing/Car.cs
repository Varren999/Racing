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
        readonly double maxspeed;
        readonly double acceleration;

        string Name
        {
            get { return name; }
            set { name = value; }
        }

        double Speed
        {
            get { return speed; }
            set 
            {
                speed = value;
                if (speed >= maxspeed)
                {
                    speed = maxspeed;
                }
            }
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

        void Drive(double Distance, double MaxSpeed) 
        {
            var timer = new Stopwatch();
            timer.Start();
            var lastTime = timer.ElapsedMilliseconds;
            do
            {
                if ((timer.ElapsedMilliseconds - lastTime) > 1000)
                {
                    Console.WriteLine($"Speed: {(int)speed}\t Time: {lastTime / 1000} сек.\t Mileage: {(int)mileage}");
                    if (Speed < MaxSpeed)
                    {
                        Speed += acceleration;
                        if(speed >= MaxSpeed)
                           speed = MaxSpeed; 
                    }
                    lastTime = timer.ElapsedMilliseconds;
                    mileage += (speed / 3.6);
                    
                }
            }
            while (mileage < Distance);
            timer.Stop();
            Mileage = 0;
        }

        public void Trassa()
        {
            var timer = new Stopwatch();
            int lap = 0;
            int final = 2;
            timer.Start();
            var timeLap = timer.ElapsedMilliseconds;
            Console.WriteLine("Старт");
            while (lap <= final)
            {
                Drive(1200, 500);
                Drive(300, 70);
                Drive(1200, 500);
                Drive(300, 70);
                lap++;
                timeLap = timer.ElapsedMilliseconds - timeLap;
                Console.WriteLine($"Lap: {lap}\t Time lap: {timeLap / 1000} сек.");
            }
            Console.WriteLine("Финиш");
            timer.Stop();
            Console.WriteLine($"Total Time: {timer.ElapsedMilliseconds / 1000} сек.");
        }
    }
}
