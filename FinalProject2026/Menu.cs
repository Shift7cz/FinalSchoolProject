using FinalProject2026.Commands;

namespace FinalProject2026;

public static class Menu
{
    /// <summary>
    /// Makes a select multiple options menu in the console
    /// </summary>
    /// <param name="options"></param>
    /// <param name="Options">List of options for the menu</param>
    /// <returns>List of ints that weare selected</returns>
    public static List<int> SelectMultiple(List<string> options)
    {
        Print.Clear();
        Print.OutDebug("Menu Selectmultiple");
        
        int current = 0;
        List<int> selected = new List<int>();

        while (true)
        {
            Print.OutLn("Use up ↑↓ keys to move, space to select and enter to confirm and exit.");

            for (int i = 0; i < options.Count; i++)
            {
                if (i == current)
                {
                    if (selected.Contains(i))
                    {
                        Print.OutLn("■ " + options[i], ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        Print.OutLn("□ " + options[i], ConsoleColor.Black, ConsoleColor.White);
                    }
                }
                else
                {
                    if (selected.Contains(i))
                    {
                        Print.OutLn("■ " + options[i]);
                    }
                    else
                    {
                        Print.OutLn("□ " + options[i]);
                    }
                }
            }
            
            var k = Print.ReadKey();
            switch (k)
            {
                case ConsoleKey.UpArrow:
                    if (current == 0)
                    {
                        current = options.Count -1;
                        break;
                    }
                    
                    current -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    if (current == options.Count -1)
                    {
                        current = 0;
                        break;
                    }
                    current += 1;
                    break;
                case  ConsoleKey.Spacebar:
                    if (selected.Contains(current))
                    {
                        selected.Remove(current);
                        break;
                    }
                    selected.Add(current);
                    break;
                case ConsoleKey.Enter:
                    selected.Sort();
                    Print.Clear();
                    return selected;
            }
            
            Print.Clear();
        }
    }
}