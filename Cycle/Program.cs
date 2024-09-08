namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            int[] fibonacci = new int[10];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            for (int i = 2; i < fibonacci.Length; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }

            Console.WriteLine("Task 1. Fibonacci array: " + string.Join(", ", fibonacci));

            // Задание 2
            Console.WriteLine("Task 2. Even numbers from 2 to 20:");
            for (int i = 2; i <= 20; i += 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // Задание 3
            Console.WriteLine("Task 3. Multiplication table (1 to 5):");
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write(i * j + "\t");
                }

                Console.WriteLine();
            }

            // Задание 4
            string password = "qwerty";
            string userInput;
            do
            {
                Console.WriteLine("Task 4. Enter the password:");
                userInput = Console.ReadLine();
            }
            while (userInput != password);

            Console.WriteLine("Correct password");
        }
    }
}
