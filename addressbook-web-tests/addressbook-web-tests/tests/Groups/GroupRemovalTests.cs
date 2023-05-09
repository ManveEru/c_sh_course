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
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupsRemovalTest()
        {
            int[] removeList = {0};

            app.Groups.PrepareGroups(1);
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldGroup = oldGroups[0];

            app.Groups.Remove(removeList);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, oldGroup.Id);
            }
        }

        [Test]
        public void GroupRemovalTest()
        {
            int groupIndex = 1;
            
            app.Groups.PrepareGroups(groupIndex + 1);
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldGroup = oldGroups[groupIndex];

            app.Groups.Remove(oldGroup.Id);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(groupIndex);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, oldGroup.Id);
            }
        }
    }
}
