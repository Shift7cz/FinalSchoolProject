namespace FinalProject2026;

/// <summary>
/// Manages points
/// </summary>
public static class PointsManager
{
    public static void AddPoints(int points)
    {
        int currentPoints = GetPoints();
        StreamWriter sw = new StreamWriter("points.txt");
        sw.WriteLine(currentPoints + points);
        sw.Close();
    }

    public static int GetPoints()
    {
        StreamReader sr = new StreamReader("points.txt");
        int value = int.Parse(sr.ReadLine() ?? "0");
        sr.Close();
        return value;
    }
    
    public static void ResetPoints()
    {
        StreamWriter sw = new StreamWriter("points.txt");
        sw.WriteLine("0");
        sw.Close();
    }
}