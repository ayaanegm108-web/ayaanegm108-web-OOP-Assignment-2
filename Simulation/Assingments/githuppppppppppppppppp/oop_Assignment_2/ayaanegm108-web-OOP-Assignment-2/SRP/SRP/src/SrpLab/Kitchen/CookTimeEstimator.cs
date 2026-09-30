namespace SrpLab;

/// <summary>
/// Reason to change: the kitchen operations timing model (stations, allergy delay) changes.
/// </summary>
public sealed class CookTimeEstimator
{
    public int EstimateMinutes(KitchenTicket ticket, int openStations, bool hasAllergens)
    {
        if (openStations <= 0) openStations = 1;
        var sequential = ticket.Items.Sum(i => i.PrepMinutes);
        var parallel = (int)Math.Ceiling(sequential / (double)openStations);
        if (hasAllergens) parallel += 3; // allergy protocol delay
        var longest = ticket.Items.Count == 0 ? 0 : ticket.Items.Max(i => i.PrepMinutes);
        return Math.Max(parallel, longest);
    }
}
