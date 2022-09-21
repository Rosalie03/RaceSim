using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Car : IEquiqement
    {
        public int Quility { get; set; }
        public int Performance { get; set; }
        public int Speed { get; set; }
        public bool IsBroken { get; set; }

        public Car(int quility, int performance, int speed, bool isBroken)
        {
            this.Quility = quility;
            this.Performance = performance;
            this.Speed = speed;
            this.IsBroken = isBroken;
        }
    }
}
