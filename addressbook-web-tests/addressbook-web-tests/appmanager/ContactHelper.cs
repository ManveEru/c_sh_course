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
            ContactTableLayout tableLayout = new ContactTableLayout();

            InitContactModification(row + 2, column);
            if (column == tableLayout.Detail)
            {
                driver.FindElement(By.Name("modifiy")).Click();
            }
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
                IList<IWebElement> rows = driver.FindElements(By.Name("entry"));

                foreach (IWebElement row in rows)
                {
                    IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[2].Text)
                    {
                        LastName = cells[1].Text,
                        Id = cells[0].FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            return new ContactData(cells[2].Text)
            {
                LastName = cells[1].Text,
                Address = cells[3].Text,
                AllPhones = cells[5].Text
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index + 2, 8);
            return new ContactData(driver.FindElement(By.Name("firstname")).GetAttribute("value"))
            {
                LastName = driver.FindElement(By.Name("lastname")).GetAttribute("value"),
                Address = driver.FindElement(By.Name("address")).GetAttribute("value"),
                HomePhone = driver.FindElement(By.Name("home")).GetAttribute("value"),
                MobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value"),
                WorkPhone = driver.FindElement(By.Name("work")).GetAttribute("value")
            };
        }

        public ContactHelper PrepareContacts(int index)
        {
            manager.Navigator.GoToHomePage();
            int difference = driver.FindElements(By.Name("entry")).Count - index;

            for (; difference < 0; difference++)
                Create(new ContactData("Default"));
            return this;
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
            foreach (int i in index)
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
            driver.FindElement(By.XPath(GetCellLink(row, column) + "/a")).Click();
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
            return System.String.Format("//table[@id='maintable']/tbody/tr[{0}]/td[{1}]", row, column);
        }
    }
}
