namespace ConsoleMenuManager
{
    public class Page
    {
        private string title;
        private List<Option> options;

        public Page(string title, List<Option> options )
        {
            this.title = title;
            this.options = options;
        }

        public void Display()
        {

        }
    }
}