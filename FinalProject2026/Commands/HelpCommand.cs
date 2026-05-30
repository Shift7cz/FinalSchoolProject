namespace FinalProject2026.Commands;

/// <summary>
/// Command that provides helpfully information to user
/// </summary>
public class HelpCommand : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }

    public HelpCommand(Terminal term, string name)
    {
        Term = term;
        Name = name;
    }

    public string Run(List<string> input)
    {
        try
        {
            if (input.Count <= 1)
            {
                return LoadHelperFile("help.txt");
            }
            
            
            switch (input[1].ToLower())
            {
                case "time":
                    return LoadHelperFile("help-time.txt");
                case "sat":
                    return LoadHelperFile("help-sat.txt");
                case "scan":
                    return LoadHelperFile("help-scan.txt");
                case "faq":
                    return "TO BE IMPLEMENTED";
                case "tutorial":
                    return "TO BE IMPLEMENTED";
                default:
                    return "Unknown option";
            }
        }
        catch (Exception e)
        {
            Print.OutDebug(e.Message);
            Console.Write(e);
        }
        return "";
    }

    public string LoadHelperFile(string path)
    {
        StreamReader sr = new StreamReader(path);
        string text = "";
        string? line;
        while ((line = sr.ReadLine()) != null)
        {
            text += line + "\n";
                    
        }
        return text;
    }
}