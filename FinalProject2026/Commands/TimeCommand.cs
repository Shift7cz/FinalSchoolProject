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
        try
        {
            Warp.SkipTime(int.Parse(input[1]));
            return "Mission time: " + Warp.MissionTime + " days";
        }
        catch(Exception e)
        {
            Print.OutLn(e.Message + " Please enter a whole number.");
            return "";
        }
    }
}