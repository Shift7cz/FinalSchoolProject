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
        LoadFiles();
    }

    public void LoadFiles()
    {
        string line;
        
        StreamReader srBattery = new StreamReader("satBattery.txt");
        while ((line = srBattery.ReadLine()) != null)
        {
            List<string> p = Terminal.ParseCommand(line);
            SatBatteryList.Add(new SatBattery(p[0], p[1], char.Parse(p[2]), int.Parse(p[3]), int.Parse(p[4]), int.Parse(p[5]), int.Parse(p[6]),int.Parse(p[7]), int.Parse(p[8])));
        }
        srBattery.Close();
        
        StreamReader srFuelTank = new StreamReader("satFuelTank.txt");
        while ((line = srFuelTank.ReadLine()) != null)
        {
            List<string> p = Terminal.ParseCommand(line);
            SatFuelTankList.Add(new SatFuelTank(p[0], p[1], char.Parse(p[2]), int.Parse(p[3]), int.Parse(p[4]), int.Parse(p[5]), int.Parse(p[6])));
        }
        srBattery.Close();
        
        StreamReader srEngine = new StreamReader("satEngine.txt");
        while ((line = srEngine.ReadLine()) != null)
        {
            List<string> p = Terminal.ParseCommand(line);
            SatEngineList.Add(new SatEngine(p[0], p[1], char.Parse(p[2]), int.Parse(p[3]), int.Parse(p[4]), int.Parse(p[5]), p[6], int.Parse(p[7])));
        }
        srEngine.Close();
    }
}