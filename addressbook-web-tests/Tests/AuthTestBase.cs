using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class AuthTestBase : TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupLogin()
        {
            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
