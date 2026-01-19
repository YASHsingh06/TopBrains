using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        string firstWord = Console.ReadLine();
        string secondWord = Console.ReadLine();


        HashSet<char> secondSet = new HashSet<char>();
        foreach (char ch in secondWord.ToLower())
        {
            secondSet.Add(ch);
        }

        StringBuilder afterRemoval = new StringBuilder();

        foreach (char ch in firstWord)
        {
            char lowerChar = char.ToLower(ch);

            if (IsConsonant(lowerChar) && secondSet.Contains(lowerChar))
            {
                continue; 
            }

            afterRemoval.Append(ch);
        }


        StringBuilder finalResult = new StringBuilder();

        for (int i = 0; i < afterRemoval.Length; i++)
        {
            if (i == 0 || afterRemoval[i] != afterRemoval[i - 1])
            {
                finalResult.Append(afterRemoval[i]);
            }
        }

        Console.WriteLine(finalResult.ToString());
    }

    static bool IsConsonant(char ch)
    {
        return char.IsLetter(ch) &&
               ch != 'a' && ch != 'e' && ch != 'i' &&
               ch != 'o' && ch != 'u';
    }
}
