using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void TestContactRemove()
        {
            int index = 0;
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            if (oldContacts.Count == 0)
            {
                ContactData contact = new ContactData() { FirstName = "ForDelete11" };
                app.Contacts.Add(contact);
                oldContacts.Insert(0, contact);
            }

            app.Contacts.Remove(index);

            List<ContactData> newGroups = app.Contacts.GetContactList();
            oldContacts.RemoveAt(index);
            oldContacts.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldContacts, newGroups);
        }
    }
}
