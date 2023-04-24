using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(4);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(4);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
        }

        [Test]
        public void TestDetailContactInformation()
        {
            string fromDetail = app.Contacts.GetContactInformationFromDetail(4);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(4);

            Assert.AreEqual(fromDetail, fromForm.AllData);
        }
    }
}
