﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressBookTests
{
    public class AddingContactToGroupTets : AuthTestBase
    {
        [Test]
        public void AddingContactToGroup()
        {
            //prepare group
            List<GroupData> atLeastOneGroupExists = GroupData.GetAll();
            if (atLeastOneGroupExists.Count == 0)
            {
                GroupData newGroup = new GroupData("New Group");
                app.Groups.Create(newGroup);
            }
            GroupData group = GroupData.GetAll()[0];


            //prepare contact without group
            List<ContactData> oldList = group.GetContacts();
            if (oldList.Count == 0)
            {
                ContactData newContact = new ContactData("New Contact");
                app.Contacts.Create(newContact);
            }
            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).First();

            //action
            app.Contacts.AddContactToGroup(contact, group);

            //validation
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void TestDeletingContactFromGroup()
        {
            //prepare
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList[0];

            //action
            app.Contacts.RemoveContactFromGroup(contact, group);

            //validation
            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);                    
            Assert.AreEqual(oldList, newList);

        }
    }
}