using FinalProject2026.Satelite;

namespace FinalProject2026;

/// <summary>
/// Handles time and timeskips
/// </summary>
public static class Warp
{
    /// <summary>
    /// Mission tim in days
    /// </summary>
    public static int MissionTime { get; set; }
    
    public static Satellite Sat { get; set; }

    /// <summary>
    /// Skips time, calculates degradation and movement, des loading screen
    /// </summary>
    /// <param name="ammount"></param>
    public static void SkipTime(int ammount)
    {
        string statusString = "Warp progress: [                    ]";
        int lastPercent = 0;
        
        for (int i = 0; i < ammount; i++)
        {
            for (int j = 0; j < Sat.SatBattery.Count; j++)
            {
                if (i % Sat.SatBattery[j].DegradeTime == 0)
                {
                    Sat.SatBattery[j].Hp -= 1;
                    Sat.SatBattery[j].RecalculateMaxChargeLevel();
                }
            }
            for (int j = 0; j < Sat.SolarSystem.OrbitingObjects.Count; j++)
            {
                Sat.SolarSystem.OrbitingObjects[j].AddOrbitalPos(Sat.SolarSystem.OrbitingObjects[j].AngularSpeed);
            }

            Sat.PosTracker.AddOrbitalPos(Sat.PosTracker.AngularSpeed);
            MissionTime++;
            
            int percentPassed = (int)((double)i/ammount * 100);
            
            if (percentPassed % 5 == 0)
            {
                statusString = "Warp progress: [";
                for (int j = 0; j < percentPassed / 5; j++)
                {
                    statusString += "#";
                }
                
                for (int j = 0; j < 20 - (percentPassed / 5); j++)
                {
                    statusString += " ";
                }

                statusString += "]";
            }
            
            if (lastPercent < percentPassed)
            {
                lastPercent = percentPassed;
                    
                Print.Clear();
                Print.OutLn(statusString + " " + percentPassed + "%");
            }
            
            Thread.Sleep(4); // adds small thread sleep if skip time skip is too little to make the user appreciate this stupid lading bar
        }
        Print.Clear();
    }
}