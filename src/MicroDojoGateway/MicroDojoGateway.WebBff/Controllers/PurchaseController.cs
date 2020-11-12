using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MicroDojoGateway.WebBff.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroDojoGateway.WebBff.Controllers
{
    [Route("api/bffweb/[controller]/[action]")]
    [ApiController]
    public class PurchaseController : ApiController
    {
        private readonly ILogger<PurchaseController> _logger;
        public readonly string _baseUrl;

        public PurchaseController(ILogger<PurchaseController> logger, IHttpClientFactory httpClientFactory)
            :base(httpClientFactory.CreateClient("Purchase_APIClient"))
        {
            _logger = logger;
            _baseUrl = "api/Purchase";
        }

        #region Stock

        [HttpGet]
        public async Task<ActionResult> GetStock()
        {
            var url = $"{_baseUrl}/GetStock";
            return await PerformRequest<List<StockVM>>(url);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetStockById(int id)
        {
            var url = $"{_baseUrl}/GetStockById/{id}";
            return await PerformRequest<StockVM>(url);
        }

        [HttpPost]
        public async Task<ActionResult> AddStock([FromBody] StockVM value)
        {
            var url = $"{_baseUrl}/AddStock";
            return await PerformRequest<bool>(url, value);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStock([FromBody] StockVM value)
        {
            var url = $"{_baseUrl}/UpdateStock";
            return await PerformRequest<bool>(url, value);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStock(int id)
        {
            var url = $"{_baseUrl}/DeleteStock/{id}";
            return await PerformRequest<bool>(url);
        }

        #endregion Stock

        #region Person

        [HttpGet]
        public async Task<ActionResult> GetPerson()
        {
            var url = $"{_baseUrl}/GetPerson";
            return await PerformRequest<List<PersonPurchaseVM>>(url);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPersonById(int id)
        {
            var url = $"{_baseUrl}/GetPersonById/{id}";
            return await PerformRequest<PersonPurchaseVM>(url);
        }

        #endregion Person

        #region Order

        [HttpGet]
        public async Task<ActionResult> GetOrder()
        {
            var url = $"{_baseUrl}/GetOrder";
            return await PerformRequest<List<OrderVM>>(url);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            var url = $"{_baseUrl}/GetOrderById/{id}";
            return await PerformRequest<OrderVM>(url);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] OrderVM value)
        {
            var url = $"{_baseUrl}/AddOrder";
            return await PerformRequest<bool>(url, value);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrder([FromBody] OrderVM value)
        {
            var url = $"{_baseUrl}/UpdateOrder";
            return await PerformRequest<bool>(url, value);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var url = $"{_baseUrl}/DeleteOrder/{id}";
            return await PerformRequest<bool>(url);
        }

        #endregion Order
    }
}
