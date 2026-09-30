namespace SrpLab;

/// <summary>
/// Reason to change: finance changes the proration rules for part-period charges.
/// </summary>
public sealed class ProrationCalculator
{
    public decimal Prorate(Subscription subscription, DateOnly activeFrom)
    {
        if (activeFrom <= subscription.PeriodStart) return subscription.MonthlyPrice;
        if (activeFrom >= subscription.PeriodEnd) return 0m;
        var totalDays = subscription.PeriodEnd.DayNumber - subscription.PeriodStart.DayNumber;
        if (totalDays <= 0) return subscription.MonthlyPrice;
        var used = subscription.PeriodEnd.DayNumber - activeFrom.DayNumber;
        return Math.Round(subscription.MonthlyPrice * used / totalDays, 2);
    }
}
