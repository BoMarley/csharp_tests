using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }
        
        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            else
            {
                driver.Navigate().GoToUrl(baseURL);
            }
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            else
            {
                driver.FindElement(By.LinkText("groups")).Click();
            }
        }
    }
}
