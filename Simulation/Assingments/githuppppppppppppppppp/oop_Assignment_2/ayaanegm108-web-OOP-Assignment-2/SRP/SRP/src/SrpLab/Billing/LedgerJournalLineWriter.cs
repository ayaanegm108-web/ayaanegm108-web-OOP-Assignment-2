namespace SrpLab;

/// <summary>
/// Reason to change: accounting changes the format of the ledger export line.
/// </summary>
public sealed class LedgerJournalLineWriter
{
    public string Write(Subscription subscription, string invoiceNumber, decimal amount) =>
        $"{subscription.CustomerId},{invoiceNumber},{amount:0.00},AR-SUB";
}
