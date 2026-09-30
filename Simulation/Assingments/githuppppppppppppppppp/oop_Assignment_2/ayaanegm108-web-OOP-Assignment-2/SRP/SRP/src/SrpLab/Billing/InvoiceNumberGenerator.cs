namespace SrpLab;

/// <summary>
/// Reason to change: the invoice numbering scheme (prefix, padding, sequence) changes.
/// Numbers are only consumed when a caller calls <see cref="Next"/> explicitly.
/// </summary>
public sealed class InvoiceNumberGenerator
{
    private int _sequence = 1000;

    public string Next(DateOnly periodStart)
    {
        var n = ++_sequence;
        return $"INV-{periodStart:yyyyMM}-{n:D5}";
    }
}
