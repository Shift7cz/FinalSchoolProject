namespace FinalProject2026;

/// <summary>
/// Custom print rapper around Console
/// </summary>
public static class Print
{
    /// <summary>
    /// Enables debug messages
    /// </summary>
    public static bool Debug {get; set; }
    
    
    /// <summary>
    /// Stabdart print with no newline
    /// </summary>
    /// <param name="input">What it prints</param>
    public static void Out(string input)
    {
        Console.Write(input);
    }
    
    /// <summary>
    /// Standart print with no newline and ability to set foreground color
    /// </summary>
    /// <param name="input">What it prints</param>
    /// <param name="color">The color</param>
    public static void Out(string input, ConsoleColor color)
    {
        Console.ForegroundColor =  color;
        Console.Write(input);
        Console.ResetColor();
    }

    /// <summary>
    /// Standart print with newline
    /// </summary>
    /// <param name="input">What it prints</param>
    public static void OutLn(string input)
    {
        Console.WriteLine(input);
    }
    
    /// <summary>
    /// Standard print with newline and ability to set foreground color
    /// </summary>
    /// <param name="input">What it prints</param>
    /// <param name="color">The color</param>
    public static void OutLn(string input, ConsoleColor color)
    {
        Console.ForegroundColor =  color;
        Console.WriteLine(input);
        Console.ResetColor();
    }
    
    /// <summary>
    /// Standard print with newline and ability to set foreground and background color
    /// </summary>
    /// <param name="input">What it prints</param>
    /// <param name="foregroundColor">The foreground color</param>
    /// <param name="backgroundColor">The background color</param>
    public static void OutLn(string input, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
    {
        Console.ForegroundColor =  foregroundColor;
        Console.BackgroundColor =  backgroundColor;
        Console.WriteLine(input);
        Console.ResetColor();
    }

    /// <summary>
    /// Prints only when debug is enabled - used for debug messages
    /// </summary>
    /// <param name="input">What it prints</param>
    public static void OutDebug(string? input)
    {
        if (Debug)
        {
            OutLn("[[DEBUG]]: " + input, ConsoleColor.Red);
        }
    }

    /// <summary>
    /// Console.ReadLine() wrapper
    /// </summary>
    /// <returns>Returns te readline</returns>
    public static string? ReadLn()
    {
        return Console.ReadLine();
    }

    /// <summary>
    /// Console.ReadKey() wrapper
    /// </summary>
    /// <returns>returns the read ready</returns>
    public static ConsoleKey ReadKey()
    {
        return Console.ReadKey().Key;
    }

    /// <summary>
    /// Console.Clear() wrapper
    /// </summary>
    public static void Clear()
    {
        Console.Clear();
    }
}