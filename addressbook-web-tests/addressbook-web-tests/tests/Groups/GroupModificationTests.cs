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
    class GroupModificationTests :AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("new1");
            newData.Header = null;
            newData.Footer = null;
            int index = 7;
            
            app.Groups.PrepareGroups(index + 1);
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Edit(index, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[index].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
