using System.Windows.Input;

namespace FinalProject2026.Commands;

public class TimeCommand : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }

    public TimeCommand(Terminal term, string name)
    {
        Term = term;
        Name = name;
    }
    
    public string Run(List<string> input)
    {
        Warp.SkipTime(int.Parse(input[1]));
        Print.Out(Warp.MissionTime + "");
        return "";
    }
}