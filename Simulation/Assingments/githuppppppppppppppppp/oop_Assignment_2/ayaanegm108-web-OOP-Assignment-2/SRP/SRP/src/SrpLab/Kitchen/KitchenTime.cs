using SrpLab;
using System;
using System.Collections.Generic;
using System.Text;

namespace src.SrpLab.Kitchen
{
    internal class KitchenTime:KitchenTicketBasicData
    {
        public int EstimatedReadyMinutes(KitchenTicket ticket, int openStations , bool hasAllergens)
        {
            // Kitchen ops model ≠ printing.
            if (openStations <= 0) openStations = 1;
            var sequential = Items.Sum(i => i.PrepMinutes);
            var parallel = (int)Math.Ceiling(sequential / (double)openStations);
            if (hasAllergens) parallel += 3; // allergy protocol delay mixed in
            var longest = Items.Count == 0 ? 0 : Items.Max(i => i.PrepMinutes);
            return Math.Max(parallel, longest);
        }
    }
}
