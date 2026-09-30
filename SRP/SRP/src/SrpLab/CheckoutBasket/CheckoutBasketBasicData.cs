using System;
using System.Collections.Generic;
using System.Text;

namespace src.SrpLab.CheckoutBasket
{
    internal class CheckoutBasketBasicData
    {
        protected readonly List<(string Sku, decimal Price, int Qty)> _lines = new();
        
        
        public void AddLine(string sku, decimal price, int qty)
        {
            if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
            _lines.Add((sku, price, qty));
        }
    }
}
