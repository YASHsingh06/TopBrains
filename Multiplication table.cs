using System;

public class Solution
{
    public static int[] MultiplicationTable(int n, int upto)
    {
        int[] row = new int[upto];

        for (int i = 1; i <= upto; i++)
        {
            row[i - 1] = n * i;
        }

        return row;
    }

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int upto = int.Parse(Console.ReadLine());

        int[] result = MultiplicationTable(n, upto);

        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i]);

            if (i < result.Length - 1)
                Console.Write(" ");
        }
    }
}
