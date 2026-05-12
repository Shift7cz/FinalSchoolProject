namespace FinalProject2026;

using System;
using System.Threading.Tasks;

public class Time
{
    /// <summary>
    /// If pulse is active
    /// </summary>
    private bool _active;
    
    /// <summary>
    /// Tracks gametime in minutes
    /// </summary>
    public int GameTime { get; set; }

    public Time()
    {
        _active = true;
    }
    
    /// <summary>
    /// What runs every pulse
    /// </summary>
    public void PulseTasks()
    {
        GameTime += 1;
    }

    /// <summary>
    /// Runs every x seconds. Doesn't take full thread and frees it when idle unlike new thread and while true thread sleep
    /// </summary>
    /// <param name="intervalSeconds">How often does it run</param>
    public async Task StartPulse(int intervalSeconds)
    {
        Print.OutDebug("Starting pulse");

        while (_active)
        {
            PulseTasks();
            await Task.Delay(intervalSeconds * 1000);
        }
        Print.OutDebug("Pulse ended");
    }
}