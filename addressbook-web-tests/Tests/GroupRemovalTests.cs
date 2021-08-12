using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemavalTests : TestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
            app.Grouops.Remove(1);
        }
    }
}
