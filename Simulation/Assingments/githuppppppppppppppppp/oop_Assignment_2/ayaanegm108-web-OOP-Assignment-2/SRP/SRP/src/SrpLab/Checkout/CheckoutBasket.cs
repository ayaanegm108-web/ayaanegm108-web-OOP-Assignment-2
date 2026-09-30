namespace SrpLab;

/// <summary>
/// Reason to change: what a customer can put in the cart (lines, coupon text, gift-wrap choice) changes.
/// It only holds cart state; it does no pricing.
/// </summary>
public sealed class CheckoutBasket
{
    private readonly List<BasketLine> _lines = new();

    public IReadOnlyList<BasketLine> Lines => _lines.AsReadOnly();
    public string? CouponText { get; private set; }
    public bool GiftWrapEnabled { get; private set; }

    public void AddLine(string sku, decimal price, int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        _lines.Add(new BasketLine(sku, price, qty));
    }

    public void ApplyCouponText(string? couponText) => CouponText = couponText;
    public void EnableGiftWrap() => GiftWrapEnabled = true;
}
