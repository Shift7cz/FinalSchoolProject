namespace FinalProject2026;

public interface ICommandable
{
    /// <summary>
    /// Points to the terminal the command belongs to, for special features
    /// </summary>
    public Terminal Term { get; set; }
    
    /// <summary>
    /// Used to call the command by terminal
    /// </summary>
    public string Name{get;set;}
    
    /// <summary>
    /// What does the terminal call - beginning of the command code
    /// </summary>
    /// <param name="input">List of the parsed command without the first word of the command itself</param>
    /// <returns>Potential return for printable functions</returns>
    public string Run(List<string> input);
}