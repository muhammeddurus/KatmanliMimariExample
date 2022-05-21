using KatmanliDAL;
using KatmanliDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {

        NorthwindEntities db = ConnectionSettings.DbInstance;
        public void Delete(int itemId)
        {
            Customer deleted = db.Customers.Find(itemId);
            db.Customers.Remove(deleted);
            db.SaveChanges();
        }

        public List<CustomerDto> GetAll()
        {
            try
            {
                List<CustomerDto> customerDtos = new List<CustomerDto>();
                List<Customer> customers = db.Customers.ToList();
                foreach (var item in customers)
                {
                    var donenDto = CustomerToCustomerDto(item);
                    customerDtos.Add(donenDto);
                }
                return customerDtos;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                throw;
            }
           
        }

        public CustomerDto GetById(int itemId)
        {
            var customer = db.Customers.Find(itemId);
            return CustomerToCustomerDto(customer);
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
        private CustomerDto CustomerToCustomerDto(Customer customer)
        {
            return new CustomerDto
            {
                CustomerID=customer.CustomerID,
                CompanyName = customer.CompanyName,
                City = customer.City,
                Country=customer.Country,
                ContactTitle=customer.ContactTitle,
                Orders=customer.Orders,
                Region=customer.Region,
                ContactName=customer.ContactName

            };
        }
    }
}
