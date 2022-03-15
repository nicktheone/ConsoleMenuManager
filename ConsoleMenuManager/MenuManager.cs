namespace ConsoleMenuManager
{
    public class MenuManager
    {
        private List<Page> pages;
        private Stack<Page> history;
        private Page CurrentPage
        {
            get { return history.Peek(); }
        }
        private Dictionary<string, object> cache = new();

        public MenuManager(string title)
        {
            Console.Title = title;
            pages = new List<Page>();
            history = new Stack<Page>();
        }

        public void AddPage(Page page)
        {
            Type type = page.GetType();
            if (pages.Any(x => x.GetType() == type))
            {
                throw new Exception($"Cannot add more than one instance of every Page: {type}");
            }
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

        public void SetCache(string key, object value)
        {
            cache.Add(key, value);
        }

        public T GetCache<T>(string key)
        {
            object output;

            if (cache.TryGetValue(key, out output!))
            {
                return (T)output;
            }

            throw new KeyNotFoundException(key);
        }
    }
}