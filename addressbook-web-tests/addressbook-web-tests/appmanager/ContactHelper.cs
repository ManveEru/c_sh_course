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
        

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreate();
            return this;
        }

        public ContactHelper Edit(ContactData contact, int row, int column)
        {
            InitContactModification(row, column);
            FillContactForm(contact);
            SubmitContactModification();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper InitContactModification(int row, int column)
        {
            ContactTableLayout table = new ContactTableLayout();
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + row + "]/td[" + column + "]/a/img")).Click();
            if (column == table.Detail)
            {
                driver.FindElement(By.Name("modifiy")).Click();
            }
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }

        public ContactHelper SubmitContactCreate()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
    }
}
