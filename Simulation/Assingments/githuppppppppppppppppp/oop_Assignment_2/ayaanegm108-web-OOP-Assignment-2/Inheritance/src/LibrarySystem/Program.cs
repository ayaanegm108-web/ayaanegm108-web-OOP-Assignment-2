using LibrarySystem.Items;
using LibrarySystem.Loans;
using LibrarySystem.Members;
using LibrarySystem.People.Staff;

namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            

            StudentMember student = new StudentMember("S1", "Ali Hassan", "0100000001");
            PremiumMember premium = new PremiumMember("P1", "Sara Ahmed", "0100000002", 20m);

            Librarian librarian = new Librarian("E1", "Mona", "0111", new DateTime(2020, 1, 1), 5000m);
            Shelver shelver = new Shelver("E2", "Omar", "0122", new DateTime(2021, 3, 1), 4000m, "Fiction");
            HeadLibrarian head = new HeadLibrarian("E3", "Hoda", "0133", new DateTime(2015, 6, 1), 7000m);

            Book b1 = new Book("B1", "Clean Code", 1.00m);
            Book b2 = new Book("B2", "Refactoring", 1.00m);
            Book b3 = new Book("B3", "C# in Depth", 1.00m);
            Book b4 = new Book("B4", "Pro .NET", 1.00m);
            Dvd dvd = new Dvd("D1", "Inception", 1.00m);
            Magazine mag = new Magazine("M1", "Tech Monthly", 1.00m);

            DateTime today = new DateTime(2026, 9, 1);

            #region Withdrawn item
            Console.WriteLine("--- Borrow a withdrawn item ---");
            head.Withdraw(mag);
            try { premium.Borrow(mag, today); }
            catch (Exception ex) { Console.WriteLine("Rejected: " + ex.Message); }
            head.Restore(mag);
            #endregion


            #region Item already on loan
            Console.WriteLine("--- Borrow an item already on loan ---");
            Loan sLoan1 = student.Borrow(b1, today);
            try { premium.Borrow(b1, today); }
            catch (Exception ex) { Console.WriteLine("Rejected: " + ex.Message); }
            #endregion


            #region Student borrows a 4th item
            Console.WriteLine("--- Student borrows a 4th item ---");
            student.Borrow(b2, today);
            student.Borrow(b3, today);
            try { student.Borrow(b4, today); }
            catch (Exception ex) { Console.WriteLine("Rejected: " + ex.Message); }
            #endregion


            #region Polymorphic staff pay
            Console.WriteLine("--- Monthly pay ---");
            List<Staff> staff = new List<Staff> { librarian, head, shelver };
            foreach (Staff st in staff)
                Console.WriteLine($"{st.FullName} ({st.GetType().Name}): {st.MonthlyPay}");
            #endregion


            #region Polymorphic items
            Console.WriteLine("--- Items ---");
            List<LibraryItem> items = new List<LibraryItem> { b1, dvd, mag };
            foreach (LibraryItem it in items)
                Console.WriteLine($"{it.Title} ({it.GetType().Name}): period={it.LoanPeriodDays} days, daily late fee={it.DailyLateFee}");
            #endregion


            #region Premium returns a DVD 5 days late
            Console.WriteLine("--- Premium returns DVD 5 days late ---");
            Loan dvdLoan = premium.Borrow(dvd, today);
            DateTime returnDate = dvdLoan.DueDate.AddDays(5);
            librarian.ProcessReturn(dvdLoan, returnDate);
            Console.WriteLine($"Due date: {dvdLoan.DueDate:yyyy-MM-dd}");
            Console.WriteLine($"Returned: {returnDate:yyyy-MM-dd}");
            Console.WriteLine($"Late fee: {dvdLoan.LateFee}");
            Console.WriteLine($"Reading points: {premium.ReadingPoints}");
            #endregion


            #region Return twice
            Console.WriteLine("--- Return the same loan twice ---");
            try { librarian.ProcessReturn(dvdLoan, returnDate); }
            catch (Exception ex) { Console.WriteLine("Rejected: " + ex.Message); }
            #endregion


            #region Mark a returned loan as lost
            Console.WriteLine("--- Mark a returned loan as lost ---");
            librarian.ProcessReturn(sLoan1, today.AddDays(2));
            try 
            {
                librarian.MarkAsLost(sLoan1);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Rejected: " + ex.Message);
            }
            #endregion



        }
    }
}
//     :) 