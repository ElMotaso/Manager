namespace Manager.Scripts;

public class Run
{
    public double Distance { get; set; }
    public double Elevation { get; set; }
    private double _groundDifficulty { get; set; }
    public double DistanceDifficultyScore { get; set; }
    public double HillDifficultyScore { get; set; }
    
    public Run(double distance, double elevation, double groundDifficulty = 1)
    {
        this.Distance = distance;
        this.Elevation = elevation;
        this._groundDifficulty = groundDifficulty;
        this.DistanceDifficultyScore = CalculateDistanceDifficultyScore(distance, groundDifficulty);
        this.HillDifficultyScore = CalculateHillDifficultyScore(elevation, groundDifficulty);
    }

    private double CalculateDistanceDifficultyScore(double distance, double groundDifficulty)
    {
        return distance * groundDifficulty;
    }

    private double CalculateHillDifficultyScore(double elevation, double groundDifficulty)
    {
        return elevation * groundDifficulty;   
    }
}