using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.GoToAddNewContactForm();
            app.Contacts.FillDataToFields(new ContactData("TestFirstName", "TestLastName"));
            app.Contacts.SubmitContactCreation();
            app.Navigator.GoBackToHomePage();
        }
    }
}
