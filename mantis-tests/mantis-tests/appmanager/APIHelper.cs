using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData projectData, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData
            {
                summary = issueData.Summary,
                description = issueData.Description,
                category = issueData.Category,
            };
            issue.project = new Mantis.ObjectRef
            {
                id = projectData.Id
            };
            client.mc_issue_add(account.Name, account.Password, issue);
        }
    }
}
