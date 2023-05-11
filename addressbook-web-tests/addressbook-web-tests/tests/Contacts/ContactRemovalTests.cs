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
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactsRemovalTest()
        {
            int[] removeList = {0, 2, 5};
            app.Contacts.PrepareContacts(removeList.Max() + 1);
            List<ContactData> oldContacts = ContactData.GetAll();
            List<ContactData> contactsToRemove = new List<ContactData>();
            foreach (int i in removeList)
            {
                contactsToRemove.Add(oldContacts[i]);
            }

            app.Contacts.Remove(false, contactsToRemove);

            List<ContactData> newContacts = ContactData.GetAll();
            for (int i = removeList.Length - 1; i >= 0; i--)
            {
                oldContacts.RemoveAt(removeList[i]);
                
            }
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                foreach (ContactData removedContact in contactsToRemove)
                    Assert.AreNotEqual(contact.Id, removedContact.Id);
            }
        }

        [Test]
        public void ContactRemovalTest()
        {
            int contactIndex = 2;
            app.Contacts.PrepareContacts(contactIndex + 1);
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData contactToRemove = oldContacts[contactIndex];

            app.Contacts.Remove(contactToRemove.Id);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(contactIndex);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, contactToRemove.Id);
            }
        }
    }
}
