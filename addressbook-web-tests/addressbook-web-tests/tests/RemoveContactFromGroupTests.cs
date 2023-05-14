using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemoveContactFromGroupTest()
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
                app.Contacts.Create(new ContactData("forAdding") { LastName = "forCompare" });
                contact = ContactData.GetAll()[0];
            }
            //если есть заранее созданные контакты и группы, то проверим, что есть контакт, ещё не добавленный в группу
            //или создадим такой если не найдётся
            if ((group is null) && (contact is null))
            {
                foreach (GroupData g in groupsList)
                {
                    if (g.GetContacts().Count > 0)
                    {
                        group = g;
                        contact = g.GetContacts()[0];
                        break;
                    }
                }
                if (group is null)
                {
                    group = groupsList[0];
                    contact = contactsList[0];
                    app.Contacts.AddContactToGroup(contact, group);
                }
            }
            //если группы были, а контакт свежесоздан, то берём любую группу
            else if (group is null)
            {
                group = groupsList[0];
                app.Contacts.AddContactToGroup(contact, group);
            }
            //если контакты были, а группа свежесоздана, то берём любой контакт
            else if (contact is null)
            {
                contact = contactsList[0];
                app.Contacts.AddContactToGroup(contact, group);
            }
            List<ContactData> oldList = group.GetContacts();

            app.Contacts.RemoveContactFromGroup(group, contact);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
