using KatmanliDAL;
using KatmanliDTO.DTO;
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

        public List<EmployeeDto> GetAll()
        {

            try
            {
                List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
                List<Employee> employees = db.Employees.ToList();
                foreach (var item in employees)
                {
                    var donenDto = EmployeeToEmployeeDto(item);
                    employeeDtos.Add(donenDto);
                }

                return employeeDtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public EmployeeDto GetById(int itemId)
        {
            var employee = db.Employees.Find(itemId);
            return EmployeeToEmployeeDto(employee);
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
        public EmployeeDto EmployeeToEmployeeDto(Employee employee)
        {
            return new EmployeeDto
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Orders = employee.Orders,
                Employee1 = employee.Employee1,
                Employees1 = employee.Employees1

            };
        }
    }
}
