using System;
using System.Collections.Generic;
using System.Text;

namespace src.SrpLab.Kitchen
{
    internal class TicketPrinter : KitchenTicketBasicData
    {
        public string Render(int orderNumber, IReadOnlyList<string> allergens, int etaMinutes)
        {
            // Hardware/formatting concerns — width, separators — change with printer vendor.
            var width = 32;
            var line = new string('=', width);
            var body = string.Join('\n',Items.Select(i => $"* {i.Name.ToUpperInvariant()} ({i.PrepMinutes}m)"));
            //var allergens = DetectAllergens();
            var allergyLine = allergens.Count == 0 ? "ALLERGENS: none" : "ALLERGENS: " + string.Join(",", allergens);
            return $"{line}\nORDER #{orderNumber}\nETA {etaMinutes} MIN\n{body}\n{allergyLine}\n{line}\n";
        }
    }
}
