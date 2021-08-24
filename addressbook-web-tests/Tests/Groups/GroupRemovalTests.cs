using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.GroupNotExists())
            {
                app.Groups.Create(group);
            }

            //action
            app.Groups.Remove(1, group);
        }
    }
}
