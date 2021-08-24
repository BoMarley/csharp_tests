using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.GroupNotExists())
            {
                app.Groups.Create(group);
            }

            //action
            app.Groups.Modify(1, group);
        }
    }
}
