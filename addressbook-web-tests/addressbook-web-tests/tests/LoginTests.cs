using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            AccountData account = new AccountData("admin", "secret");

            System.Threading.Thread.Sleep(1000);
            app.Auth.Logout();
            System.Threading.Thread.Sleep(1000);
            app.Auth.Login(account);
            System.Threading.Thread.Sleep(1000);
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            AccountData account = new AccountData("admin", "notsecret");

            System.Threading.Thread.Sleep(1000);
            app.Auth.Logout();
            System.Threading.Thread.Sleep(1000);
            app.Auth.Login(account);
            System.Threading.Thread.Sleep(1000);
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
