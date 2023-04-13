using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        private ContactData contact = new ContactData("New Name");
        private ContactTableLayout table = new ContactTableLayout();

        public ContactModificationTests()
        {
            contact.LastName = null;
        }

        [Test]
        public void ContactModificationTest()
        {
            int index = 5;
            app.Contacts.PrepareContacts(index);
            app.Contacts.Edit(contact, index, table.Detail);
        }

        [Test]
        public void ContactEditTest()
        {
            int index = 7;

            app.Contacts.PrepareContacts(index);
            app.Contacts.Edit(contact, index, table.Edit);
        }
    }
}
