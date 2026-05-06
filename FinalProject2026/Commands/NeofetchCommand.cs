namespace FinalProject2026.Commands;

public class NeofetchCommand : ICommandable
{
    public Terminal Term { get; set; }
    public string Name { get; set; }

    public NeofetchCommand(Terminal term, string name)
    {
        Term = term;
        Name = name;
    }

    public string Run(List<string> input)
    {
        Print.Out("NasaInternUser67", ConsoleColor.Blue); Print.Out("@"); Print.OutLn("CommandPc27", ConsoleColor.Blue);
        Print.OutLn("----------------------------");
        Print.Out("OS", ConsoleColor.Blue); Print.OutLn(": Arch Linux x86_64");
        Print.Out("Kernel", ConsoleColor.Blue); Print.OutLn(": Linux 2.6.7-nasa1-2");
        Print.Out("Shel", ConsoleColor.Blue); Print.OutLn(": SatCon-Bash");
        Print.Out("Cpu", ConsoleColor.Blue); Print.OutLn(": Intel I8 6767");
        Print.Out("Memory", ConsoleColor.Blue); Print.OutLn(": 6.70 GiB / 19.35 GiB (35%)");
        Print.Out("Disk (/)", ConsoleColor.Blue); Print.OutLn(": 156.42 GiB / 237.47 GiB (66%) - ext4");
        return "";
    }
}