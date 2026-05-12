namespace FinalProject2026.Satelite;

public interface ISateliteFunctionable
{
    public string Name { get; set; }
    public string Run(string input);
}