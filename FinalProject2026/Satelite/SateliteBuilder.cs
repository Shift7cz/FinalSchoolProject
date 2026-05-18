namespace FinalProject2026.Satelite;

public class SateliteBuilder
{
    public List<SatBattery> SatBatteryList { get; set; }
    public List<SatFuelTank> SatFuelTankList { get; set; }

    public SateliteBuilder()
    {
        SatBatteryList = new List<SatBattery>();
        SatFuelTankList = new List<SatFuelTank>();
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
    }
}