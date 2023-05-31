using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void TestContactCreation()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData newContact = new ContactData() { FirstName = "Test2" };

            app.Contacts.Add(newContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
