using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Members
{
    internal class StudentMember :Member
    {
        public StudentMember(string personId, string fullName, string phone)
       : base(personId, fullName, phone, 3, 0m)
        {
        }
    }
}
