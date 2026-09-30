namespace SrpLab;

/// <summary>
/// Reason to change: the payment-gateway authorization scheme changes.
/// (Still a stub, as in the original; string.GetHashCode differs between runs.)
/// </summary>
public sealed class PaymentAuthorizer
{
    public string Authorize(decimal grandTotal, string cardLast4, int lineCount)
    {
        var payload = $"{grandTotal:0.00}|{cardLast4}|{lineCount}";
        var hash = payload.GetHashCode();
        return $"AUTH-{Math.Abs(hash):X8}";
    }
}
