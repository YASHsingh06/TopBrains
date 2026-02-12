using System;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

public class Solution
{
    public record Student(string Name, int Score);

    public static string Process(string[] items, int minScore)
    {
        var students = items
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x =>
            {
                var parts = x.Split(':');
                return new Student(parts[0], int.Parse(parts[1]));
            })
            .Where(s => s.Score >= minScore)
            .OrderByDescending(s => s.Score)
            .ThenBy(s => s.Name)
            .ToList();

        return JsonSerializer.Serialize(students);
    }
}
