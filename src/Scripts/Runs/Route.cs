using System.Collections.Generic;

namespace Manager.Scripts.Runs;

public class Route : IRun
{
    public List<Segment> Segments { get; set; } = new List<Segment>();

    public Route(List<Segment> segments)
    {
        this.Segments = segments;
    }
    
    public double CalculateDifficultyScore()
    {
        double difficultyScore = 0;
        foreach (Segment segment in Segments)
        {
            difficultyScore += segment.CalculateDifficultyScore();
        }
        return difficultyScore;
    }
    
    public double getDistance()
    {
        double distance = 0;
        foreach (Segment segment in Segments)
        {
            distance += segment.getDistance();
        }
        return distance;
    }
}