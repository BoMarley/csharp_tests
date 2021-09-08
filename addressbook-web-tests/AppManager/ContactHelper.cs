using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            EditContact();
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string allEmails = driver.FindElement(By.Name("email")).GetAttribute("value")
                                + "\r\n" + driver.FindElement(By.Name("email2")).GetAttribute("value")
                                + "\r\n" + driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                AllEmails = allEmails
                
            };    
        }

        internal ContactData GetContactInformationFromDetailsMenu(int v)
        {
            manager.Navigator.OpenHomePage();
            ContactDetails();
            string allContactData = driver.FindElement(By.CssSelector("#content")).Text;

            return new ContactData(allContactData)
            { 
                AllContactData = allContactData.Replace("\r\nH: ", "").Replace("M: ", "").Replace("W: ", "").Replace("\r\n\r\n", "")
            };
        }

        public ContactHelper ContactDetails()
        {
            driver.FindElement(By.XPath("//img[@alt='Details']")).Click();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            GoToAddNewContactForm();
            FillDataToFields(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(ContactData contact)
        {
            EditContact();
            FillDataToFields(contact);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper ContactsCheck(ContactData contact)
        {
            GoToHomePage();
            if (!ContactNotExist(contact))
            {
                Create(contact);
            }
            return this;
        }

        public ContactHelper Delete(ContactData contact)
        {
            EditContact();
            DeleteContact(contact);
            return this;
        }

        public ContactHelper DeleteFromTable(ContactData contact)
        {
            driver.FindElement(By.XPath("//html/body/div/div[4]/form[2]/table/tbody/tr[2]/td[1]/input")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper DeleteContact(ContactData contact)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
            contactCache = null;
            return this;
        }

        public bool ContactNotExist(ContactData contact)
        {
            return IsElementPresent(By.XPath("//html/body/div/div[4]/form[2]/table/tbody/tr[2]/td[1]/input"));
        }

        public ContactHelper EditContact()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

         public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
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

        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                GoToHomePage();
                IList<IWebElement> lines = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in lines)
                {
                    IWebElement cellSurename = element.FindElement(By.CssSelector("td:nth-of-type(2)"));
                    IWebElement cellName = element.FindElement(By.CssSelector("td:nth-of-type(3)"));
                    contactCache.Add(new ContactData(cellName.Text, cellSurename.Text));
                }
            }

            return new List<ContactData>(contactCache);
        }

        public int GetNumberOfSearchResults()
        {
            GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
