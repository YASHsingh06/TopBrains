using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int m = int.Parse(input[0]);
        int n = int.Parse(input[1]);

        int luckyCount = 0;

        for (int num = m; num <= n; num++)
        {
            if (!IsPrime(num))
            {
                int sumNum = SumOfDigits(num);
                int sumSquare = SumOfDigits(num * num);

                if (sumSquare == sumNum * sumNum)
                {
                    luckyCount++;
                }
            }
        }

        Console.WriteLine(luckyCount);
    }

    static int SumOfDigits(int number)
    {
        int sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }

    static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}
