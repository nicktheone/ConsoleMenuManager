namespace ConsoleMenuManager
{
    public abstract class Page
    {
        private readonly string prompt;
        private readonly List<Option> options;

        public Page(string prompt, List<Option> options)
        {
            this.prompt = prompt;
            this.options = options;
        }

        public void Display()
        {
            Console.WriteLine(prompt);
            Console.WriteLine("-----");
            Console.WriteLine();
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {options[i].name}");
            }
            Console.WriteLine();
            Console.WriteLine("Choose an option:");
            var input = Console.ReadLine();
            int menuChoice;
            while (!int.TryParse(input, out menuChoice) || menuChoice < 1 || menuChoice > options.Count)
            {
                Console.WriteLine();
                Console.WriteLine($"Please enter an integer number between 1 and {options.Count}:");
                input = Console.ReadLine();
            }
            Console.WriteLine();
            options[menuChoice - 1].callback.Invoke();
        }
    }
}