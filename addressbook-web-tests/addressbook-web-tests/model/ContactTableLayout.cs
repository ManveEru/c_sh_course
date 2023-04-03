using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    //Класс хранящий расположение кнопок работы с контактом в таблице контактов.
    public class ContactTableLayout
    {
        private int detailColumn = 7;
        private int editColumn = 8;
        private int vCardColumn = 9;

        public int Detail
        {
            get
            {
                return detailColumn;
            }
        }

        public int Edit
        {
            get
            {
                return editColumn;
            }
        }

        public int VCard
        {
            get
            {
                return vCardColumn;
            }
        }
    }
}
