using System;
using System.Collections.Generic;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
}

public class StudentComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        int markCompare = y.Marks.CompareTo(x.Marks);

        if (markCompare != 0)
            return markCompare;

        return x.Age.CompareTo(y.Age);
    }
}

public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student { Name = "Amit", Age = 21, Marks = 85 },
            new Student { Name = "Rohit", Age = 20, Marks = 90 },
            new Student { Name = "Neha", Age = 19, Marks = 90 },
            new Student { Name = "Pooja", Age = 22, Marks = 85 }
        };

        students.Sort(new StudentComparer());

        foreach (var s in students)
        {
            Console.WriteLine(s.Name + " " + s.Age + " " + s.Marks);
        }
    }
}
