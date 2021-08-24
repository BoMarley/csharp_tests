using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModifyTests : AuthTestBase
    {

        [Test]
        public void ContactModifyTest()
        {
            //prepare
            ContactData contact = new ContactData("ModifiedFirstName", "ModifiedLastName");
            app.Contacts.GoToHomePage();
            if (!app.Contacts.ContactNotExist(contact))
            {
                app.Contacts.Create(contact);
            }

            //action
            app.Contacts.Modify(contact);
        }
    }
}