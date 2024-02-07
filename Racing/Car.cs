using System;
using System.CodeDom.Compiler;
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
        long totalTime = 0;
        readonly double maxspeed;
        readonly double acceleration;
        Task item;

        Random random = new Random();

        public string Name
        {
            get { return name; }
        }

        public long TotalTime
        {
            get { return totalTime; }
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
            try
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
                            Speed += random.Next(0, (int)acceleration);
                            if (speed >= MaxSpeed)
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //
        public void Start(int countLap = 3)
        {
            try
            {
                item = Task.Run(() =>
                {
                    var timer = new Stopwatch();
                    totalTime = 0;
                    Console.WriteLine($"Старт {name}");
                    for (int lap = 1; lap <= countLap; lap++)
                    {
                        timer.Start();

                        Drive(1200, 500);
                        Drive(300, 70);
                        Drive(1200, 500);
                        Drive(300, 70);

                        timer.Stop();
                        totalTime += timer.ElapsedMilliseconds;
                        if(countLap > 1)
                            Console.WriteLine("{0,-7}{1,-25}{2,-5}{3,-3}{4,-10}{5,3}{6,0}","Name: ", name, "Lap: ", lap, "Time lap: ", timer.ElapsedMilliseconds / 1000, " сек.");
                        timer.Reset();
                    }
                Console.WriteLine("{0,-13}{1,-25}{2,-12}{3,3}{4,0}","Финиш  Name: ", name, "Total Time: ", totalTime / 1000, " сек.");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //
        public void Finish()
        {
            item.Wait();
        }

        //
        public static bool operator > (Car one, Car two)
        {
            return one.totalTime > two.totalTime;
        }

        //
        public static bool operator < (Car one, Car two)
        {
            return one.totalTime < two.totalTime;
        }
    }
}
