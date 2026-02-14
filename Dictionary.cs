using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        List<int> ids = new List<int> { 1, 4, 5 };


        Dictionary<int, int> empSalary = new Dictionary<int, int>()
        {
            {1, 20000},
            {4, 40000},
            {5, 15000}
        };

        int totalSalary = 0;

        foreach (int id in ids)
        {
            if (empSalary.ContainsKey(id))
            {
                totalSalary += empSalary[id];
            }
        }

        Console.WriteLine(totalSalary);
    }
}
