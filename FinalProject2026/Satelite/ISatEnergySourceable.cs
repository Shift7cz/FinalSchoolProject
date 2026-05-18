namespace FinalProject2026.Satelite;

public interface ISatEnergySourceable
{
    /// <summary>
    /// Output in watts
    /// </summary>
    public int Output{ get; set; }

    public void ReclaculateOutput(int hp);
}