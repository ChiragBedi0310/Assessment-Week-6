using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BAL
{
    public class BusinessLogic
    {
        DataLink obj = new DataLink();

        public bool InsertData(Book book)
        {
            if (obj.Insert(book))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(int id)
        {
            if (obj.Delete(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateData(Book book)
        {
            if (obj.Update(book))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ShowData()
        {
            return obj.Show();

        }
    }
}
