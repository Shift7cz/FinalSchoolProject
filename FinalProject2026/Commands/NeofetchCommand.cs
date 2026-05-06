namespace FinalProject2026.Commands;

public class NeofetchCommand : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }

    public NeofetchCommand(Terminal term, string name)
    {
        Term = term;
        Name = name;
    }
    
    public string Run(List<string> input)
    {
        return "";
    }
}