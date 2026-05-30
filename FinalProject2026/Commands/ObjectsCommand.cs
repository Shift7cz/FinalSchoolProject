namespace FinalProject2026.Commands;

/// <summary>
/// Lists all the objects in the current planetary system
/// </summary>
public class ObjectsCommand : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }

    public ObjectsCommand(Terminal term, string name)
    {
        Term = term;
        Name = name;
    }
    
    public string Run(List<string> input)
    {
        string returnValue = "Objects In This System:\n";
        returnValue += "Central Object -> " + Term.VirtualWorld?.CentralObject + "\n\n";

        if (Term.VirtualWorld != null)
        {
            for (int i = 0; i < Term.VirtualWorld.OrbitingObjects.Count; i++)
            {
                returnValue += "Orbiting Object -> " + Term.VirtualWorld.OrbitingObjects[i] + "\n";
            }
        }
        else
        {
            Print.OutDebug("Object Term.VirtualWorld is null");
        }

        return returnValue;
    }
}