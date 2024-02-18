using Microsoft.AspNetCore.Mvc;
using metaExchangeTask;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using static metaExchangeTask.Program;

namespace MetaExchangeTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMetaExchange _metaExchangeAppLibrary;

        public OrderController(IMetaExchange metaExchangeAppLibrary)
        {
            _metaExchangeAppLibrary = metaExchangeAppLibrary;
        }

        [HttpPost("execute-order")]
        public IActionResult ExecuteOrder([FromBody] OrderRequest orderRequest)
        {
            if (orderRequest == null)
            {
                return BadRequest("Invalid order request.");
            }

            // Validate order request (add specific checks here)
            if (!IsValidOrderRequest(orderRequest))
            {
                return BadRequest("Invalid order request data.");
            }

            try
            {
                string filePath = @"C:\Users\Solmaz Ibrahimova\Desktop\test2.txt";
                List<OrderBook> orderBooks = _metaExchangeAppLibrary.DeserializeJsonData(filePath);

                Balance balances = new Balance
                {
                    BTCbalance = 1000,
                    EURObalance = 1000000000
                };

                // Adjust arguments for GetMatchedOrders based on your library's requirements
                List<Order> executionPlan = _metaExchangeAppLibrary.GetMatchedOrders(orderBooks, orderRequest.OrderType, orderRequest.Amount, balances);

                if (executionPlan == null)
                {
                    throw new InvalidOperationException("Failed to determine execution plan.");
                }

                return Ok(executionPlan);
            }
            catch (Exception ex)
            {
                // Log exception details
                // ...
                return StatusCode(500, "Failed to execute order.");
            }
        }

        // Additional methods for validation and error handling
        private bool IsValidOrderRequest(OrderRequest orderRequest)
        {
            // Implement specific validation checks here
            // ...
            return true;
        }

        // Define a specific response class for execution plans (if needed)
        public class OrderRequest
        {
            public OrderType OrderType { get; set; }
            public decimal Amount { get; set; }
            // Other properties as needed
        }
    }
}
