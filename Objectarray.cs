using System;

public class Solution
{
    public int SumIntegers(object[] values)
    {
        int sum = 0;

        foreach (object item in values)
        {
            if (item is int x)
            {
                sum += x;
            }
        }

        return sum;
    }
}
