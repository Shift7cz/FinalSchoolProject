using System.Windows.Input;

namespace FinalProject2026.Commands;

public class SateliteCommand : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }

    public SateliteCommand(Terminal term, string name)
    {
        Term = term;
        Name = name;
    }
    
    public string Run(List<string> input)
    {
        switch (input[1].ToLower())
        {
            case "new":
                if (Term.VirtualWorld.Sat != null)
                {
                    bool proceed = Term.YNoption("Are you sure you want to do this? you already have an existing satellite and by running this command it will be destroyed", 'n');
                    if (proceed) { break; }
                }
                Print.Out("Enter name of your staelite: ");
                string name = Print.ReadLn();
                
                
                
                Menu.SelectMultiple(new List<string> { "ahbehvesbvsjbevsbe", "epstein", "befhvfehvehvsvefsvfes" });
                break;
        }

        return "";
    }
}