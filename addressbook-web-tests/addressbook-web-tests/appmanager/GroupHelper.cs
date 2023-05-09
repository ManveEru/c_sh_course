using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        private List<GroupData> groupCache = null;
        
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreate();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Edit(string id, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Edit(int index, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index + 1);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(int[] index)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(string id)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(id);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    
                    groupCache.Add(new GroupData(element.Text));
                    groupCache.Last().Id = element.FindElement(By.TagName("input")).GetAttribute("value");
                }
            }
            return new List<GroupData>(groupCache);
        }

        public GroupHelper PrepareGroups(int index)
        {
            int difference = DifferenceGroups(index);


            for (; difference < 0; difference++)
                Create(new GroupData("Test"));
            return this;
        }

        public int DifferenceGroups(int count)
        {
            manager.Navigator.GoToGroupsPage();
            return driver.FindElements(By.Name("selected[]")).Count - count;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }

        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("//input[@type='checkbox' and @value='" + id + "']")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int[] index)
        {
            foreach (var i in index)
            {
                driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (i + 1) + "]/input")).Click();
            }
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            FillInput(By.Name("group_name"), group.Name);
            FillInput(By.Name("group_header"), group.Header);
            FillInput(By.Name("group_footer"), group.Footer);
            return this;
        }

       public GroupHelper SubmitGroupCreate()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
    }
}
