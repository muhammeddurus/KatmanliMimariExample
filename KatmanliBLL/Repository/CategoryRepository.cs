using KatmanliDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    class CategoryRepository : IRepository<Category>
    {

        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Category deleted = db.Categories.Find(itemId);
            db.Categories.Remove(deleted);
            db.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category GetById(int itemId)
        {
            return db.Categories.Find(itemId);
        }

        public void Insert(Category item)
        {
            db.Categories.Add(item);
            db.SaveChanges();
        }

        public void Update(Category item)
        {
            db.Entry(db.Categories.Find(item.CategoryID)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
