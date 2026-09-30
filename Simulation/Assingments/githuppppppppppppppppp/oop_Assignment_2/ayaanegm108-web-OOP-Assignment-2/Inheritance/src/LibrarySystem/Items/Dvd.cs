using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Items
{
    internal class Dvd : LibraryItem
    {
        public Dvd(string catalogNumber, string title, decimal baseLateFee)
            : base(catalogNumber, title, baseLateFee, 7, 2m) { }
    }
}
