using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData (string firstName)
        {
            FirstName = firstName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.FirstName) && (LastName == other.LastName);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (FirstName.CompareTo(other.FirstName) == 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            return FirstName.CompareTo(other.FirstName);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "First name = " + FirstName + ", last name = " + LastName;
        }

        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        
        public string NickName { get; set; }
        
        public string Photo { get; set; }
        
        public bool Delete { get; set; }
        
        public string Company { get; set; }
        
        public string Title { get; set; }
        
        public string Address { get; set; }
        
        public int HomePhone { get; set; }
        
        public int MobilePhone { get; set; }
        
        public int WorkPhone { get; set; }
        
        public int Fax { get; set; }
        
        public string Email { get; set; }
        
        public string Email2 { get; set; }
        
        public string Email3 { get; set; }
        
        public string Homepage { get; set; }
        
        public string Birthday { get; set; }
        
        public string Anniversary { get; set; }
        
        public string AddressSecondary { get; set; }
        
        public string HomeSecondary { get; set; }
        
        public string NotesSecondary { get; set; }

        public string Id { get; set; }
    }
}
