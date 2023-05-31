using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;

namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {
        public static string DELETEUSERWINTITLE = "Question";
        public static string CONTACTEDITORWINTITLE = "Contact Editor";
        public static string QUESTIONWINTITLE = "Question";

        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();
            TableRows rows = manager.MainWindow.Get<Table>("uxAddressGrid").Rows;
            foreach (TableRow item in rows)
            {
                list.Add(new ContactData() { FirstName = item.Cells[0].Value.ToString() });
                System.Console.Out.WriteLine(item.Cells[0].Value.ToString());
            }
            return list;
        }

        public void Add(ContactData newContact)
        {
            Window dialogue = OpenModalWindow(manager.MainWindow, "uxNewAddressButton", CONTACTEDITORWINTITLE);
            TextBox textBox = dialogue.Get<TextBox>("ueFirstNameAddressTextBox");
            textBox.Enter(newContact.FirstName);
            dialogue.Get<Button>("uxSaveAddressButton").Click();
        }
        public void Remove(int index)
        {
            manager.MainWindow.Get<Table>("uxAddressGrid").Rows[index].Click();
            Window deleteContactDilogue = OpenModalWindow(manager.MainWindow, "uxDeleteAddressButton", QUESTIONWINTITLE);
            deleteContactDilogue.Get<Button>(SearchCriteria.ByText("Yes")).Click();
        }
    }
}
