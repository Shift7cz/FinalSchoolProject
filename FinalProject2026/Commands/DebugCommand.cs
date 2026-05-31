namespace FinalProject2026.Commands;

/// <summary>
/// Dev option toggle debug messages
/// </summary>
public class DebugCommand : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }

    public DebugCommand(Terminal terminal, string name)
    {
        Term = terminal;
        Name = name;
    }
    
    /// <summary>
    /// Sets debug to true/false; this is a dev option and doesn't impact gameplay
    /// </summary>
    /// <param name="input">The command list</param>
    /// <returns>String to print</returns>
    public string Run(List<string> input)
    {
        try
        {
            if (Menu.YNoption("This command is a dev option. Do you want to continue?", 'n'))
            {
                switch (input[1].ToLower())
                {
                    case "true":
                        Print.Debug = true;
                        return "Set Debug to true; Warning: This command is a dev option";
                    case "false":
                        Print.Debug = false;
                        return "Set Debug to false";
                    default:
                        return "Expected true/false; Warning: This command is a dev option";
                }

            }

            return "";
        }
        catch
        {
            return "User error";
        }
    }
}