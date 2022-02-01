namespace ConsoleMenuManager
{
    public class MenuManager
    {
        private List<Page> pages;
        private Stack<Page> history;

        public Page CurrentPage
        {
            get { return history.Peek(); }
        }


        public MenuManager(string title)
        {
            Console.Title = title;
            pages = new List<Page>();
            history = new Stack<Page>();
        }

        public void AddPage(Page page)
        {
            pages.Add(page);
        }

        public void NavigateTo<T>() where T : Page
        {
            Type pageType = typeof(T);

            history.Push(pages.Find(x => x.GetType() == pageType)!);

            Console.Clear();
            CurrentPage.Display();
        }

        public void NavigateHome()
        {
            while (history.Count > 1)
            {
                history.Pop();
            }

            Console.Clear();
            CurrentPage.Display();
        }

        public void NavigateBack()
        {
            history.Pop();

            Console.Clear();
            CurrentPage.Display();
        }
    }
}