internal class Program
{
    private class ListTask
    {
        private List<string> _listOfStrings = new List<string> { "Элемент1", "Элемент2", "Элемент3" };

        public void TaskLoop()
        {
            Console.WriteLine("Начальный список: ");
            foreach (var str in _listOfStrings)
            {
                Console.WriteLine(str);
            }

            while (true)
            {
                Console.WriteLine("Введите новую строку (или –exit для выхода): ");
                string input = Console.ReadLine();
                if (input == "-exit") break;

                _listOfStrings.Add(input);
                Console.WriteLine("Список после добавления:");
                foreach (var str in _listOfStrings)
                {
                    Console.WriteLine(str);
                }

                Console.WriteLine("Введите строку для добавления в середину списка:");
                input = Console.ReadLine();
                if (input == "-exit") break;

                _listOfStrings.Insert(_listOfStrings.Count / 2, input);
                Console.WriteLine("Список после добавления в середину:");
                foreach (var str in _listOfStrings)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }

    private class DictionaryTask
    {
        private readonly Dictionary<string, int> _students = new Dictionary<string, int>();

        public void TaskLoop()
        {
            while (true)
            {
                Console.WriteLine("Введите через пробел имя студента и его оценку (или –exit для выхода): ");
                string input = Console.ReadLine();
                if (input == "-exit") break;

                string[] parts = input.Split(' ');
                if (parts.Length != 2 || !int.TryParse(parts[1], out int grade) || grade < 2 || grade > 5)
                {
                    Console.WriteLine("Ошибка: оценка должна быть от 2 до 5.");
                    continue;
                }

                _students[parts[0]] = grade;

                Console.WriteLine("Введите имя студента для поиска:");
                input = Console.ReadLine();
                if (input == "-exit") break;

                if (_students.TryGetValue(input, out int studentGrade))
                {
                    Console.WriteLine($"Оценка студента {input}: {studentGrade}");
                }
                else
                {
                    Console.WriteLine("Студент с таким именем не найден.");
                }
            }
        }
    }

    private class DoublyLinkedListTask
    {
        private class Node
        {
            public string Data;
            public Node Next;
            public Node Prev;

            public Node(string data)
            {
                Data = data;
            }
        }

        private Node _head;
        private Node _tail;

        public void TaskLoop()
        {
            Console.WriteLine("Введите от 3 до 6 элементов для списка (или –exit для выхода):");
            for (int i = 0; i < 6; i++)
            {
                string input = Console.ReadLine();
                if (input == "-exit") break;

                Add(input);

                if (i >= 2)
                {
                    Console.WriteLine("Хотите ввести ещё один элемент? (y/n)");
                    if (Console.ReadLine() != "y") break;
                }
            }

            Console.WriteLine("Список в прямом порядке:");
            PrintForward();

            Console.WriteLine("Список в обратном порядке:");
            PrintBackward();
        }

        private void Add(string data)
        {
            var newNode = new Node(data);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }
        }

        private void PrintForward()
        {
            var current = _head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        private void PrintBackward()
        {
            var current = _tail;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Prev;
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите номер задачи (1, 2 или 3):");
        if (int.TryParse(Console.ReadLine(), out int task))
        {
            switch (task)
            {
                case 1:
                    var listTask = new ListTask();
                    listTask.TaskLoop();
                    break;
                case 2:
                    var dictionaryTask = new DictionaryTask();
                    dictionaryTask.TaskLoop();
                    break;
                case 3:
                    var doublyLinkedListTask = new DoublyLinkedListTask();
                    doublyLinkedListTask.TaskLoop();
                    break;
                default:
                    Console.WriteLine("Некорректный номер задачи.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод.");
        }
    }
}
