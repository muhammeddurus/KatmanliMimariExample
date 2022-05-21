using KatmanliDAL;
using KatmanliDTO.DTO;
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

        public List<SupplierDto> GetAll()
        {
            try
            {
                List<SupplierDto> supplierDtos = new List<SupplierDto>();
                List<Supplier> suppliers = db.Suppliers.ToList();
                foreach (var item in suppliers)
                {
                    var donenDto = SupplierToSupplierDto(item);
                    supplierDtos.Add(donenDto);
                }

                return supplierDtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public SupplierDto GetById(int itemId)
        {
            var supplier = db.Suppliers.Find(itemId);
            return SupplierToSupplierDto(supplier);
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
        private SupplierDto SupplierToSupplierDto(Supplier supplier)
        {
            return new SupplierDto
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Products = supplier.Products



            };
        }
    }
}
