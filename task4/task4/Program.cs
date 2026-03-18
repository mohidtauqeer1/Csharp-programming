using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task4
{

    class Student
    {
        public string Name;
        public double Marks;

        public Student(string name, double marks)
        {
            Name = name;
            Marks = marks;
        }

        public double Aggregate() => Marks;
    }

    class StudentManagement
    {
        static List<Student> students = new List<Student>();

        static void AddStudent()
        {
            Console.Write("Enter student name  : ");
            string name = Console.ReadLine();
            Console.Write("Enter marks (0-100) : ");
            double marks = double.Parse(Console.ReadLine());
            students.Add(new Student(name, marks));
            Console.WriteLine("Student added successfully!");
        }

        static void ShowStudents()
        {
            if (students.Count == 0) { Console.WriteLine("No students found."); return; }
            Console.WriteLine(" All Students ");
            for (int i = 0; i < students.Count; i++)
                Console.WriteLine((i + 1) + ". " + students[i].Name + " - Marks: " + students[i].Marks);
        }

        static void CalculateAggregate()
        {
            if (students.Count == 0) { Console.WriteLine("No students found."); return; }
            double total = 0;
            foreach (Student s in students) total += s.Aggregate();
            Console.WriteLine("Class Average: " + (total / students.Count).ToString("F2"));
        }

        static void TopStudents()
        {
            if (students.Count == 0) { Console.WriteLine("No students found."); return; }
            Student top = students[0];
            foreach (Student s in students)
                if (s.Marks > top.Marks) top = s;
            Console.WriteLine("Top Student: " + top.Name + " with " + top.Marks + " marks");
        }

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n Student Management ");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show Students");
                Console.WriteLine("3. Calculate Aggregate");
                Console.WriteLine("4. Top Student");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddStudent(); break;
                    case 2: ShowStudents(); break;
                    case 3: CalculateAggregate(); break;
                    case 4: TopStudents(); break;
                    case 0: Console.WriteLine("Exiting..."); break;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
            } while (choice != 0);
        }
    }
}