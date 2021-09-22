using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation_Table_EditForm()
        {
            //prepare
            ContactData contact = new ContactData("NewName", "NewLastName");
            app.Contacts.ContactsCheck(contact);

            //actions
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //validation
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactInformation_DetailsMenu_EditForm()
        {
            //prepare
            ContactData contact = new ContactData("NewName", "NewLastName");
            app.Contacts.ContactsCheck(contact);

            //actions
            string fromDetailsMenu = app.Contacts.GetContactInformationFromDetailsMenu(0);
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);            

            //validation
            Assert.AreEqual(fromDetailsMenu, fromEditForm.AllContactData);
        }
    }
}
