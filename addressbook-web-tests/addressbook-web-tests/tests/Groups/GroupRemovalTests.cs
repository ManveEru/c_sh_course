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
        public void GroupRemovalTest()
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
    }
}
