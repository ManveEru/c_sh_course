using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        private List<ProjectData> projectCache = null;
        
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Create(List<ProjectData> projects)
        {
            foreach (ProjectData project in projects)
            {
                manager.Navigator.GoToManageTab("manage_proj_page.php");
                //System.Console.Out.WriteLine(project.Name);
                InitCreation();
                FillCreationForm(project);
                SubmitForm();
                ReturnToProjectTable();
            }
            projectCache = null;
        }

        public void Remove(int index)
        {
            manager.Navigator.GoToManageTab("manage_proj_page.php");
            SelectProject(index);
            InitRemoval();
            SubmitRemoval();
            projectCache = null;
        }

        private void SelectProject(int index)
        {
            driver.FindElements(By.CssSelector("div.table-responsive"))[0]
                                                .FindElement(By.TagName("tbody"))
                                                .FindElements(By.TagName("tr"))[index]
                                                .FindElement(By.TagName("a")).Click();
        }

        private void InitCreation()
        {
            driver.FindElement(By.CssSelector("input[name=manage_proj_create_page_token] + *")).Click();
        }

        private void InitRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void FillCreationForm(ProjectData project)
        {
            FillInput(By.Id("project-name"), project.Name);
        }

        private void SubmitForm()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }
        private void SubmitRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void ReturnToProjectTable()
        {
            driver.FindElement(By.LinkText("Продолжить")).Click();
        }

        public List<ProjectData> GetProjecttList()
        {
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();
                manager.Navigator.GoToManageTab("manage_proj_page.php");
                IList<IWebElement> rows = driver.FindElements(By.CssSelector("div.table-responsive"))[0]
                                                .FindElement(By.TagName("tbody"))
                                                .FindElements(By.TagName("tr"));

                foreach (IWebElement row in rows)
                {
                    IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                    projectCache.Add(new ProjectData(cells[0].Text)
                    {
                        State = cells[1].Text,
                        Scope = cells[3].Text,
                        Definition = cells[4].Text
                    });
                }
            }
            return new List<ProjectData>(projectCache);
        }

        public void TestLocator()
        {
            manager.Navigator.GoToManageTab("manage_proj_page.php");
            System.Console.Out.Write(driver.FindElement(By.CssSelector("input[name=manage_proj_create_page_token] + *")).Text);
        }
    }
}
