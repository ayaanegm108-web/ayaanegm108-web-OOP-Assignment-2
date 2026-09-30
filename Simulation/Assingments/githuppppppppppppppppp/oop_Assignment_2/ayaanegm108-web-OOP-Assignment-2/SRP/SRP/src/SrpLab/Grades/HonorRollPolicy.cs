namespace SrpLab;

/// <summary>
/// Reason to change: academic policy changes the honor-roll rule.
/// </summary>
public sealed class HonorRollPolicy
{
    public bool Qualifies(decimal average, string letter) =>
        average >= 85 && letter is "A" or "B";
}
