namespace SrpLab;

/// <summary>
/// Reason to change: the way the cart total is assembled (subtotal, discount, fees) changes.
/// </summary>
public sealed class BasketPricing
{
    private readonly CouponDiscountRules _coupons;
    private readonly GiftWrapPolicy _giftWrap;

    public BasketPricing(CouponDiscountRules coupons, GiftWrapPolicy giftWrap)
    {
        _coupons = coupons;
        _giftWrap = giftWrap;
    }

    public decimal SubTotal(CheckoutBasket basket) => basket.Lines.Sum(l => l.Price * l.Qty);

    public decimal DiscountAmount(CheckoutBasket basket) =>
        _coupons.Discount(basket.CouponText, SubTotal(basket));

    public decimal GrandTotal(CheckoutBasket basket)
    {
        var total = SubTotal(basket) - DiscountAmount(basket);
        if (basket.GiftWrapEnabled) total += _giftWrap.Fee;
        return Math.Max(0m, total);
    }
}
