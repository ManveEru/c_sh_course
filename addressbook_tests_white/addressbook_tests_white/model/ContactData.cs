using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_white
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public string FirstName { get; set; }

        public int CompareTo(ContactData other)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }

        public bool Equals(ContactData other)
        {
            return this.FirstName.Equals(other.FirstName);
        }

        public override string ToString()
        {
            return FirstName;
        }
    }
}
