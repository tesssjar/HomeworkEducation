using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Fields;
using MarineShips;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter the length of the field:");
            var field = new Field(int.Parse(Console.ReadLine()));

        ShipCreation:

            Console.WriteLine("Enter the type of the ship (1 - battle ship, 2 - support ship, 3 - mixed ship)");
            Ship ship = new Ship();

            switch (Console.ReadLine())
            {
                case "1":
                    ship = (BattleShip)ship;
                    break;
                case "2":
                    ship = (SupportShip)ship;
                    break;
                case "3":
                    ship = (MixedShip)ship;
                    break;
                default:
                    Console.WriteLine("Invalid type of ship!");
                    goto ShipCreation;
            }

            List<Ship> ships = new List<Ship>();

            Console.WriteLine("Enter the location of the ship (x1, y1, x2, y2)");
            for (int i = 0; i < 4; i++)
            {
                ship.Location[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the speed of the ship");

            if (field.IsEnoughSpace(ship.Location, ship.Length(ship.Location), ships))
            {
                ships.Add(ship);
            }
            else
            {
                Console.WriteLine("Can't set the ship here!");
            }


        }
    }
}