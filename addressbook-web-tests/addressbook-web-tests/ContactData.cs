using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstName;
        private string middleName = "";
        private string lastName = "";
        private string nickName = "";
        private string photo = "";
        private bool delete = false;
        private string company = "";
        private string title = "";
        private string address = "";
        private int homePhone;
        private int mobilePhone;
        private int workPhone;
        private int fax;
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string birthday = "";
        private string anniversary = "";
        private string addressSecondary = "";
        private string homeSecondary = "";
        private string notesSecondary = "";

        public ContactData (string firstName)
        {
            this.firstName = firstName;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string NickName
        {
            get
            {
                return nickName;
            }
            set
            {
                nickName = value;
            }
        }
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }
        public bool Delete
        {
            get
            {
                return delete;
            }
            set
            {
                delete = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public int HomePhone
        {
            get
            {
                return homePhone;
            }
            set
            {
                homePhone = value;
            }
        }
        public int MobilePhone
        {
            get
            {
                return mobilePhone;
            }
            set
            {
                mobilePhone = value;
            }
        }
        public int WorkPhone
        {
            get
            {
                return workPhone;
            }
            set
            {
                workPhone = value;
            }
        }
        public int Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
        public string Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }
        public string Anniversary
        {
            get
            {
                return anniversary;
            }
            set
            {
                anniversary = value;
            }
        }
        public string AddressSecondary
        {
            get
            {
                return addressSecondary;
            }
            set
            {
                addressSecondary = value;
            }
        }
        public string HomeSecondary
        {
            get
            {
                return homeSecondary;
            }
            set
            {
                homeSecondary = value;
            }
        }
        public string NotesSecondary
        {
            get
            {
                return notesSecondary;
            }
            set
            {
                notesSecondary = value;
            }
        }
    }
}
