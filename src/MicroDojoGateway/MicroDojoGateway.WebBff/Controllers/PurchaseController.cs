using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MicroDojoGateway.WebBff.Services;
using MicroDojoGateway.WebBff.Services.Interfaces;
using MicroDojoGateway.WebBff.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroDojoGateway.WebBff.Controllers
{
    [Route("api/bffweb/[controller]/[action]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly ILogger<PurchaseController> _logger;
        private readonly IPurchaseService _purchaseService;
        public readonly string _baseUrl;

        public PurchaseController(ILogger<PurchaseController> logger, IPurchaseService purchaseService)
        {
            _logger = logger;
            _purchaseService = purchaseService;
            _baseUrl = "api/Purchase";
        }
        
        #region Stock

        [HttpGet]
        public async Task<ActionResult> GetStock()
        {
            var result = await _purchaseService.GetStock();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetStockById(int id)
        {
            var result = await _purchaseService.GetStockById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddStock([FromBody] StockVM value)
        {
            var response = await _purchaseService.AddStock(value);
            return Created("", value);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStock([FromBody] StockVM value)
        {
            var response = await _purchaseService.UpdateStock(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStock(int id)
        {
            var response = await _purchaseService.DeleteStock(id);
            return Ok();
        }

        #endregion Stock

        #region Person

        [HttpGet]
        public async Task<ActionResult> GetPerson()
        {
            var result = await _purchaseService.GetPerson();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPersonById(int id)
        {
            var result = await _purchaseService.GetPersonById(id);
            return Ok(result);
        }

        #endregion Person

        #region Order

        [HttpGet]
        public async Task<ActionResult> GetOrder()
        {
            var result = await _purchaseService.GetOrder();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            var result = await _purchaseService.GetOrderById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] OrderVM value)
        {
            var response = await _purchaseService.AddOrder(value);
            return Created("", value);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrder([FromBody] OrderVM value)
        {
            var response = await _purchaseService.UpdateOrder(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var response = await _purchaseService.DeleteOrder(id);
            return Ok();
        }

        #endregion Order
        
    }
}
