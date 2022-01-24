using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fields;

namespace MarineShips
{
    public class Ship
    {
        public int Speed { get; set; }
        public List<int> Location { get; set; }
        public List<int> Index { get; set; }

        public double Length(List<int> location)
        {
            double l = Math.Sqrt(Math.Pow(location[0] - location[2], 2) - Math.Pow(location[1] - location[3], 2));
            if (l != 0.0)
            {
                return l;
            }
            else
            {
                return 1.0;
            }
        }
    }

    public class BattleShip : Ship
    {
        public double AttackLength()
        {
            double l = Length(Location) + 10 - Speed;
            if (l >= 0)
            {
                return l;
            }
            else
            {
                return 0;
            }
        }
        public void Attack(double AttackLength) { }
    }

    public class SupportShip : Ship
    {
        public double FixLength()
        {
            double l = Length(Location) + 10 - Speed;
            if (l >= 0)
            {
                return l;
            }
            else
            {
                return 0;
            }
        }
        public void Fix(double FixLength) { }
    }

    public class MixedShip : Ship
    {
        public double FixOrAttackLength()
        {
            double l = Length(Location) + 5 - Speed;
            if (l >= 0)
            {
                return l;
            }
            else
            {
                return 0;
            }
        }
        public void Attack(double FixOrAttackLength) { }
        public void Fix(double FixOrAttackLength) { }
    }

}