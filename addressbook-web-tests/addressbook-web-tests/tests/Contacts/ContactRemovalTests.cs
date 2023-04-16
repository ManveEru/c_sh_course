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
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.PrepareContacts(1);
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldContact = oldContacts[0];

            app.Contacts.Remove(false, new int[] {0});

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData group in newContacts)
            {
                Assert.AreNotEqual(group.Id, oldContact.Id);
            }
        }
    }
}
