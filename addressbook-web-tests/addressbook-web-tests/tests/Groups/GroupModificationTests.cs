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
            int difference = app.Groups.DifferenceGroups(index);


            if (difference < 0)
                for (; difference < 0; difference++)
                    app.Groups.Create(new GroupData("Test"));
            app.Groups.Edit(index, newData);
        }
    }
}
