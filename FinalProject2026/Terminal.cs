using FinalProject2026.Sat;

namespace FinalProject2026;

/// <summary>
/// Terlinal calass handeling user inout and calling stuff
/// </summary>
public class Terminal
{
    /// <summary>
    /// List of commands
    /// </summary>
    public List<ICommandable> CommandList { get; set; }
   
    /// <summary>
    /// That think that terminal prints before the user writes
    /// </summary>
    public string TerminalString { get; set; }
    
    /// <summary>
    /// Reference to the world object
    /// </summary>
    public World? VirtualWorld { get; set; }
    
    /// <summary>
    /// The satellite object
    /// </summary>
    public Satellite? Satellite { get; set; }
    
    public Terminal(List<ICommandable> commands, string terminalString, World? virtualWorld = null, Satellite? satellite = null)
    {
        CommandList = commands;
        TerminalString = terminalString;
        VirtualWorld = virtualWorld;
        Satellite = satellite;
    }

    /// <summary>
    /// Splits a command into List by ' ' char
    /// </summary>
    /// <param name="input">The raw command string</param>
    /// <returns>The splited command List</returns>
    public static List<string> ParseCommand(string? input)
    {
        char devider = ' ';
        string[]? devided = input?.Split(devider);
        if (devided != null)
        {
            return devided.ToList();
        }
        else
        {
            return new List<string>();
        }
    }

    /// <summary>
    /// Handles user requests and calls commands in a loop
    /// </summary>
    public void Run()
    {
        Print.OutLn("Type \"help\" for help or \"help tutorial\" for tutorial. Use external README for list of commands. You can type now.");
        
        bool hasQuit = false;

        while (!hasQuit)
        {
            bool hasRan = false;
            
            Print.Out(TerminalString + " ");
            string? rawCommand = Print.ReadLn();
            
            Print.OutDebug(rawCommand);

            List<string> command = ParseCommand(rawCommand);

            for (int i = 0; i < CommandList.Count; i++)
            {
                if (command[0] == CommandList[i].Name)
                {
                    Print.OutLn(CommandList[i].Run(command));
                    hasRan = true;
                }
            }

            if (!hasRan)
            {
                if (command[0] == "quit" &&
                    !hasRan) // todo: make it actual object command that saves state and stuff
                {
                    hasQuit = true;
                }
                else
                {
                    if (command[0] != "")
                    {
                        Print.OutLn("Unknown command: " + command[0]);
                    }
                }
            }
        }
    }
}