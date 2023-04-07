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

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int[] index)
        {
            foreach (var i in index)
            {
                driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (i + 1) + "]/td[1]/input")).Click();
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
            FillInput(By.Name("firstname"), contact.FirstName);
            FillInput(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactHelper SubmitContactCreate()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
    }
}
