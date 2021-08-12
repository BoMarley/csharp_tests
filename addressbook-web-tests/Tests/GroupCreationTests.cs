using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Grouops.InitGroupCreation();
            GroupData group = new GroupData("test group name");
            group.Header = "test group header";
            group.Footer = "test group footer";
            app.Grouops.FillGroupForm(group);
            app.Grouops.SubmitGroupCreation();
            app.Grouops.ReturnToGroupsPage();
        }
    }
}
