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
    public class LoginHelper : HelperBase
    {
        private string baseURL;

        public LoginHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            driver.Url = baseURL + "/login_page.php";
            FillSimpleDialogue(By.Id("username"), account.Name, "Вход");
            FillSimpleDialogue(By.Id("password"), account.Password, "Вход");
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user-info"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && (GetLoggetUserName() == account.Name.ToLower());
        }

        public string GetLoggetUserName()
        {
            return driver.FindElement(By.CssSelector("span.user-info")).Text;
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("span.user-info")).Click();
                driver.FindElement(By.LinkText("Выход")).Click();
                driver.FindElement(By.LinkText("Зарегистрировать новую учётную запись"));
            }
        }
    }
}
