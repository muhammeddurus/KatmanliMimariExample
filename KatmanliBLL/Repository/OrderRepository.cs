using KatmanliDAL;
using KatmanliDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    public class OrderRepository : IRepository<Order>
    {

        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Order deleted = db.Orders.Find(itemId);
            db.Orders.Remove(deleted);
            db.SaveChanges();
        }

        public List<OrderDto> GetAll()
        {
            try
            {
                List<OrderDto> orderDtos = new List<OrderDto>();
                List<Order> orders = db.Orders.ToList();
                foreach (var item in orders)
                {
                    var donenDto = OrderToOrderDto(item);
                    orderDtos.Add(donenDto);
                }

                return orderDtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public OrderDto GetById(int itemId)
        {
            var order = db.Orders.Find(itemId);
            return OrderToOrderDto(order);
        }

        public void Insert(Order item)
        {
            db.Orders.Add(item);
            db.SaveChanges();
        }

        public void Update(Order item)
        {
            db.Entry(db.Orders.Find(item.OrderID)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
        private OrderDto OrderToOrderDto(Order order)
        {
            return new OrderDto
            {
                OrderID = order.OrderID,
                Order_Details = order.Order_Details,
                Customer = order.Customer,
                OrderDate=order.OrderDate,
                ShipCity=order.ShipCity,
                ShipCountry=order.ShipCountry,
                RequiredDate=order.RequiredDate,
                ShipName=order.ShipName,
                Shipper = order.Shipper,
                ShippedDate=order.ShippedDate
                

                
            };
        }
    }
}
