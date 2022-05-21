using KatmanliDAL;
using KatmanliDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    public class OrderDetailRepository : IRepository<Order_Detail>
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Order_Detail deleted = db.Order_Details.Find(itemId);
            db.Order_Details.Remove(deleted);
            db.SaveChanges();
        }

        public List<OrderDetailDto> GetAll()
        {
            try
            {
                List<OrderDetailDto> orderDetailDto = new List<OrderDetailDto>();
                List<Order_Detail> order_Details = db.Order_Details.ToList();
                foreach (var item in order_Details)
                {
                    var donenDto = OrderDetailToOrderDetailDto(item);
                    orderDetailDto.Add(donenDto);
                }
                return orderDetailDto;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public OrderDetailDto GetById(int itemId)
        {
            var orderDetail = db.Order_Details.Find(itemId);
            return OrderDetailToOrderDetailDto(orderDetail);
        }

        public void Insert(Order_Detail item)
        {
            db.Order_Details.Add(item);
            db.SaveChanges();
        }

        public void Update(Order_Detail item)
        {
            
            db.Entry(db.Order_Details.Find(item.ProductID)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
        public OrderDetailDto OrderDetailToOrderDetailDto(Order_Detail order_Detail)
        {
            return new OrderDetailDto
            {
                OrderID=order_Detail.OrderID,
                ProductID = order_Detail.ProductID,
                Product = order_Detail.Product,
                Order=order_Detail.Order,
                UnitPrice=order_Detail.UnitPrice,
                Quantity=order_Detail.Quantity

            };
        }
    }
}
