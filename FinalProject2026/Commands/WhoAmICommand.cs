namespace FinalProject2026.Commands;

/// <summary>
/// Esteregg command
/// </summary>
public class WhoAmICommand : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }

    public WhoAmICommand(Terminal term, string name)
    {
        Term = term;
        Name = name;
    }
    
    public string Run(List<string> input)
    {
        return "NasaInternUser67";
    }
}