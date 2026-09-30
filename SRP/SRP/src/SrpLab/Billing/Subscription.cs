namespace SrpLab;

/// <summary>
/// Reason to change: what a subscription stores (customer, price, period, failed payments) changes.
/// </summary>
public sealed class Subscription
{
    public string CustomerId { get; }
    public decimal MonthlyPrice { get; }
    public DateOnly PeriodStart { get; }
    public DateOnly PeriodEnd { get; }
    public int FailedPayments { get; private set; }

    public Subscription(string customerId, decimal monthlyPrice, DateOnly periodStart, DateOnly periodEnd)
    {
        CustomerId = customerId;
        MonthlyPrice = monthlyPrice;
        PeriodStart = periodStart;
        PeriodEnd = periodEnd;
    }

    public void RegisterFailedPayment() => FailedPayments++;
}
