using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace src.SrpLab.CheckoutBasket
{
    internal class PaymentAuthorization:CheckoutBasketBasicData
    {
        public string AuthorizePaymentStub(decimal grandTotal, string cardLast4, int lineCount)
        {
            
            // Pretends to talk to a gateway — auth scheme changes independently of cart rules.
            var payload = $"{grandTotal:0.00}|{cardLast4}|{_lines.Count}";
            var hash = payload.GetHashCode();
            return $"AUTH-{Math.Abs(hash):X8}";
        }
    }
}
