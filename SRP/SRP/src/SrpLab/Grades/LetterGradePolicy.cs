namespace SrpLab;

/// <summary>
/// Reason to change: the faculty senate changes the letter-grade bands.
/// </summary>
public sealed class LetterGradePolicy
{
    public string Letter(decimal average)
    {
        if (average >= 90) return "A";
        if (average >= 80) return "B";
        if (average >= 70) return "C";
        if (average >= 60) return "D";
        return "F";
    }
}
