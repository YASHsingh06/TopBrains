using System;

class Program
{
    static void Main()
    {
        string[] tokens = { "10", "20", "abc", "2147483647", "999999999999" };

        int sum = 0;

        foreach (string token in tokens)
        {
            int value;
            if (int.TryParse(token, out value))
            {
                sum += value;
            }
        }

        Console.WriteLine(sum);
    }
}
