using Business;
using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace TerraSales.Controllers.Api
{
    [RoutePrefix("api/sales")]
    public class SalesController : ApiController
    {

        /// <summary>
        /// This method receives an Integer in the queryString and returns an order with all details associated
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <description>poipoipoip</description>
        /// <response code="200">Process OK</response>
        /// <response code="400">Invalid parameters sent</response>
        /// <response code="404">Order not found</response>
        /// <response code="500">Excpetion unhandled</response> 
        /// <returns>Returns an order with all details associated</returns>
        [HttpGet]
        [Route("ordersById/{orderId:int}")]
        [ResponseType(typeof(SalesViewModel))]
        public IHttpActionResult GetOrdersById(int orderId)
        {

            var sales = new Sales();
            var response = sales.GetSaleByOrderId(orderId);
            if (response.Result == Result.NotFound)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        /// This method receives a model with the Username and details for the purchase, de details contains a list of desc and price
        /// This method authomatically creates the orderId and sequence for those details
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <description>poipoipoip</description>
        /// <response code="201">Created - Process OK</response>
        /// <response code="400">Invalid parameters sent</response>
        /// <response code="500">Excpetion unhandled</response> 
        /// <returns>Returns an order with all details associated</returns>
        [HttpPost]
        [Route("CreateOrder")]
        [ResponseType(typeof(SalesViewModel))]
        public IHttpActionResult CreateOrder(AddSaleModel addSale)
        {
            if (ModelState.IsValid)
            {
                var sales = new Sales();
                var response = sales.AddSale(addSale);
                //var resp = Request.CreateResponse(HttpStatusCode.OK, "");

                return Created(new Uri(Request.RequestUri + "/" + response.salesOrder.OrderID.ToString()), response);
            }
            return BadRequest("Parameters are not valid");

        }

        /// <summary>
        /// This method receives a model with the orderId and deletes from Database also deletes all of details associated to it
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <description>poipoipoip</description>
        /// <response code="200">Process OK</response>
        /// <response code="400">Invalid parameters sent</response>
        /// <response code="404">Order not found</response>
        /// <response code="500">Excpetion unhandled</response> 
        /// <returns>Returns an order with all details associated</returns>
        [HttpDelete]
        [Route("DeleteOrder")]
        //[ResponseType(typeof(SalesViewModel))]
        public IHttpActionResult DeleteOrder(DeleteOrderModel deleteSale)
        {
            if (ModelState.IsValid)
            {
                var sales = new Sales();
                if (sales.DeleteSale(deleteSale.OrderId))
                {
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest("Parameters are not valid");

        }

        /// <summary>
        /// This method receives an Order Id and a list of details to edit, each detail must contain a sequece, desc and price
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <description>poipoipoip</description>
        /// <response code="200">Edition - Process OK</response>
        /// <response code="400">Invalid parameters sent</response>
        /// <response code="404">Order not found</response>
        /// <response code="500">Excpetion unhandled</response> 
        /// <returns>Returns an order with all details associated</returns>
        [HttpPut]
        [Route("EditOrder")]
        [ResponseType(typeof(SalesViewModel))]
        public IHttpActionResult EditOrder(EditSaleModel editSale)
        {
            if (ModelState.IsValid)
            {
                var sales = new Sales();
                var response = sales.EditSale(editSale);
                if (response.Result == Result.Success)
                {
                    return Ok(response);
                }
                else
                {

                    return NotFound();
                }
            }
            return BadRequest("Parameters are not valid");

        }
    }
}
