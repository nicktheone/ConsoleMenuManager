﻿namespace ConsoleMenuManager
{
    public abstract class Page
    {
        private readonly string prompt;
        private readonly List<Option> options;
        private readonly MenuManager menuManager;

        public Page(string prompt, List<Option> options, MenuManager menuManager)
        {
            this.prompt = prompt;
            this.options = options;
            this.menuManager = menuManager;
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
                Console.WriteLine($"Please enter an integer number between 1 and {options.Count}:");
                input = Console.ReadLine();
            }

            options[menuChoice - 1].callback.Invoke();
        }
    }
}