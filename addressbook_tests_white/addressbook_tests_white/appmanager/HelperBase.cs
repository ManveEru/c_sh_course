using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;

namespace addressbook_tests_white
{
    public class HelperBase
    {
        public ApplicationManager manager;

        public HelperBase (ApplicationManager manager)
        {
            this.manager = manager;
        }

        public Window OpenModalWindow(Window parentWindow, String triggerButton, String modalWindowTitle)
        {
            parentWindow.Get<Button>(triggerButton).Click();
            return parentWindow.ModalWindow(modalWindowTitle);
        }
    }
}