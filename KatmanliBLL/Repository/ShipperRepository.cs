using KatmanliDAL;
using KatmanliDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    public class ShipperRepository : IRepository<Shipper>
    {

        NorthwindEntities db = new NorthwindEntities();
        public void Delete(int itemId)
        {
            Shipper deleted = db.Shippers.Find(itemId);
            db.Shippers.Remove(deleted);
            db.SaveChanges();
        }

        public List<ShipperDto> GetAll()
        {
            try
            {
                List<ShipperDto> shipperDtos = new List<ShipperDto>();
                List<Shipper> shippers = db.Shippers.ToList();
                foreach (var item in shippers)
                {
                    var donenDto = ShipperToShipperDto(item);
                    shipperDtos.Add(donenDto);
                }

                return shipperDtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public ShipperDto GetById(int itemId)
        {
            var shipper = db.Shippers.Find(itemId);
            return ShipperToShipperDto(shipper);
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
        private ShipperDto ShipperToShipperDto(Shipper shipper)
        {
            return new ShipperDto
            {
               ShipperID=shipper.ShipperID,
               CompanyName=shipper.CompanyName,
               Phone=shipper.Phone,
               Orders=shipper.Orders



            };
        }
    }
}
