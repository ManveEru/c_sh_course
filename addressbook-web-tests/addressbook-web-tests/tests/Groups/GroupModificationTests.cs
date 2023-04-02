using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupModificationTests :TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("modified");
            newData.Header = "newheader";
            newData.Footer = "newfooter";

            app.Groups.Edit(1, newData);
        }
    }
}
