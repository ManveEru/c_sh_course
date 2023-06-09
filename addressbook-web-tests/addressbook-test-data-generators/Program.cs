﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

            if (dataType == "group")
            {
                List<GroupData> groups = GenerateGroups(count);
                WriteGroupsToFile(format, groups, writer);
            }
            else if (dataType == "contact")
            {
                List<ContactData> contacts = GenerateContacts(count);
                WriteContactsToFile(format, contacts, writer);
            }
            else
                System.Console.Out.WriteLine("Unrecognized data type " + dataType);
            writer.Close();
        }

        private static List<ContactData> GenerateContacts(int count)
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                {
                    LastName = TestBase.GenerateRandomString(10)
                });
            }
            return contacts;
        }

        static List<GroupData> GenerateGroups(int count)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
            return groups;
        }

        private static void WriteGroupsToFile(string format, List<GroupData> groups, StreamWriter writer)
        {
            if (format == "csv")
                WriteGroupsToCsvFile(groups, writer);
            else if (format == "xml")
                WriteGroupsToXmlFile(groups, writer);
            else if (format == "json")
                WriteGroupsToJsonFile(groups, writer);
            else
                System.Console.Out.WriteLine("Unrecognized format " + format);
        }

        private static void WriteContactsToFile(string format, List<ContactData> contacts, StreamWriter writer)
        {
            if (format == "csv")
                WriteContactsToCsvFile(contacts, writer);
            else if (format == "xml")
                WriteContactsToXmlFile(contacts, writer);
            else if (format == "json")
                WriteContactsToJsonFile(contacts, writer);
            else
                System.Console.Out.WriteLine("Unrecognized format " + format);
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("{0},{1},{2}", group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("{0},{1}", contact.FirstName, contact.LastName));
            }
        }

        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
