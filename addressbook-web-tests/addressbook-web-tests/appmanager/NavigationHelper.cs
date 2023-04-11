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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper (ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        //Переход на главную страницу по ссылке после создания контакта
        public void OpenHomePageByLink()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        //Переход на главную страницу по ссылке в главном меню
        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook")
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
