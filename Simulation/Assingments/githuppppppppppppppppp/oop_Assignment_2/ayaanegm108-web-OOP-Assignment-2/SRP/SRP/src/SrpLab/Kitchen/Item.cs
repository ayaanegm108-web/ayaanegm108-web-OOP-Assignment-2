using System;
using System.Collections.Generic;
using System.Text;

namespace src.SrpLab.Kitchen
{
    public sealed record TicketItem(string Name, IReadOnlyList<string> Ingredients, int PrepMinutes);
    
}
