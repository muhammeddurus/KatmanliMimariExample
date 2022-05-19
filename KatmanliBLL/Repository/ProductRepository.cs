using KatmanliDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    class ProductRepository : IRepository<Product>
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Product deleted = db.Products.Find(itemId);
            db.Products.Remove(deleted);
            db.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetById(int itemId)
        {
            return db.Products.Find(itemId);
        }

        public void Insert(Product item)
        {
            db.Products.Add(item);
            db.SaveChanges();
        }

        public void Update(Product item)
        {
            db.Entry(db.Products.Find(item.ProductID)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
