namespace SrpLab;

/// <summary>
/// Reason to change: the customer-facing gift message text changes.
/// </summary>
public sealed class GiftMessageWriter
{
    public string Write(CheckoutBasket basket, string fromName, decimal grandTotal)
    {
        var items = string.Join(", ", basket.Lines.Select(l => l.Sku));
        return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {grandTotal:C}\n";
    }
}
