namespace Manager.Scripts.Runs;

public class Segment : IRun
{
    private readonly double _distance;
    private readonly double _elevation;
    private readonly double _groundDifficulty;
    public double Distance => _distance;

    public double Elevation => _elevation;

    public double GroundDifficulty => _groundDifficulty;
    
    public Segment(double distance, double elevation, double groundDifficulty = 1)
    {
        _distance = distance;
        _elevation = elevation;
        _groundDifficulty = groundDifficulty;
    }

    public double CalculateDifficultyScore()
    {
        if (_distance == 0)
        {
            return 0;
        }
        double G = _elevation / _distance;
        double factor = 0;
        if (G > 0)
        {
            factor = 7;
        }
        else
        {
            factor = -4;
        }
        return _distance * (1 + double.Max(G * factor, -0.3)) * _groundDifficulty;
    }
}