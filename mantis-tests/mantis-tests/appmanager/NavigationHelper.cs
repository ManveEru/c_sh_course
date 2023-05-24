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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        private string appVersionURL = "/mantisbt-2.25.7";

        public NavigationHelper (ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToManageOverviewPage()
        {
            if (driver.Url == baseURL + appVersionURL + "/manage_overview_page.php")
            {
                return;
            }
            driver.FindElement(By.CssSelector("i.fa-gears")).Click();
        }

        public void GoToManageTab(string tab)
        {
            GoToManageOverviewPage();
            if (driver.Url == baseURL + appVersionURL + "/" + tab)
            {
                return;
            }
            driver.FindElement(By.CssSelector("a[href='" + appVersionURL + "/" + tab + "']")).Click();
        }
    }
}
