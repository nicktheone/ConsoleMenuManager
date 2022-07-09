namespace ConsoleMenuManager;

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

    public async Task NavigateToAsync<T>() where T : Page
    {
        Type pageType = typeof(T);

        history.Push(pages.Find(x => x.GetType() == pageType)!);

        Console.Clear();
        await CurrentPage.DisplayAsync();
    }

    public async Task NavigateHomeAsync()
    {
        while (history.Count > 1)
        {
            history.Pop();
        }

        Console.Clear();
        await CurrentPage.DisplayAsync();
    }

    public async Task NavigateBackAsync()
    {
        history.Pop();

        Console.Clear();
        await CurrentPage.DisplayAsync();
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