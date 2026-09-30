using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.People.Staff
{
    internal class Staff : Person
    {
        private readonly decimal _allowance;

        public DateTime HireDate { get; }
        public decimal MonthlySalary { get; private set; }

        public Staff(string personId, string fullName, string phone,
                        DateTime hireDate, decimal monthlySalary, decimal allowance)
            : base(personId, fullName, phone)
        {
            if (monthlySalary <= 0)
                throw new ArgumentException("Salary must be positive.");
            if (allowance < 0)
                throw new ArgumentException("Allowance cannot be negative.");

            HireDate = hireDate;
            MonthlySalary = monthlySalary;
            _allowance = allowance;
        }

        public decimal MonthlyPay => MonthlySalary + _allowance;

        public void GiveRaise(decimal percent)
        {
            if (percent <= 0)
                throw new ArgumentException("Raise percentage must be greater than zero.");

            MonthlySalary += MonthlySalary * percent / 100m;
        }
    }
}
