using LibrarySystem.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.People.Staff
{
    internal class HeadLibrarian : Staff
    {
        public HeadLibrarian(string personId, string fullName, string phone,
                             DateTime hireDate, decimal monthlySalary)
            : base(personId, fullName, phone, hireDate, monthlySalary, 400m)
        {
        }

        public void ChangeLateFee(LibraryItem item, decimal newBaseFee)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            item.SetBaseLateFee(newBaseFee);
        }

        public void Withdraw(LibraryItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            item.Withdraw();
        }

        public void Restore(LibraryItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            item.Restore();
        }
    }
}
