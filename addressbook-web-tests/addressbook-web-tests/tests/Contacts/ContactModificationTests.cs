using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        private ContactData contact = new ContactData("New Name2");
        private ContactTableLayout table = new ContactTableLayout();

        public ContactModificationTests()
        {
            contact.LastName = null;
        }

        [Test]
        public void ContactModificationTest()
        {
            int index = 5;
            app.Contacts.PrepareContacts(index + 1);
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldContact = oldContacts[index];

            app.Contacts.Edit(contact, index, table.Detail);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[index].FirstName = contact.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData group in newContacts)
            {
                if (group.Id == oldContact.Id)
                {
                    Assert.AreEqual(group.FirstName, contact.FirstName);
                }
            }
        }

        [Test]
        public void ContactEditTest()
        {
            int index = 7;

            app.Contacts.PrepareContacts(index + 1);
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldContact = oldContacts[index];

            app.Contacts.Edit(contact, index, table.Edit);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[index].FirstName = contact.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData group in newContacts)
            {
                if (group.Id == oldContact.Id)
                {
                    Assert.AreEqual(group.FirstName, contact.FirstName);
                }
            }
        }
    }
}
