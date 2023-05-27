using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;

namespace addressbook_tests_white
{
    public class UserHelper : HelperBase
    {
        public static string DELETEUSERWINTITLE = "Delete group";

        public UserHelper(ApplicationManager manager) : base(manager) { }

        public List<UserData> GetUserList()
        {
            List<UserData> list = new List<UserData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new UserData() { Name = item.Text });
            }
            CloseGroupsDialogue(dialogue);
            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox)dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialogue(dialogue);
        }

        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        public void Remove(int index)
        {
            Window groupDialogue = OpenGroupsDialogue();
            Tree tree = groupDialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            root.Nodes[index].Click();
            Window deleteGroupDilogue = OpenDeleteGroupsDialogue(groupDialogue);
            deleteGroupDilogue.Get<RadioButton>("uxDeleteAllRadioButton").Click();
            ConfirmDeleteGroups(deleteGroupDilogue);
            CloseGroupsDialogue(groupDialogue);
        }

        private Window OpenDeleteGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            return dialogue.ModalWindow(DELETEGROUPWINTITLE);
        }

        private void ConfirmDeleteGroups(Window dialogue)
        {
            dialogue.Get<Button>("uxOKAddressButton").Click();
        }
    }
}
