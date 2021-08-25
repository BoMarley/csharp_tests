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
            ContactData contact = new ContactData("Delete", "me");
            app.Contacts.ContactsCheck(contact);

            //actions
            app.Contacts.Delete(contact);
        }

        [Test]
        public void ContactDeleteFromTable()
        {
            //prepare
            ContactData contact = new ContactData("Delete", "me");
            app.Contacts.ContactsCheck(contact);

            //actions
            app.Contacts.DeleteFromTable(contact);
        }
    }
}