namespace ConsoleMenuManager
{
    public class Option
    {
        internal readonly string name;
        internal readonly Func<Task> callback;
        public Option(string name, Func<Task> callback)
        {
            this.name = name;
            this.callback = callback;
        }
    }
}