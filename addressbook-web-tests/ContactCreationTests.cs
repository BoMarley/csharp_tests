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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddNewContactForm();
            FillDataToFields(new ContactData("TestFirstName", "TestLastName"));
            SubmitContactCreation();
            GoBackToHomePage();
        }
    }
}