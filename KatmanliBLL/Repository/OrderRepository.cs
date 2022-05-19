using KatmanliDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    public class OrderRepository : IRepository<Order>
    {

        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Order deleted = db.Orders.Find(itemId);
            db.Orders.Remove(deleted);
            db.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public Order GetById(int itemId)
        {
            return db.Orders.Find(itemId);
        }

        public void Insert(Order item)
        {
            db.Orders.Add(item);
            db.SaveChanges();
        }

        public void Update(Order item)
        {
            db.Entry(db.Orders.Find(item.OrderID)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
