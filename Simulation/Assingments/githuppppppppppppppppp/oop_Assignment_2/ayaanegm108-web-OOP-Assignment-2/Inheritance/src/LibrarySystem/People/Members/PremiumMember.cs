using LibrarySystem.Items;
using LibrarySystem.Loans;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Members
{
    internal class PremiumMember:Member
    {
        private const int PointsPerReturn = 5;

        public PremiumMember(string personId, string fullName, string phone, decimal discountPercent)
            : base(personId, fullName, phone, 10, discountPercent)
        {
        }

        public int ReadingPoints
        {
            get
            {
                int points = 0;
                foreach (Loan loan in Loans)
                {
                    if (loan.Status == LoanStatus.Returned)
                        points += PointsPerReturn;
                }
                return points;
            }
        }
    }
}