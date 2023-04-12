using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int[] removeList = {1, 3, 7};
            int maxIndex = 7;
            int difference = app.Groups.DifferenceGroups(maxIndex);


            if (difference < 0)
                for (; difference < 0; difference++)
                    app.Groups.Create(new GroupData("Test"));
            app.Groups.Remove(removeList);
        }
    }
}
