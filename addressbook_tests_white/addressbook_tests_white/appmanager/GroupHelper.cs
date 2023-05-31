using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenModalWindow(manager.MainWindow, "groupButton", GROUPWINTITLE);
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach(TreeNode item in root.Nodes)
            {
                list.Add(new GroupData() { Name = item.Text });
            }
            dialogue.Get<Button>("uxCloseAddressButton").Click();
            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenModalWindow(manager.MainWindow, "groupButton", GROUPWINTITLE);
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }
        public void Remove(int index)
        {
            Window groupDialogue = OpenModalWindow(manager.MainWindow, "groupButton", GROUPWINTITLE);
            Tree tree = groupDialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            root.Nodes[index].Click();
            Window deleteGroupDilogue = OpenModalWindow(groupDialogue, "uxDeleteAddressButton", DELETEGROUPWINTITLE);
            deleteGroupDilogue.Get<RadioButton>("uxDeleteAllRadioButton").Click();
            deleteGroupDilogue.Get<Button>("uxOKAddressButton").Click();
            groupDialogue.Get<Button>("uxCloseAddressButton").Click();
        }
    }
}