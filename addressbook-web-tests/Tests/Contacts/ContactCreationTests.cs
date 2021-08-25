using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            //action
            ContactData contact = new ContactData("TestFirstName", "TestLastName");
            app.Contacts.Create(contact);
        }
    }
}
