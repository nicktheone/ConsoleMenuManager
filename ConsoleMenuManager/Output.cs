namespace ConsoleMenuManager;

public static class Output
{
    public static void WriteColor(string stringToWrite, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(stringToWrite);
        Console.ResetColor();
    }
}
