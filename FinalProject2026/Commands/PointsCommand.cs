namespace FinalProject2026.Commands;

/// <summary>
/// Allows player to display his points.
/// </summary>
public class PointsCommand : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }

    public PointsCommand(Terminal term, string name)
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
                return "You have " + PointsManager.GetPoints() + " points!";
            }

            switch (input[1].ToLower())
            {
                case "reset":
                    if (Menu.YNoption("Are you sure you want ot reset your points", 'n'))
                    {
                        PointsManager.ResetPoints();
                        return "Points have been reset";
                    }
                    break;
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
}