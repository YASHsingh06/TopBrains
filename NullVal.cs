using System;
using System.Linq;

public class Solution
{
    public static double? ComputeAverage(double?[] values)
    {
        var nonNullValues = values.Where(v => v.HasValue)
                                  .Select(v => v.Value)
                                  .ToArray();

        if (nonNullValues.Length == 0)
            return null;

        double avg = nonNullValues.Average();

        return Math.Round(avg, 2, MidpointRounding.AwayFromZero);
    }
}
