using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL; //основная часть адреса сайта
        protected LoginHelper auth;
        protected NavigationHelper navigator;
        protected ProjectManagementHelper projectManager;

        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }
        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        //
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0.5);
            baseURL = "http://localhost";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            auth = new LoginHelper(this, baseURL);
            navigator = new NavigationHelper(this, baseURL);
            projectManager = new ProjectManagementHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
        }

        ~ApplicationManager()
        {
            auth.Logout();
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
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.7/login_page.php";
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
                return auth;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public ProjectManagementHelper PM
        {
            get
            {
                return projectManager;
            }
        }
    }
}
