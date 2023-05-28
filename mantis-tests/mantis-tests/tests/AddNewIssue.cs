using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTests : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Id = "11"
            };
            IssueData issueData = new IssueData()
            {
                Summary = "short desc",
                Description = "long desc",
                Category = "General"
            };
            app.API.CreateNewIssue(account, project, issueData);
        }
    }
}
