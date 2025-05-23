namespace Manager.Scripts;

public partial class Runner
{
    
    //private double _fatigueResistance;
    //private double _hillSkill;
    //private double _injuryProbability;
    //private double _fatigueInterest = 1.05;
    
    
    /*
     private double GetDistancePenaltyFactor(Run run)
    {
        return Math.Pow(1.1 - _fatigueResistance / 10, run.DistanceDifficultyScore);
    }
    */

    /*
     private double GetElevationPenaltyFactor(Run run)
    {
        return Math.Pow(1.1 - _hillSkill / 10, run.HillDifficultyScore / 100);
    }
    */

    /*
    private double GetRoutePenaltyFactor(Run run)
    {
        return GetDistancePenaltyFactor(run) * GetElevationPenaltyFactor(run);
    }
    */

    /*
    private double GetRunnerReadienessFactor()
    {
        return 1 / _fatigue;
    }
    */
    
    /*
    private double GetFinishTime(Segment segment)
    {
        return segment.Distance *
               GetAveragePace(); // * GetRoutePenaltyFactor(run) * GetRunnerReadienessFactor();
    }

    private double CalculateFatigue(Segment segment)
    {
        double addedFatigue = segment.CalculateDifficultyScore();
         + _fatigue * _fatigueInterest
          + run.DistanceDifficultyScore
          + run.HillDifficultyScore / 10 / _hillSkill; 
        return _fatigue + addedFatigue * _fatigueResistance;
    }
    */
}