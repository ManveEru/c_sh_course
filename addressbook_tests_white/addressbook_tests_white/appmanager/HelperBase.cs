using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook_tests_white
{
    public class HelperBase
    {
        public ApplicationManager manager;

        public HelperBase (ApplicationManager manager)
        {
            this.manager = manager;
        }
    }
}