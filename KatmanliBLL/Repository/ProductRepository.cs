using KatmanliDAL;
using KatmanliDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Product deleted = db.Products.Find(itemId);
            db.Products.Remove(deleted);
            db.SaveChanges();
        }

        public List<ProductDto> GetAll()
        {
            try
            {
                List<ProductDto> productDtos = new List<ProductDto>();
                List<Product> products = db.Products.ToList();
                foreach (var item in products)
                {
                    var donenDto = ProductToProductDto(item);
                    productDtos.Add(donenDto);
                }

                return productDtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public ProductDto GetById(int itemId)
        {
            var product = db.Products.Find(itemId);
            return ProductToProductDto(product);
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
        private ProductDto ProductToProductDto(Product product)
        {
            return new ProductDto
            {
               ProductID= product.ProductID,
               ProductName = product.ProductName,
               UnitPrice = product.UnitPrice,
               Category= product.Category,
               QuantityPerUnit= product.QuantityPerUnit,
               UnitsInStock= product.UnitsInStock,
               Supplier= product.Supplier,
               CategoryID= product.CategoryID,
               Order_Details= product.Order_Details,
               SupplierID = product.SupplierID



            };
        }
    }
}
