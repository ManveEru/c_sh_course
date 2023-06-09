﻿using System;
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

        public ContactHelper Edit(ContactData contact, string id, int column)
        {
            ContactTableLayout tableLayout = new ContactTableLayout();
                        
            InitContactModification(id, column);
            if (column == tableLayout.Detail)
            {
                driver.FindElement(By.Name("modifiy")).Click();
            }
            FillContactForm(contact);
            SubmitContactModification();
            manager.Navigator.OpenHomePageByLink();
            return this;
        }

        public ContactHelper Remove(bool all, List<ContactData> contactsToRemove)
        {
            if (all)
            {
                SelectContact();
            }
            else
            {
                string[] index = new string[contactsToRemove.Count];
                for (int i = 0; i < contactsToRemove.Count; i++)
                {
                    index[i] = contactsToRemove[i].Id;
                }
                SelectContact(index);
            }
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(string id)
        {
            SelectContact(id);
            RemoveContact();
            manager.Navigator.GoToHomePage();
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

        public ContactHelper AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            return this;
        }

        public ContactHelper RemoveContactFromGroup(GroupData group, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupFilter(group);
            SelectContact(contact.Id);
            driver.FindElement(By.Name("remove")).Click();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        private void SelectGroupFilter(GroupData group)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(group.Name);
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
                AllEmail = cells[4].Text,
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
                WorkPhone = driver.FindElement(By.Name("work")).GetAttribute("value"),
                Email = driver.FindElement(By.Name("email")).GetAttribute("value"),
                Email2 = driver.FindElement(By.Name("email2")).GetAttribute("value"),
                Email3 = driver.FindElement(By.Name("email3")).GetAttribute("value")
            };
        }

        public string GetContactInformationFromDetail(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index + 2, 7);
            return driver.FindElement(By.Id("content")).Text;
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

        public ContactHelper SelectContact(string[] index)
        {
            foreach (string i in index)
            {
                driver.FindElement(By.Id(i)).Click();
            }
            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.Id(id)).Click();
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

        public ContactHelper InitContactModification(string id, int column)
        {
            ContactTableLayout tableLayout = new ContactTableLayout();

            if (column == tableLayout.Detail)
                driver.FindElement(By.XPath("//a[@href='view.php?id=" + id + "']")).Click();
            else
                driver.FindElement(By.XPath("//a[@href='edit.php?id=" + id + "']")).Click();
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
