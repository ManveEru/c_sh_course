using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupModificationTests :AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("new");
            newData.Header = null;
            newData.Footer = null;
            int index = 5;
            
            app.Groups.PrepareGroups(index);
            app.Groups.Edit(index, newData);
        }
    }
}
