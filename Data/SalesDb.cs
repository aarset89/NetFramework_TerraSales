using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SalesDb //: TerraSalesDb
    {
        private TerraSalesDb _context;

        public SalesDb()
        {
            _context = new TerraSalesDb();
        }

        public SalesOrder GetSaleByOrderId(int orderId)
        {
            SalesOrder so = _context.SalesOrders.Where(s => s.OrderID == orderId).SingleOrDefault();

            if (so == null)
            {
                return null;
            }

            return so;
        }

        public List<SalesOrderDetail> GetSaleDetailsByOrderId(int orderId)
        {
            return _context.SalesOrderDetails.Where(s => s.OrderID == orderId).ToList();
        }

        public SalesOrder AddSale(SalesOrder salesOrder)
        {
            salesOrder.OrderNumber = _context.SalesOrders.Select(s => s.OrderNumber).Max()+1;

            var r =_context.SalesOrders.Add(salesOrder);
            _context.SaveChanges();

            return r;

            
        }
        public void AddSaleDetail(List<SalesOrderDetail> salesOrderDetails)
        {
            _context.SalesOrderDetails.AddRange(salesOrderDetails);
            _context.SaveChanges();
        }

        public bool DeleteSale(int orderId)
        {
            var orderInDb = _context.SalesOrders.SingleOrDefault(m => m.OrderID == orderId);
            if (orderInDb == null)
                return false;

            _context.SalesOrders.Remove(orderInDb);
            _context.SaveChanges();
            return true;

        }

        public void EditSale(List<SalesOrderDetail> salesOrderDetails)
        {

            foreach(var t in salesOrderDetails)
            {
                var detailInDb = _context.SalesOrderDetails.Single(m => m.OrderID == t.OrderID && m.Sequence == t.Sequence);
                detailInDb.Price = t.Price;
                detailInDb.Description = t.Description;
                _context.SaveChanges();
            }

        }

    }
}
