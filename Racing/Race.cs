using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    internal class Race
    {
        public delegate void delRace(int lap);
        public delegate void delFinRace();
        public event delRace startRace;
        public event delFinRace stopRace;

        public void Start(int countLap)
        {
            if (startRace != null)
                startRace(countLap);
        }

        public void Finish()
        {
            if (stopRace != null)
                stopRace();
        }
    }
}
