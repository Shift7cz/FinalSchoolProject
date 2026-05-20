namespace FinalProject2026.Satelite;

public interface ISatEnergySourceable // todo: make oit be same as SatBattery or SatEngine philosophy and implement
{
    /// <summary>
    /// Output in watts
    /// </summary>
    public int Output{ get; set; }

    public void ReclaculateOutput(int hp);
}