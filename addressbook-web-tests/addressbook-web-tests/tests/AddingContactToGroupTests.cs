using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> groupsList = GroupData.GetAll();
            List<ContactData> contactsList = ContactData.GetAll();
            ContactData contact = null;
            GroupData group = null;

            //если нет контактов или групп создаём один из них
            if (groupsList.Count == 0)
            {
                app.Groups.Create(new GroupData("gropForContactAdding"));
                group = GroupData.GetAll()[0];
            }
            if (contactsList.Count == 0)
            {
                app.Contacts.Create(new ContactData("forAdding") {LastName = "forCompare"});
                contact = ContactData.GetAll()[0];
            }
            //если есть заранее созданные контакты и группы, то проверим, что есть контакт, ещё не добавленный в группу
            //или создадим такой если не найдётся
            if ((group is null) && (contact is null))
            {
                List<ContactData> contactsInGroup = new List<ContactData>();
                foreach(GroupData g in groupsList)
                {
                    foreach(ContactData c in g.GetContacts())
                    {
                        contactsInGroup.Add(c);
                    }
                }
                contact = contactsList.Except(contactsInGroup).Count() == 0 ? null : contactsList.Except(contactsInGroup).First();
                if (contact is null)
                {
                    app.Contacts.Create(new ContactData("forAdding1"));
                    contact = ContactData.GetAll().Except(contactsList).First();
                }
                group = groupsList[0];
            }
            //если группы были, а контакт свежесоздан, то берём любую группу
            else if (group is null) 
            {
                group = groupsList[0];
            }
            //если контакты были, а группа свежесоздана, то берём любой контакт
            else if (contact is null)
            {
                contact = contactsList[0];
            }
            List<ContactData> oldList = group.GetContacts();
            
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
