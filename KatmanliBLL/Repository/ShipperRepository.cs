using KatmanliDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    class ShipperRepository : IRepository<Shipper>
    {

        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Shipper deleted = db.Shippers.Find(itemId);
            db.Shippers.Remove(deleted);
            db.SaveChanges();
        }

        public List<Shipper> GetAll()
        {
            return db.Shippers.ToList();
        }

        public Shipper GetById(int itemId)
        {
            return db.Shippers.Find(itemId);
        }

        public void Insert(Shipper item)
        {
            db.Shippers.Add(item);
            db.SaveChanges();
        }

        public void Update(Shipper item)
        {
            db.Entry(db.Shippers.Find(item.ShipperID)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
