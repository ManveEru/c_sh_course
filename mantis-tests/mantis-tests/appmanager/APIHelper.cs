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
        private Mantis.MantisConnectPortTypeClient client;
        public APIHelper(ApplicationManager manager) : base(manager) 
        {
            client = new Mantis.MantisConnectPortTypeClient();
        }

        public void CreateNewIssue(AccountData account, ProjectData projectData, IssueData issueData)
        {
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

        public void CreateProjects(AccountData account, List<ProjectData> addingProjects)
        {
            foreach (ProjectData item in addingProjects)
            {
                Mantis.ProjectData project = new Mantis.ProjectData
                {
                    name = item.Name, id = item.Id
                };
                client.mc_project_add(account.Name, account.Password, project);
            }
        }

        public List<ProjectData> GetProjectsList(AccountData account)
        {
            List<ProjectData> projectsList = new List<ProjectData>();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (Mantis.ProjectData project in projects)
            {
                projectsList.Add(new ProjectData()
                {
                    Name = project.name,
                    Id = project.id
                });
            }
            return projectsList;
        }
    }
}
