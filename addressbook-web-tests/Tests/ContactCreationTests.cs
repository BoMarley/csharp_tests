﻿using System;
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
            ContactData contact = new ContactData("TestFirstName", "TestLastName");
            app.Contacts.Create(contact);
        }
    }
}
