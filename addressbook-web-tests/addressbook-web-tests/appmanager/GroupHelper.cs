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

        public GroupHelper Edit(int index, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            PrepareForSelectGroup();
            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(int[] index)
        {
            manager.Navigator.GoToGroupsPage();
            PrepareForSelectGroup();
            SelectGroup(index);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        private void PrepareForSelectGroup()
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                Create(new GroupData("Test"));
            }
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
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

        public GroupHelper SelectGroup(int[] index)
        {
            foreach (var i in index)
            {
                driver.FindElement(By.XPath("//div[@id='content']/form/span[" + i + "]/input")).Click();
            }
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
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
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
    }
}
