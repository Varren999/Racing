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

        //
        void Drive(double Distance, double MaxSpeed) 
        {
            var timer = new Stopwatch();
            long lastTime = timer.ElapsedMilliseconds;
            timer.Start();
            do
            {
                if ((timer.ElapsedMilliseconds - lastTime) > 1000)
                {
                    //Console.WriteLine($"Speed: {(int)speed}\t Time: {lastTime / 1000} сек.\t Mileage: {(int)mileage}");
                    if (Speed <= maxspeed)
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

        //
        public void Trassa()
        {
            var timer = new Stopwatch();
            int final = 3;          
            long totalTime = 0;

            Console.WriteLine("Старт");
            for(int lap = 1; lap <= final; lap++)
            {
                timer.Start();
                Drive(1200, 500);
                Drive(300, 70);
                Drive(1200, 500);
                Drive(300, 70);
                timer.Stop();
                totalTime += timer.ElapsedMilliseconds;
                Console.WriteLine($"Name: {name}\tLap: {lap}\t Time lap: {timer.ElapsedMilliseconds / 1000} сек.");
                timer.Reset();
            }
            Console.WriteLine("Финиш");
            Console.WriteLine($"Name: {name}\tTotal Time: {totalTime / 1000} сек.");
        }
    }
}
