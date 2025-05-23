namespace Manager.Scripts.Runs;

public class Segment : IRun
{
    public double Distance { get; set; }
    public double Elevation { get; set; }
    private double GroundDifficulty { get; set; }
    
    public Segment(double distance, double elevation, double groundDifficulty = 1)
    {
        this.Distance = distance;
        this.Elevation = elevation;
        this.GroundDifficulty = groundDifficulty;
    }

    public double CalculateDifficultyScore()
    {
        double G = Elevation / Distance;
        double factor = 0;
        if (G > 0)
        {
            factor = 7;
        }
        else
        {
            factor = -4;
        }
        return Distance * (1 + double.Max(G * factor, -0.3)) * GroundDifficulty;
    }
    
    public double getDistance()
    {
        return Distance;
    }
}