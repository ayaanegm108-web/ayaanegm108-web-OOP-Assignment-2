using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace src.SrpLab.CheckoutBasket
{
    internal class CalculateTotal :CheckoutBasketBasicData
    {
        protected bool _giftWrap;
        protected string? _couponRaw;
        public decimal SubTotal() => _lines.Sum(l => l.Price * l.Qty);
        public decimal DiscountAmount()
        {
            // Parsing marketing strings is a different reason to change than pricing math.
            if (string.IsNullOrWhiteSpace(_couponRaw)) return 0m;
            var t = _couponRaw.Trim().ToUpperInvariant();
            if (t.StartsWith("SAVE") && int.TryParse(t[4..], out var pct) && pct is > 0 and <= 50)
                return Math.Round(SubTotal() * pct / 100m, 2);
            if (t.Contains("FREESHIP")) return 0m; // ship is elsewhere — still parsed here
            if (t == "WELCOME10") return Math.Min(10m, SubTotal());
            return 0m;
        }
        public decimal GrandTotal()
        {
            var total = SubTotal() - DiscountAmount();
            if (_giftWrap) total += 4.99m; // packaging fee policy ≠ cart math
            return Math.Max(0m, total);
           
        }
        public void pay()
        {

        }
    }
}
