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
            GroupData toBeRemoved = new GroupData("delete me");
            app.Groups.GroupCheck(toBeRemoved);
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            app.Groups.Remove(0);

            //validation
            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData saveToBeRemovedfForValidation = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, saveToBeRemovedfForValidation.Id);
            }
        }
    }
}
