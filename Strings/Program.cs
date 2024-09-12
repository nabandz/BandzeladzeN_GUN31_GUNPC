using System.Text;

// Задание 1
string ConcatenateStrings(string str1, string str2)
{
    return str1 + str2;
}
Console.WriteLine(ConcatenateStrings("Hello, ", "world!"));

// Задание 2
string GreetUser(string name, int age)
{
    return $"Hello, {name}! You are {age} years old.\n";
}
Console.WriteLine(GreetUser("Natasha", 25));

// Задание 3
string AnalyzeString(string input)
{
    return $"Number of characters: {input.Length}\n" +
           $"Upper case: {input.ToUpper()}\n" +
           $"Lower case: {input.ToLower()}";
}
Console.WriteLine(AnalyzeString("Hello, world!"));

// Задание 4
string GetFirstFiveCharacters(string input)
{
    return input.Length >= 5 ? input.Substring(0, 5) : input;
}
Console.WriteLine(GetFirstFiveCharacters("Hello, world!"));

// Задание 5
StringBuilder ConcatenateStringsArray(string[] inputArray)
{
    var strBuilder = new StringBuilder();
    foreach (var str in inputArray)
    {
        strBuilder.Append(str).Append(' ');
    }
    return strBuilder;
}
var resultStringBuilder = ConcatenateStringsArray(new[] { "Hello,", "world!"});
Console.WriteLine(resultStringBuilder.ToString().Trim());

// Задание 6
string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
{
    return inputString.Replace(wordToReplace, replacementWord);
}
Console.WriteLine(ReplaceWords("Hello, world!", "world", "Natasha"));
