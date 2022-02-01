namespace ConsoleMenuManager
{
    public class Option
    {
        internal readonly string name;
        internal readonly Action callback;
        public Option(string name, Action callback)
        {
            this.name = name;
            this.callback = callback;
        }
    }
}