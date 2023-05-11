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
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupsRemovalTest()
        {
            int[] removeList = {0, 4, 5};

            app.Groups.PrepareGroups(removeList.Max() + 1);
            List<GroupData> oldGroups = GroupData.GetAll();
            List<GroupData> groupsToRemove = new List<GroupData>();
            foreach(int i in removeList)
            {
                groupsToRemove.Add(oldGroups[i]);
            }

            app.Groups.Remove(groupsToRemove);

            List<GroupData> newGroups = GroupData.GetAll();
            for (int i = removeList.Length - 1; i >= 0; i--)
            {
                oldGroups.RemoveAt(removeList[i]);
            }

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                foreach (GroupData removedGroup in groupsToRemove)
                    Assert.AreNotEqual(group.Id, removedGroup.Id);
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

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, oldGroup.Id);
            }
        }
    }
}
