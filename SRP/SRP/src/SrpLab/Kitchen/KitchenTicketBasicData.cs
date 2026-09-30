using System;
using System.Collections.Generic;
using System.Text;

namespace src.SrpLab.Kitchen
{
    internal class KitchenTicketBasicData
    {
        private readonly List<TicketItem> _items = new();

        public IReadOnlyList<TicketItem> Items => _items.AsReadOnly();
        public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
        {
            _items.Add(new TicketItem(item, ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList(), prepMinutes));
        }
    }
}
