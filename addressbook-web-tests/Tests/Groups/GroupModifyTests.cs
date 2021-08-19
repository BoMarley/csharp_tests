﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    class GroupModifyTests : TestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            GroupData group = new GroupData("modified group name");
            group.Header = null;
            group.Footer = null;
            app.Groups.Modify(1, group);
        }
    }
}