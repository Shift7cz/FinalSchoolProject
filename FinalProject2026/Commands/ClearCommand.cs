namespace FinalProject2026.Commands;

/// <summary>
/// Clears the terminal (same as in bash)
/// </summary>
public class ClearCommand : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }

    public ClearCommand(Terminal term, string name)
    {
        Term = term;
        Name = name;

    }
    
    public string Run(List<string> input)
    {
        Print.Clear();
        return "";
    }
}