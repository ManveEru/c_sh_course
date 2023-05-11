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
    class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("new1")
            {
                Header = null,
                Footer = null
            };
            int index = 7;
            
            app.Groups.PrepareGroups(index + 1);
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData modifiedGroup = oldGroups[index];

            app.Groups.Edit(modifiedGroup.Id, newData);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[index].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == modifiedGroup.Id)
                    Assert.AreEqual(newData.Name, group.Name);
            }
        }
    }
}
