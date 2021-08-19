﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {

        [Test]
        public void ContactDeleteViaEditForm()
        {
            app.Contacts.Delete();
        }

        [Test]
        public void ContactDeleteFromTable()
        {
            app.Contacts.DeleteFromTable();
        }
    }
}