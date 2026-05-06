using FinalProject2026.Commands;

namespace FinalProject2026;

public class Run
{
    /// <summary>
    /// Enables debug messages
    /// </summary>
    public bool Debug { get; set; }
    
    public Run(bool doDebug)
    {
        Debug = doDebug;
        Print.Debug = true;
    }
    
    /// <summary>
    /// The start method - strats everything needed for running
    /// </summary>
    public void Start()
    {
        Terminal t = new Terminal(new List<ICommandable>(), ">");


        List<ICommandable> cmndList = new List<ICommandable>()
        {
            new DebugCommand(t, "debug"),
            new WhoAmICommanad(t, "whoami")
        };
            
        t.CommandList = cmndList;
        t.Run();
    }
}