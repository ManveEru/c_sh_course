using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_white
{
    public class UserData : IComparable<UserData>, IEquatable<UserData>
    {
        public string FirstName { get; set; }

        public int CompareTo(UserData other)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }

        public bool Equals(UserData other)
        {
            return this.FirstName.Equals(other.FirstName);
        }

        public override string ToString()
        {
            return FirstName;
        }
    }
}
