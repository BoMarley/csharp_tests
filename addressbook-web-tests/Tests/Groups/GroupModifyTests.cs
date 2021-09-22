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
            GroupData modifyMe = new GroupData("modified group name");
            app.Groups.GroupCheck(modifyMe);
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            //action
            app.Groups.Modify(0, modifyMe);

            //validation
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = modifyMe.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(modifyMe.Name, group.Name);
                }
            }
        }
    }
}
