using KatmanliDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    public class SupplierRepository : IRepository<Supplier>
    {

        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Supplier deleted = db.Suppliers.Find(itemId);
            db.Suppliers.Remove(deleted);
            db.SaveChanges();
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public Supplier GetById(int itemId)
        {
            return db.Suppliers.Find(itemId);
        }

        public void Insert(Supplier item)
        {
            db.Suppliers.Add(item);
            db.SaveChanges();
        }

        public void Update(Supplier item)
        {
            db.Entry(db.Suppliers.Find(item.SupplierID)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
