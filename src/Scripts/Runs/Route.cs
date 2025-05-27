using System.Collections.Generic;

namespace Manager.Scripts.Runs;

public class Route(List<Segment> segments) : IRun
{
    private List<Segment> Segments { get; set; } = segments;

    public double CalculateDifficultyScore()
    {
        double difficultyScore = 0;
        foreach (Segment segment in Segments)
        {
            difficultyScore += segment.CalculateDifficultyScore();
        }
        return difficultyScore;
    }
    
    public double GetDistance()
    {
        double distance = 0;
        foreach (Segment segment in Segments)
        {
            distance += segment.GetDistance();
        }
        return distance;
    }
}