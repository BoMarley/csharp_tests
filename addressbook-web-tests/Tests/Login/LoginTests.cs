using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //prepare
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            //prepare
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "wrongpass");
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
