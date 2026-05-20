using FinalProject2026.Satelite;

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
    public World VirtualWorld { get; set; }
    
    /// <summary>
    /// The satellite object
    /// </summary>
    public Satellite Satellite { get; set; }
    
    public Terminal(List<ICommandable> commands, string terminalString)
    {
        CommandList = commands;
        TerminalString = terminalString;
    }

    /// <summary>
    /// Splits a command into List by ' ' char
    /// </summary>
    /// <param name="input">The raw command string</param>
    /// <returns>The splited command List</returns>
    public static List<string> ParseCommand(string input)
    {
        char devider = ' ';
        string[] devided = input.Split(devider);
        return devided.ToList();
    }

    /// <summary>
    /// Asks user if they want to proceed with y/n
    /// </summary>
    /// <param name="message">Custom message for the user</param>
    /// <param name="recomended">Which option is recommended. always enter lowercase, leve blanc for n recommendation</param>
    /// <returns>y = true; n = false; returns bool based on user response</returns>
    public bool YNoption(string message, char recomended)
    {
        switch (recomended)
        {
            case 'y':
                Print.Out(message + " [Y/n]: ");
                break;
            case 'n':
                Print.Out(message + " [y/N]: ");
                break;
            default:
                Print.Out(message + " [y/n]: ");
                break;
        }
        
        ConsoleKey k = Print.ReadKey();
        Print.OutLn("");

        switch (k)
        {
            case ConsoleKey.Y:
                return true;
            case ConsoleKey.N:
                return false;
            default:
                Print.OutLn("Excepted keys [y/n]");
                return false;
        }
    }

    /// <summary>
    /// Handles user requests and calls commands in a loop
    /// </summary>
    public void Run()
    {
        bool hasQuit = false;

        while (!hasQuit)
        {
            bool hasRan = false;
            
            Print.Out(TerminalString + " ");
            string rawCommand = Print.ReadLn();
            
            // command = command.ToLower()
            Print.OutDebug(rawCommand);
            
            List<string> command = ParseCommand(rawCommand);
            
            for (int i = 0; i < CommandList.Count; i++)
            {
                if (command[0] == CommandList[i].Name)
                {
                    //command.RemoveAt(0);
                    Print.OutLn(CommandList[i].Run(command));
                    hasRan = true;
                } 
            }

            if (!hasRan)
            {
                if (command[0] == "quit" && !hasRan) // todo: make it actual object command that saves state and stuff
                {
                    hasQuit = true;
                    hasRan = true;
                }
                else // TODO: That did u mean this but u cant write think like in linux terminal
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