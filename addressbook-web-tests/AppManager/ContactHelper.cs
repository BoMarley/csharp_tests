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
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            GoToAddNewContactForm();
            FillDataToFields(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Modify(ContactData contact)
        {
            manager.Navigator.GoBackToHomePage();
            EditContact();
            FillDataToFields(contact);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Delete()
        {
            EditContact();
            DeleteContact();
            return this;
        }

        public ContactHelper DeleteFromTable()
        {
            driver.FindElement(By.XPath("//html/body/div/div[4]/form[2]/table/tbody/tr[2]/td[1]/input")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
            return this;
        }

        public ContactHelper EditContact()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

         public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper FillDataToFields(ContactData contacts)
        {
            Type(By.Name("firstname"), contacts.Firstname);
            Type(By.Name("lastname"), contacts.Lastname);
            return this;
        }

        public ContactHelper GoToAddNewContactForm()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}
