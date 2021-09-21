using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressBookTests;

namespace test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            string type = args[3];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                { 
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }

            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                {
                    Firstname = TestBase.GenerateRandomString(10),
                    Lastname = TestBase.GenerateRandomString(10),
                });
            }

            if (format == "xml"
                && type == "groups")
            {
                writeGroupsToXmlFile(groups, writer);
            } else if (format == "json"
                && type == "groups")
            {
                writeGroupsToJsonFile(groups, writer);
            }
            else if (format == "xml"
              && type == "contacts")
            {
                writeContactsToXmlFile(contacts, writer);
            }
            else if (format == "json"
              && type == "contacts")
            {
                writeContactsToJsonFile(contacts, writer);
            }
            else
            {
                System.Console.Out.Write("Unknown input");
            }

            writer.Close();
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
