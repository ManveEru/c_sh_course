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
    public class ContactHelper : HelperBase
    {
        private List<ContactData> contactCache = null;
        private string table = "//table[@id='maintable']/tbody";

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreate();
            manager.Navigator.OpenHomePageByLink();
            return this;
        }

        public ContactHelper Edit(ContactData contact, int row, int column)
        {
            InitContactModification(row + 2, column);
            FillContactForm(contact);
            SubmitContactModification();
            manager.Navigator.OpenHomePageByLink();
            return this;
        }

        public ContactHelper Remove(bool all, int[] index)
        {
            if (all)
            {
                SelectContact();
            }
            else
            {
                SelectContact(index);
            }
            RemoveContact();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                int rowCount = driver.FindElements(By.XPath(table + "/tr")).Count - 1;

                for (int i = 2; i < (rowCount + 2); i++)
                {
                    contactCache.Add(new ContactData(driver.FindElement(By.XPath(GetCellLink(i, 3))).Text));
                    contactCache.Last().LastName = driver.FindElement(By.XPath(GetCellLink(i, 2))).Text;
                    contactCache.Last().Id = driver.FindElement(By.XPath(GetCellLink(i, 1) + "/input")).GetAttribute("value");
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactHelper PrepareContacts(int index)
        {
            int difference = DifferenceContacts(index);

            for (; difference < 0; difference++)
                Create(new ContactData("Default"));
            return this;
        }

        public int DifferenceContacts(int count)
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElement(By.XPath(table)).FindElements(By.Name("selected[]")).Count - count;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int[] index)
        {
            foreach (var i in index)
            {
                driver.FindElement(By.XPath(GetCellLink(i + 2, 1) + "/input")).Click();
            }
            return this;
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.Id("MassCB")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int row, int column)
        {
            ContactTableLayout tableLayout = new ContactTableLayout();
            driver.FindElement(By.XPath(GetCellLink(row, column) + "/a/img")).Click();
            if (column == tableLayout.Detail)
            {
                driver.FindElement(By.Name("modifiy")).Click();
            }
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            FillInput(By.Name("firstname"), contact.FirstName);
            FillInput(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactHelper SubmitContactCreate()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public string GetCellLink(int row, int column)
        {
            return System.String.Format("{0}/tr[{1}]/td[{2}]", table, row, column);
        }
    }
}
