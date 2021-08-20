using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactDeleteViaEditForm()
        {
            //prepare
            //to implement

            //action
            app.Contacts.Delete();
        }

        [Test]
        public void ContactDeleteFromTable()
        {
            //prepare
            //to implement

            //action
            app.Contacts.DeleteFromTable();
        }
    }
}