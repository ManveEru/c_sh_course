using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemove()
        {
            int index = 0;
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count == 1)
            {
                GroupData group = new GroupData() { Name = "ForDelete11" };
                app.Groups.Add(group);
                oldGroups.Insert(0, group);
            }

            app.Groups.Remove(index);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(index);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
