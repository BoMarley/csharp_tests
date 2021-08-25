using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    class GroupModifyTests : AuthTestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            //prepare
            GroupData group = new GroupData("modified group name");
            group.Header = null;
            group.Footer = null;
            app.Groups.GroupCheck(group);
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            app.Groups.Modify(0, group);

            //validation
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
