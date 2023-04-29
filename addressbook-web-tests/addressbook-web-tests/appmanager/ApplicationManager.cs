using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver; //драйвер для работы с браузером
        protected string baseURL; //основная часть адреса сайта

        protected LoginHelper loginHelper; //реализует методы авторизации и выхода с сайта
        protected NavigationHelper navHelper; //реализует методы перехода по страницам сайта
        protected GroupHelper groupHelper; // реализует методы работы с группами
        protected ContactHelper contactHelper; // реализует методы работы с контактами
        //
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0.5);
            baseURL = "http://localhost";
            
            loginHelper = new LoginHelper(this, baseURL);
            navHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        ~ApplicationManager()
        {
           loginHelper.Logout();
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
         }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Auth.OpenLoginPage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver 
        {
            get
            {
                return driver;
            } 
        }
        
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navHelper;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

        
    }
}
