using KatmanliDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL
{
    public class ConnectionSettings
    {
        private static NorthwindEntities _db;

        public static NorthwindEntities DbInstance
        {
            get
            {
                if (_db == null)
                {
                    _db = new NorthwindEntities();

                }
                return _db;

            }

        }

    }
}
