using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = " llapppptop bag ";


        string cleaned = Regex.Replace(input.Trim(), @"\s+", " ");


        StringBuilder resultBuilder = new StringBuilder();
        char previousChar = '\0';

        foreach (char currentChar in cleaned)
        {
            if (currentChar != previousChar)
            {
                resultBuilder.Append(currentChar);
                previousChar = currentChar;
            }
        }


        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string finalResult = textInfo.ToTitleCase(resultBuilder.ToString().ToLower());

        Console.WriteLine(finalResult);
    }
}
