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
        public void TestContactInformation_Edit_Menu()
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

        }

        [Test]
        public void TestContactInformation_Details_Form()
        {
            //prepare
            ContactData contact = new ContactData("NewName", "NewLastName");
            app.Contacts.ContactsCheck(contact);

            //actions
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetailsMenu(0);

            //validation
            Assert.AreEqual(fromForm.AllContactDataToCompare, fromDetails.AllContactData);
        }

        [Test]
        public void TestContactInformation_Details_Menu()
        {
            //prepare
            ContactData contact = new ContactData("NewName", "NewLastName");
            app.Contacts.ContactsCheck(contact);

            //actions
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetailsMenu(0);

            //validation
            Assert.AreEqual(fromTable.AllContactDataToCompare, fromDetails.AllContactData);
        }
    }
}
