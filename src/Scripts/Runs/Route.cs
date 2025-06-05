using System.Collections.Generic;

namespace Manager.Scripts.Runs;

public partial class Route : Godot.GodotObject, IRun
{
    protected List<Segment> Segments { get; set; }

    protected Route(List<Segment> segments) : this()
    {
        Segments = segments;
    }
    
    public Route(double distance, double elevation, double groundDifficulty = 1) : this()
    {
        Segment segment = new Segment(distance, elevation, groundDifficulty);
        Segments = new List<Segment>();
        Segments.Add(segment);
    }

    public Route()
    {
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

    public double Elevation()
    {
        double elevation = 0;
        foreach (Segment segment in Segments)
        {
            elevation += segment.Elevation;
        }
        return elevation;
    }
    
    public double GroundDifficulty()
    {
        double groundDifficulty = 0;
        foreach (Segment segment in Segments)
        {
            groundDifficulty += segment.GroundDifficulty;
        }
        return groundDifficulty / Segments.Count;
    }
}