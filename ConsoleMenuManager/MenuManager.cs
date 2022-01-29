namespace ConsoleMenuManager
{
    public class MenuManager
    {
        private List<Page> pages;

        public MenuManager()
        {

        }

        public void AddPage(Page page)
        {
            pages.Add(page);
        }
    }
}