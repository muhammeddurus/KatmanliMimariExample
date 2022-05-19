using KatmanliDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {

        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Employee deleted = db.Employees.Find(itemId);
            db.Employees.Remove(deleted);
            db.SaveChanges();
        }

        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public Employee GetById(int itemId)
        {
            return db.Employees.Find(itemId);
        }

        public void Insert(Employee item)
        {
            db.Employees.Add(item);
            db.SaveChanges();
        }

        public void Update(Employee item)
        {
            db.Entry(db.Employees.Find(item.EmployeeID)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
