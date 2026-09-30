namespace SrpLab;

/// <summary>
/// Reason to change: the paging policy (when to fire CODE-YELLOW, how alerts are logged) changes.
/// </summary>
public sealed class PagerAlertLog
{
    private const int CodeYellowThreshold = 8;
    private readonly List<string> _alerts = new();

    public void RecordIfNeeded(int bed, int acuity, DateTime nowUtc)
    {
        if (acuity >= CodeYellowThreshold)
            _alerts.Add($"CODE-YELLOW bed={bed} at {nowUtc:HH:mm}");
    }

    /// <summary>Returns all alerts recorded so far and clears the log.</summary>
    public IReadOnlyList<string> Drain()
    {
        var copy = _alerts.ToList();
        _alerts.Clear();
        return copy;
    }
}
