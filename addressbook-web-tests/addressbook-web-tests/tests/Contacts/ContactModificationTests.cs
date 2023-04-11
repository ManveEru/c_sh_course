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
            app.Contacts.Edit(contact, 2, table.Detail);            
        }

        [Test]
        public void ContactEditTest()
        {
            app.Contacts.Edit(contact, 2, table.Edit);
        }
    }
}
