using KatmanliDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    class OrderDetailRepository : IRepository<Order_Detail>
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Order_Detail deleted = db.Order_Details.Find(itemId);
            db.Order_Details.Remove(deleted);
            db.SaveChanges();
        }

        public List<Order_Detail> GetAll()
        {
            return db.Order_Details.ToList();
        }

        public Order_Detail GetById(int itemId)
        {
            return db.Order_Details.Find(itemId);
        }

        public void Insert(Order_Detail item)
        {
            db.Order_Details.Add(item);
            db.SaveChanges();
        }

        public void Update(Order_Detail item)
        {
            
            db.Entry(db.Order_Details.Find(item.ProductID)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
