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
            ContactData contact = new ContactData("Delete", "me");
            app.Contacts.Delete(contact);
        }

        [Test]
        public void ContactDeleteFromTable()
        {
            ContactData contact = new ContactData("Delete", "me");
            app.Contacts.DeleteFromTable(contact);
        }
    }
}