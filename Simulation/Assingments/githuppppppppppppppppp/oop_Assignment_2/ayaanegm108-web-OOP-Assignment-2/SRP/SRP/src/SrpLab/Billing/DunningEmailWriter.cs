namespace SrpLab;

/// <summary>
/// Reason to change: collections or legal change the tone or text of the dunning email.
/// </summary>
public sealed class DunningEmailWriter
{
    public string Write(Subscription subscription, string customerName, DateOnly asOf,
        decimal amountDue, string invoiceNumber)
    {
        var severity = subscription.FailedPayments switch
        {
            <= 1 => "friendly reminder",
            2 => "second notice",
            _ => "final notice before suspension"
        };
        return $"Subject: {severity} {invoiceNumber}\nHi {customerName},\nBalance {amountDue:C} as of {asOf:o} ({subscription.FailedPayments} failures).\n";
    }
}
