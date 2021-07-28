using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Sales
    {


        public SalesViewModel GetSaleByOrderId(int orderId)
        {
            SalesViewModel svm = new SalesViewModel() { Result = Result.Error };
            try
            {
                SalesDb dataAccess = new SalesDb();

                var order = dataAccess.GetSaleByOrderId(orderId);
                if (order == null)
                {
                    svm.Result = Result.NotFound;
                    return svm;
                }
                List<SalesOrderDetailsModel> salesOrderDetailsModels = new List<SalesOrderDetailsModel>();
                SalesOrderModel salesOrderModel = new SalesOrderModel()
                {
                    OrderID = order.OrderID,
                    OrderNumber = order.OrderNumber,
                    UserName = order.UserName
                };

                var listDetails = dataAccess.GetSaleDetailsByOrderId(orderId);

                listDetails.ForEach(delegate (SalesOrderDetail sd)
                {
                    salesOrderDetailsModels.Add(
                        new SalesOrderDetailsModel()
                        {
                            Description = sd.Description,
                            OrderID = sd.OrderID,
                            Price = sd.Price,
                            Sequence = sd.Sequence
                        }
                        );
                });

                svm.Result = Result.Success;
                svm.salesOrder = salesOrderModel;
                svm.salesOrderDetails = salesOrderDetailsModels;
                return svm;


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SalesViewModel AddSale(AddSaleModel addSale)
        {
            try
            {
                SalesDb salesDb = new SalesDb();
                var order = salesDb.AddSale(new SalesOrder()
                {
                    UserName = addSale.userName,
                });

                List<SalesOrderDetail> salesOrderDetails = new List<SalesOrderDetail>();
                int seq = 1;
                foreach (var detail in addSale.details)
                {
                    salesOrderDetails.Add(
                        new SalesOrderDetail()
                        {
                            Description = detail.description,
                            OrderID = order.OrderID,
                            Price = detail.price,
                            Sequence = seq
                        });
                    seq++;
                }
                salesDb.AddSaleDetail(salesOrderDetails);


                return GetSaleByOrderId(order.OrderID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool DeleteSale(int orderId)
        {

            SalesDb salesDb = new SalesDb();

            if (salesDb.DeleteSale(orderId))
            {
                return true;
            }

            return false;
        }

        public SalesViewModel EditSale(EditSaleModel editSale)
        {
            SalesViewModel output = new SalesViewModel() { Result = Result.Error };
            try
            {
                var g = GetSaleByOrderId(editSale.OrderId);
                if (g.Result == Result.NotFound)
                {
                    output.Result = Result.NotFound;
                    return output;
                }

                List<SalesOrderDetail> salesOrderDetails = new List<SalesOrderDetail>();

                foreach (var f in editSale.details)
                {
                    var t = g.salesOrderDetails.Where(o => o.OrderID == editSale.OrderId && o.Sequence == f.Sequence).SingleOrDefault();
                    if (t == null)
                    {
                        output.Result = Result.NotFound;
                        return output;
                    }

                    salesOrderDetails.Add(
                        new SalesOrderDetail()
                        {
                            Description = f.description,
                            OrderID = t.OrderID,
                            Price = f.price,
                            Sequence = t.Sequence
                        });

                }

                SalesDb salesDb = new SalesDb();
                salesDb.EditSale(salesOrderDetails);


                return GetSaleByOrderId(editSale.OrderId);
            }
            catch (Exception e)
            {
                return output;
            }


        }


    }
}
