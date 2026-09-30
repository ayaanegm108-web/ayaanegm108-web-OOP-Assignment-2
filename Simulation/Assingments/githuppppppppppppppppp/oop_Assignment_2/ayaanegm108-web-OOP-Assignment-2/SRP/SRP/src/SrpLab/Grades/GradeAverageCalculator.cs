namespace SrpLab;

/// <summary>
/// Reason to change: the way a student's average is calculated (rounding, weighting) changes.
/// </summary>
public sealed class GradeAverageCalculator
{
    public decimal Average(IReadOnlyList<decimal> scores) =>
        scores.Count == 0 ? 0m : Math.Round(scores.Average(), 2);
}
