using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
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
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //actions
            app.Contacts.Delete(contact);

            //validation
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactDeleteFromTable()
        {
            //prepare
            ContactData contact = new ContactData("Delete", "me");
            app.Contacts.ContactsCheck(contact);
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //actions
            app.Contacts.DeleteFromTable(contact);

            //validation
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}