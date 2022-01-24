using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarineShips;

namespace Fields
{
    public class IsIntersected
    {
        public static bool IsIntersect(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            int k1 = (x2 - x1) / (y2 - y1);
            int k2 = (x4 - x3) / (y4 - y3);
            if (k1 == k2)
            {
                if (x1 / y1 == x3 / y3)
                {
                    if ((x1 < x2 && ((x1 < x3 && x2 > x3) || (x1 < x4 && x2 > x4))) ||
                        (x1 > x2 && ((x1 > x3 && x2 < x3) || (x1 > x4 && x2 < x4))))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                int x = ((x1 * y2 - x2 * y1) * (x4 - x3) - (x3 * y4 - x4 * y3) * (x2 - x1)) / ((y1 - y2) * (x4 - x3) - (y3 - y4) * (x2 - x1));
                int y = ((y3 - y4) * x - (x3 * y4 - x4 * y3)) / (x4 - x3);

                if (((x1 <= x) && (x2 >= x) && (x3 <= x) && (x4 >= x)) ||
                    ((y1 <= y) && (y2 >= y) && (y3 <= y) && (y4 >= y)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    public class Field
    {
        public Field(int Length)
        {
            Length = Length;
        }

        public int Length { get; set; }
        public List<Ship> ships { get; set; }

        public bool IsEnoughSpace(List<int> Location, double Length, List<Ship> ships)
        {
            if (Location[1] > Length || Location[0] > Length || Location[1] < -Length || Location[0] < -Length ||
                Location[3] > Length || Location[2] > Length || Location[3] < -Length || Location[2] < -Length)
            {
                return false;
            }
            else
            {
                bool flag = true;
                if (ships.Count != 0)
                {
                    foreach (var ship in ships)
                    {
                        if (!IsIntersected.IsIntersect(Location[0], Location[1], Location[2], Location[3],
                                ship.Location[0], ship.Location[1], ship.Location[2], ship.Location[3]))
                        {
                            flag = false;
                        }
                    }
                }

                return flag;
            }
        }
        public void AddShip(Ship ship, List<Ship> ships, List<int> location)
        {
            Console.WriteLine("Enter the position of the ship. Mind that the position is defined by ship's coordinates (x1,y1,x2,y2)!");
            for (int i = 0; i < 4; i++)
            {
                location.Add(int.Parse(Console.ReadLine()));
            }

            if (IsEnoughSpace(ship.Location, Length, ships))
            {
                ships.Add(ship);
            }
            else
            {
                Console.WriteLine("Cant set the ship here!");
            }
        }
    }
}