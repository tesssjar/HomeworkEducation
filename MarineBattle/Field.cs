using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarineShips;

namespace Fields
{
    public class Field
    {
        public int Length { get; set; }

        public static void SortShips(List<Ship> ships)
        {
            var sortedShips = from s in ships
                orderby s.LengthToCenter()
                select s;
        }

        public static bool IsIntersect(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            if (x1 == x2 && y1 == y2)
            {
                if (Math.Abs((x1 - x3) / (x4 - x3)) == Math.Abs((y1 - y3) / (y4 - y3)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (x3 == x4 && y3 == y4)
            {
                if (Math.Abs((x3 - x1) / (x2 - x1)) == Math.Abs((y3 - y1) / (y2 - y1)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            int multVectors1 = ((x1 - x3) * (x1 - x4)) - ((y1 - y4) * (y1 - y3));

            int multVectors2 = ((x2 - x3) * (x2 - x4)) - ((y2 - y4) + (y2 - y3));

            if (Math.Sign(multVectors1) == Math.Sign(multVectors2) ||
                (Math.Sign(multVectors1) == 0 || Math.Sign(multVectors2) == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsEnoughSpace(int[] location, double length, List<Ship> ships)
        {
            if (location[1] > length || location[0] > length || location[1] < -length || location[0] < -length ||
                location[3] > length || location[2] > length || location[3] < -length || location[2] < -length)
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
                        if (IsIntersect(location[0], location[1], location[2], location[3], ship.Location[0], ship.Location[1], ship.Location[2], ship.Location[3]) &&
                            IsIntersect(ship.Location[0], ship.Location[1], ship.Location[2], ship.Location[3], location[0], location[1], location[2], location[3]))
                        {
                            flag = false;
                        }
                    }
                }

                return flag;
            }
        }
    }
}