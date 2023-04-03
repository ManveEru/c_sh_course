﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Name");
            contact.LastName = "Surname";

            app.Contacts.Create(contact);
            app.Navigator.OpenHomePage();
        }
    }
}