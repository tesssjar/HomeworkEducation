using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var field = new Field();
            field.Length = int.Parse(Console.ReadLine());

            List<Ship> ships = new List<Ship>();

        ShipCreation:

            Console.WriteLine("Enter the type of the ship (1 - battle ship, 2 - support ship, 3 - mixed ship)");
            Ship ship = new Ship();

            switch (Console.ReadLine())
            {
                case "1":
                    ship = new BattleShip();
                    break;
                case "2":
                    ship = new SupportShip();
                    break;
                case "3":
                    ship = new MixedShip();
                    break;
                default:
                    Console.WriteLine("Invalid type of ship!");
                    goto ShipCreation;
            }

            Console.WriteLine("Enter the speed of the ship");

            ship.Speed = int.Parse(Console.ReadLine());

        LocationSet:

            Console.WriteLine("Enter the location of the ship (x1, y1, x2, y2)");
            var location = new int[4];
            for (int i = 0; i < 4; i++)
            { 
                location[i] = int.Parse(Console.ReadLine());
            }

            ship.Location = location;

            if (field.IsEnoughSpace(ship.Location, field.Length, ships))
            {
                ships.Add(ship);
            }
            else
            {
                Console.WriteLine("Can't set the ship here!");
                goto LocationSet;
            }

            double[] center = ship.Center(ship.Location);

            switch (center)
            {
                case var _ when center[0] > 0 && center[1] > 0:
                    ship.Index = new double[3] { 1, center[0], center[1] };
                    break;
                case var _ when center[0] > 0 && center[1] < 0:
                    ship.Index = new double[3] { 4, center[0], center[1] };
                    break;
                case var _ when center[0] < 0 && center[1] > 0:
                    ship.Index = new double[3] { 2, center[0], center[1] };
                    break;
                case var _ when center[0] < 0 && center[1] < 0:
                    ship.Index = new double[3] { 3, center[0], center[1] };
                    break;
                default:
                    ship.Index = new double[3] { 0, center[0], center[1] };
                    break;
            }

        NewAction:

            Console.WriteLine("What do you want to do next? (1 - add a new ship, 2 - field info, 3 - do an action)");

            switch (Console.ReadLine())
            {
                case "1":
                    goto ShipCreation;
                case "2":
                    Console.WriteLine("Mind that 0 quadrant means that the center of the ship is located on the asymptote");
                    Field.SortShips(ships);
                    foreach (var anyShip in ships)
                    {
                        Console.WriteLine($"Type of ship: {anyShip.GetType()}");
                        Console.WriteLine($"Speed: {anyShip.Speed}");
                        Console.WriteLine($"Length of action: {anyShip.ActionLength()}");
                        Console.WriteLine($"Quadrant: {anyShip.Index[0]}");
                        Console.WriteLine($"Center location: {anyShip.Index[1]}, {anyShip.Index[2]}");
                        Console.WriteLine();
                    }

                    break;

                case "3":
                    Console.WriteLine("Pick a ship from the list:");
                    int i = 0;
                    foreach (var anyShip in ships)
                    {
                        Console.WriteLine($"Ship №{i}");
                        Console.WriteLine($"Quadrant: {anyShip.Index[0]}");
                        Console.WriteLine($"Center location: {anyShip.Index[1]}, {anyShip.Index[2]}");
                        Console.WriteLine();
                        i++;
                    }

                    Console.WriteLine("Quadrant:");

                    int quadrant = int.Parse(Console.ReadLine());

               ShipChoose:

                    bool shipExist = false;

                    Console.WriteLine("Coordinates:");

                    double x = double.Parse(Console.ReadLine());
                    double y = double.Parse(Console.ReadLine());

                    foreach (var anyShip1 in ships)
                    {
                        if (anyShip1.Index[0] == quadrant && anyShip1.Index[1] == x && anyShip1.Index[2] == y)
                        {
                            shipExist = true;

                            ActionCheck:

                            Console.WriteLine("Do you want to check? (check for equality/unequality, action)");

                            switch (Console.ReadLine())
                            {
                                case "equality":
                                    foreach (var anyShip2 in ships)
                                    {
                                        if (anyShip1 == anyShip2)
                                        {
                                            Console.WriteLine($"Ship in quadrant {anyShip2.Index[0]} and with coordinates {anyShip2.Index[1]}, {anyShip2.Index[2]} is equal to yours");
                                        }
                                    }

                                    break;

                                case "unequality":
                                    foreach (var anyShip2 in ships)
                                    {
                                        if (anyShip1 != anyShip2)
                                        {
                                            Console.WriteLine($"Ship in quadrant {anyShip2.Index[0]} and with coordinates {anyShip2.Index[1]}, {anyShip2.Index[2]} is unequal to yours");
                                        }
                                    }

                                    break;

                                case "action":
                                    anyShip1.Action(anyShip1.ActionLength());
                                    break;

                                default:
                                    Console.WriteLine("Undefined statement!");
                                    goto ActionCheck;
                            }
                        }

                        if (!shipExist)
                        {
                            Console.WriteLine("This ship does not exist!");
                            goto ShipChoose;
                        }
                    }

                    break;
            }

            Console.WriteLine("What do you want to do next? (1 - return to global actions, any other key - end a program)");

            if (Console.ReadLine() == "1")
            {
                goto NewAction;
            }
        }
    }
}