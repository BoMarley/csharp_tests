using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModifyTests : AuthTestBase
    {

        [Test]
        public void ContactModifyTest()
        {
            //prepare
            ContactData contact = new ContactData("NewName", "NewLastName");
            app.Contacts.ContactsCheck(contact);
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //action
            app.Contacts.Modify(contact);

            //validation
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = contact.Firstname;
            oldContacts[0].Lastname = contact.Lastname;
            
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}