using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetSaleByOrderId_OK()
        {

            Sales sales = new Sales();

            var t = sales.GetSaleByOrderId(1);

            if (t.Result == Model.Result.Success)
            {
                Assert.AreEqual(typeof(int), t.salesOrder.OrderID.GetType());
            }


        }

        [TestMethod]
        public void GetSaleByOrderId_BAD()
        {

            Sales sales = new Sales();

            var t = sales.GetSaleByOrderId(9999);

            if (t.Result == Model.Result.NotFound)
            {

            }
            else
            {
                Assert.Fail();
            }


        }


        [TestMethod]
        public void CreateOrder_OK()
        {
            var rand = new Random();
            Sales sales = new Sales();
            List<AddSaleDetailsModel> dm = new List<AddSaleDetailsModel>();

            for (int i = 0; i < rand.Next(0, 20); i++)
            {
                dm.Add(new AddSaleDetailsModel()
                {
                    description = "Desc " + i,
                    price = i * 100
                });
            }
            var t = sales.AddSale(new Model.AddSaleModel()
            {
                userName = "Test 1",
                details = dm
            }); ;

            if (t.Result == Model.Result.Success)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }


        }
        
        [TestMethod]
        public void EditOrder_OK()
        {
            int orderId = 1;
            var rand = new Random();
            Sales sales = new Sales();
            List<EditSaleDetailsModel> dm = new List<EditSaleDetailsModel>();

            for (int i = 0; i < 2; i++)
            {
                dm.Add(new EditSaleDetailsModel()
                {
                    Sequence = i+1,
                    description = "Desc " + i,
                    price = i * 100
                });
            }
            var t = sales.EditSale(new Model.EditSaleModel()
            {
                OrderId = orderId,
                details = dm
            }); ;

            if (t.Result == Model.Result.Success)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }


        }
        [TestMethod]
        public void EditOrder_BAD()
        {
            int orderId = 100;
            var rand = new Random();
            Sales sales = new Sales();
            List<EditSaleDetailsModel> dm = new List<EditSaleDetailsModel>();

            for (int i = 0; i < 2; i++)
            {
                dm.Add(new EditSaleDetailsModel()
                {
                    Sequence = i+1,
                    description = "Desc " + i,
                    price = i * 100
                });
            }
            var t = sales.EditSale(new Model.EditSaleModel()
            {
                OrderId = orderId,
                details = dm
            }); ;

            if (t.Result == Model.Result.Success)
            {
                Assert.Fail();
            }
            else
            {
                Assert.IsTrue(true);
            }


        }
    }
}
