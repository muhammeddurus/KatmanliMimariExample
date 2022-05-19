using KatmanliDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {

        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Customer deleted = db.Customers.Find(itemId);
            db.Customers.Remove(deleted);
            db.SaveChanges();
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public Customer GetById(int itemId)
        {
            return db.Customers.Find(itemId);
        }

        public void Insert(Customer item)
        {
            db.Customers.Add(item);
            db.SaveChanges();
        }

        public void Update(Customer item)
        {
            db.Entry(db.Customers.Find(item.CustomerID)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
