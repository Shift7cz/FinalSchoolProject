namespace FinalProject2026.Commands;

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
            switch (input[1].ToLower())
            {
                case "bodies":
                    string returnValue = "Bodies In This System:\n";
                    returnValue += "Central Object -> " + Term.VirtualWorld.CentralObject + "\n\n";

                    for (int i = 0; i < Term.VirtualWorld.OrbitingObjects.Count; i++)
                    {
                        returnValue += "Orbiting Object -> " + Term.VirtualWorld.OrbitingObjects[i] + "\n";
                    }

                    return returnValue;
                default:
                    return "Unknown Command";
            }
        }
        catch (Exception e)
        {
            Print.OutLn("IMPLEMENT TS"); //todo: fix ts
            return e.Message;
        }
    }
}