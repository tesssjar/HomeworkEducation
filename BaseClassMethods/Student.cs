using System;
using System.Collections.Generic;

namespace ClassStudent
{
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public int KdmMark { get; set; }

        public int VmMark { get; set; }

        public static double IndexOfHappiness(int KdmMark, int VmMark)
        {
            return Overall(KdmMark, VmMark);
        }

        public static double IndexOfHappiness(int KdmMark, int VmMark, string Name, string Sex)
        {
            if (Name == "Ivan")
            {
                Console.WriteLine("он просто хотел поиграть в доту...");

                return 1;
            }
            else
            {
                if (Sex == "female")
                {
                    Console.Write("Index for this girl is:");

                    return Overall(KdmMark, VmMark);
                }
                else
                {
                    Console.Write("Index for this man is:");

                    return Overall(KdmMark, VmMark);
                }
            }
        }

        private static double Overall(int KdmMark, int VmMark)
        {
            return ((double)KdmMark + (double)VmMark) / 2.0;
        }
    }
}