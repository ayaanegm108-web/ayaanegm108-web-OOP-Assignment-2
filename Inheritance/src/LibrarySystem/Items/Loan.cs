using LibrarySystem.Items;
using LibrarySystem.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Loans
{
    internal class Loan
    {
        private static int _counter = 0;

        public string LoanId { get; }
        public DateTime BorrowDate { get; }
        public Member Borrower { get; }
        public LibraryItem Item { get; }
        public LoanStatus Status { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        internal Loan(Member borrower, LibraryItem item, DateTime borrowDate)
        {
            if (borrower == null) throw new ArgumentNullException(nameof(borrower));
            if (item == null) throw new ArgumentNullException(nameof(item));

            _counter++;
            LoanId = "L-" + _counter;
            Borrower = borrower;
            Item = item;
            BorrowDate = borrowDate;
            Status = LoanStatus.Borrowed;
        }

        public DateTime DueDate => BorrowDate.AddDays(Item.LoanPeriodDays);

        public decimal LateFee
        {
            get
            {
                if (Status != LoanStatus.Returned || ReturnDate == null)
                    return 0m;

                int daysLate = (ReturnDate.Value.Date - DueDate.Date).Days;
                if (daysLate <= 0)
                    return 0m;

                decimal gross = daysLate * Item.DailyLateFee;
                return gross * (1m - Borrower.DiscountPercent / 100m);
            }
        }

        internal void MarkReturned(DateTime returnDate)
        {
            if (Status != LoanStatus.Borrowed)
                throw new InvalidOperationException(
                    $"Loan {LoanId} cannot be returned because its status is {Status}.");
            if (returnDate < BorrowDate)
                throw new ArgumentException("Return date cannot be earlier than the borrow date.");

            Status = LoanStatus.Returned;
            ReturnDate = returnDate;
            Item.MarkAsReturned();
        }

        internal void MarkLost()
        {
            if (Status != LoanStatus.Borrowed)
                throw new InvalidOperationException(
                    $"Loan {LoanId} cannot be marked as lost because its status is {Status}.");

            Status = LoanStatus.Lost;
        }
    }
}

