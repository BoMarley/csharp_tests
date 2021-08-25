using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemavalTests : AuthTestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
            //prepare
            GroupData group = new GroupData("delete me");
            group.Header = null;
            group.Footer = null;
            app.Groups.GroupCheck(group);
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            app.Groups.Remove(0, group);

            //validation
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
