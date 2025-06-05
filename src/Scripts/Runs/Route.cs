using System.Collections.Generic;

namespace Manager.Scripts.Runs;

public class Route() : IRun
{
    private List<Segment> Segments { get; set; }

    public Route(List<Segment> segments) : this()
    {
        Segments = segments;
    }
    
    public Route(double distance, double elevation, double groundDifficulty = 1) : this()
    {
        Segment segment = new Segment(distance, elevation, groundDifficulty);
        Segments.Add(segment);
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
    
    public double Distance()
    {
        double distance = 0;
        foreach (Segment segment in Segments)
        {
            distance += segment.Distance;
        }
        return distance;
    }
}