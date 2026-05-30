namespace FinalProject2026.Satelite;

/// <summary>
/// Builds the satellite
/// </summary>
public class SateliteBuilder
{
    /// <summary>
    /// Partlist
    /// </summary>
    public List<SatBattery> SatBatteryList { get; set; }
    
    /// <summary>
    /// Partlist
    /// </summary>
    public List<SatFuelTank> SatFuelTankList { get; set; }
    
    /// <summary>
    /// Partlist
    /// </summary>
    public List<SatEngine> SatEngineList { get; set; }
    
    
    public SateliteBuilder()
    {
        SatBatteryList = new List<SatBattery>();
        SatFuelTankList = new List<SatFuelTank>();
        SatEngineList = new List<SatEngine>();
        LoadFilesSafe();
    }

    public void LoadFilesSafe()
    {
        try
        {
            LoadFiles();
        }
        catch (Exception e)
        {
            Print.OutLn(e.Message + " Regenerating files.");
            FileRegenrator.RegenerateFiles();
            LoadFiles();
        }
    }

    private void LoadFiles()
    {
        StreamReader sr;
        string? line;

        sr = new StreamReader("sat-battery.txt");
        while ((line = sr.ReadLine()) != null)
        {
            List<string> p = Terminal.ParseCommand(line);
            SatBatteryList.Add(new SatBattery(p[0], p[1], char.Parse(p[2]), int.Parse(p[3]), int.Parse(p[4]),
                int.Parse(p[5]), int.Parse(p[6]), int.Parse(p[7]), int.Parse(p[8])));
        }
        sr.Close();

        sr = new StreamReader("sat-fuel-tank.txt");
        while ((line = sr.ReadLine()) != null)
        {
            List<string> p = Terminal.ParseCommand(line);
            SatFuelTankList.Add(new SatFuelTank(p[0], p[1], char.Parse(p[2]), int.Parse(p[3]), int.Parse(p[4]),
                int.Parse(p[5]), int.Parse(p[6])));
        }
        sr.Close();

        sr = new StreamReader("sat-engine.txt");
        while ((line = sr.ReadLine()) != null)
        {
            List<string> p = Terminal.ParseCommand(line);
            SatEngineList.Add(new SatEngine(p[0], p[1], char.Parse(p[2]), int.Parse(p[3]), int.Parse(p[4]),
                int.Parse(p[5]), p[6], int.Parse(p[7])));
        }
        sr.Close();
    }
}