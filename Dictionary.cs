 using System.Collections.Generic;

public class Solution
{
    public int GetTotalSalary(List<int> ids, Dictionary<int, int> salaryDict)
    {
        int total = 0;

        foreach (int id in ids)
        {
            if (salaryDict.ContainsKey(id))
            {
                total += salaryDict[id];
            }
        }

        return total;
    }
}
