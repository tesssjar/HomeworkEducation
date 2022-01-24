using System;
using System.Collections.Generic;
using ClassStudent;
using ClassEmployer;
namespace Program
{
    public class Program
    {
        public static void Main()
        {
            bool flag;

            Console.WriteLine("Welcome to mine employee list constructor!");

        NewEmployer:

            Console.WriteLine("Enter the employer's name:");
            string EmployerName = Console.ReadLine();

            var employer = new Employer(EmployerName);

            employer.Name = EmployerName;
            employer.Employee = new List<Student>();

        NewStudent:

            var student = new Student();

            Console.WriteLine("Student info:");

            Console.WriteLine("Enter the name:");

            student.Name = Console.ReadLine();

            Console.WriteLine("Enter the age:");

            do
            {
                flag = int.TryParse(Console.ReadLine(), out int age);
                if (flag) { student.Age = age; }
                else { Console.WriteLine("Incorrect age!"); }
            }
            while (!flag);

            Console.WriteLine("Enter the sex (female/male):");
            do
            {
                var sex = Console.ReadLine();
                if (sex == "male" || sex == "female")
                {
                    student.Sex = sex;
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Incorrect sex!");
                    flag = false;
                }
            }
            while (!flag);

            Console.WriteLine("Enter the kdm mark:");
            do
            {
                flag = int.TryParse(Console.ReadLine(), out int KdmMark);
                if (flag)
                {
                    student.KdmMark = KdmMark;
                }
                else
                {
                    Console.WriteLine("Incorrect mark!");
                }
            }
            while (!flag);

            Console.WriteLine("Enter the vm mark:");
            do
            {
                flag = int.TryParse(Console.ReadLine(), out int VmMark);
                if (flag)
                {
                    student.VmMark = VmMark;
                }
                else
                {
                    Console.WriteLine("Incorrect mark!");
                }
            }
            while (!flag);

            Console.WriteLine("Index of happiness without overload:");

            Console.WriteLine(Student.IndexOfHappiness(student.KdmMark, student.VmMark));

            Console.WriteLine("Index of happiness with overload:");

            Console.WriteLine(Student.IndexOfHappiness(student.KdmMark, student.VmMark, student.Name, student.Sex));

            Employer.AddStudent(student, employer.Employee);

            Console.WriteLine("Salary for this student based on his marks:");

            Console.WriteLine(Employer.SalaryCount(student));

            Console.WriteLine("Enter 1 to add new employer, 2 - to add new student to a list, any other key - to exit");

            var NextMove = Console.ReadLine();

            if (NextMove == "1")
            {
                Console.WriteLine($"List of student names for the employer {employer.Name}:");
                foreach (Student stud in employer.Employee) { Console.WriteLine(stud.Name); }

                goto NewEmployer;
            }
            else
            {
                if (NextMove == "2")
                {
                    goto NewStudent;
                }
                else
                {
                    Console.WriteLine($"List of student names for the employer {employer.Name}:");

                    foreach (Student stud in employer.Employee) { Console.WriteLine(stud.Name); }

                    Console.WriteLine("Thanks for using my program!");
                }
            }
        }
    }
}