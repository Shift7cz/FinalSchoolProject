using System.Windows.Input;

namespace FinalProject2026.Commands;

public class WhoAmICommanad : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }

    public WhoAmICommanad(Terminal term, string name)
    {
        Term = term;
        Name = name;
    }
    
    public string Run(List<string> input)
    {
        return "NasaInternUser67";
    }
}