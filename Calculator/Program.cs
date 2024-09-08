class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the first number:");
        if (!int.TryParse(Console.ReadLine(), out int firstNumber))
        {
            Console.WriteLine("Invalid input for the first number.");
            return;
        }

        Console.WriteLine("Enter the second number:");
        if (!int.TryParse(Console.ReadLine(), out int secondNumber))
        {
            Console.WriteLine("Invalid input for the second number.");
            return;
        }

        Console.WriteLine("Enter an operator (&, |, ^):");
        string userOperator = Console.ReadLine();

        if (userOperator != "&" && userOperator != "|" && userOperator != "^")
        {
            Console.WriteLine("Invalid operator.");
            return;
        }

        int result = 0;

        switch (userOperator)
        {
            case "&":
                result = firstNumber & secondNumber;
                break;
            case "|":
                result = firstNumber | secondNumber;
                break;
            case "^":
                result = firstNumber ^ secondNumber;
                break;
        }

        // Вывод результата в десятичной, двоичной и шестнадцатеричной форме
        Console.WriteLine($"Result (decimal): {result}");
        Console.WriteLine($"Result (binary): {Convert.ToString(result, 2)}");
        Console.WriteLine($"Result (hexadecimal): {Convert.ToString(result, 16)}");
    }
}