namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задача А

            // Задание 1
            int[] fibonacci = new int[8];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            for (int i = 2; i < fibonacci.Length; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }

            Console.WriteLine("Task 1. Fibonacci array: " + string.Join(", ", fibonacci));

            // Задание 2
            string[] months = new string[]
            {
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
            };
            Console.WriteLine("Task 2. Months array: " + string.Join(", ", months));

            // Задание 3
            int[,] matrix = new int[3, 3]
            {
                { 2, 3, 4 },
                { 2*2, 3*3, 4*4 },
                { 2*2*2, 3*3*3, 4*4*4 }
            };
            Console.WriteLine("Task 3. Matrix 3x3:");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Задание 4
            double[][] jaggedArray = new double[3][];
            jaggedArray[0] = new double[] { 1, 2, 3, 4, 5 };
            jaggedArray[1] = new double[] { Math.E, Math.PI };
            jaggedArray[2] = new double[]
            {
                Math.Log10(1),
                Math.Log10(10),
                Math.Log10(100),
                Math.Log10(1000)
            };

            Console.WriteLine("Task 4. Jagged array:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(", ", jaggedArray[i]));
            }

            // Задача Б

            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

            // Задание 5
            Array.Copy(array, array2, 3);
            Console.WriteLine("Task 5. Array2: " + string.Join(", ", array2));

            // Задание 6
            Array.Resize(ref array, array.Length * 2);
            Console.WriteLine("Task 6. Resized array: " + string.Join(", ", array));
        }
    }
}