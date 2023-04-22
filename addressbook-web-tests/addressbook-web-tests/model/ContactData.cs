using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allData;

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

        public string AllData 
        {
            get 
            {
                return (FirstName 
                        + (string.IsNullOrEmpty(LastName) ? "" :" " + LastName) 
                        + "\r\n"
                        + (string.IsNullOrEmpty(Address) ? "" : Address + "\r\n")
                        + "\r\n"
                        + (string.IsNullOrEmpty(HomePhone) ? "" : "H: " + HomePhone + "\r\n")
                        + (string.IsNullOrEmpty(MobilePhone) ? "" : "M: " + MobilePhone + "\r\n")
                        + (string.IsNullOrEmpty(WorkPhone) ? "" : "W: " + WorkPhone + "\r\n")).Trim();
            }
            set 
            {
                allData = value;
            } 
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
        
        public string HomePhone { get; set; }
        
        public string MobilePhone { get; set; }
        
        public string WorkPhone { get; set; }

        public string AllPhones 
        { 
            get 
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set 
            {
                allPhones = value;
            } 
        }

        public string Fax { get; set; }
        
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
        
        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
    }
}
