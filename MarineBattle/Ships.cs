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

        public int[] Location { get; set; }

        public double[] Index { get; set; }
        
        public static bool operator ==(Ship ship1, Ship ship2)
        {
            return ((ship1.GetType() == ship2.GetType()) &&
                    (ship1.Length(ship1.Location) == ship2.Length(ship2.Location)) &&
                    (ship1.Speed == ship2.Speed))
                ? true
                : false;
        }

        public static bool operator !=(Ship ship1, Ship ship2)
        {
            return ((ship1.GetType() == ship2.GetType()) &&
                    (ship1.Length(ship1.Location) == ship2.Length(ship2.Location)) &&
                    (ship1.Speed == ship2.Speed))
                ? false
                : true;
        }

        public double Length(int[] location)
        {
            double l = Math.Sqrt(Math.Pow(location[0] - location[2], 2) - Math.Pow(location[1] - location[3], 2));
            return l;
        }

        public double[] Center(int[] location)
        {
            double[] center = new double[2];
            center[0] = (location[0] + location[2]) / 2.0;
            center[1] = (location[1] + location[3]) / 2.0;
            return center;
        }

        public double LengthToCenter()
        {
            double l = Math.Sqrt(Math.Pow(this.Center(this.Location)[0] - 0, 2) -
                                 Math.Pow(this.Center(this.Location)[1] - 0, 2));
            return l;
        }

        public virtual double ActionLength()
        {
            return 0;
        }

        public virtual void Action(double actionLength) { }
    }

    public class BattleShip : Ship
    {
        public override double ActionLength()
        {
            double l = this.Length(this.Location) + 10 - this.Speed;
            if (l >= 0)
            {
                return l;
            }
            else
            {
                return 0;
            }
        }

        public override void Action(double attackLength) { }
    }

    public class SupportShip : Ship
    {
        public static void ShipType(Ship ship)
        {
            ship = new SupportShip();
        }

        public override double ActionLength()
        {
            double l = this.Length(this.Location) + 10 - this.Speed;
            if (l >= 0)
            {
                return l;
            }
            else
            {
                return 0;
            }
        }

        public override void Action(double fixLength) { }
    }

    public class MixedShip : Ship
    {
        public bool ActionType { get; set; }

        public override double ActionLength()
        {
            double l = this.Length(this.Location) + 5 - this.Speed;
            if (l >= 0)
            {
                return l;
            }
            else
            {
                return 0;
            }
        }

        public override void Action(double fixOrAttackLength) { }
    }

}