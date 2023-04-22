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
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(3);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(3);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestDetailContactInformation()
        {
            string fromDetail = app.Contacts.GetContactInformationFromDetail(3);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(3);

            Assert.AreEqual(fromDetail, fromForm.AllData);
        }
    }
}
