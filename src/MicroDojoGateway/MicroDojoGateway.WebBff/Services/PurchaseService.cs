using MicroDojoGateway.WebBff.Extensions;
using MicroDojoGateway.WebBff.Services.Interfaces;
using MicroDojoGateway.WebBff.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroDojoGateway.WebBff.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly HttpClient _client;
        public readonly string _baseUrl;

        public PurchaseService(HttpClient client)
        {
            _client = client;
            _baseUrl = "api/Purchase";
        }

        #region Stock

        public async Task<List<StockVM>> GetStock()
        {
            var url = $"{_baseUrl}/GetStock";
            var response = await _client.GetAsync(url);
            return await response.ReadContentAs<List<StockVM>>();
        }

        public async Task<StockVM> GetStockById(int id)
        {
            var url = $"{_baseUrl}/GetStockById/{id}";
            var response = await _client.GetAsync(url);
            return await response.ReadContentAs<StockVM>();
        }

        public async Task<HttpResponseMessage> AddStock(StockVM value)
        {
            var url = $"{_baseUrl}/AddStock";
            return await _client.PostAsJson(url, value);
        }

        public async Task<HttpResponseMessage> UpdateStock(StockVM value)
        {
            var url = $"{_baseUrl}/UpdateStock";
            return await _client.PutAsJson(url, value);
        }

        public async Task<HttpResponseMessage> DeleteStock(int id)
        {
            var url = $"{_baseUrl}/DeleteStock/{id}";
            return await _client.DeleteAsync(url);
        }

        #endregion Stock

        #region Person

        public async Task<List<PersonPurchaseVM>> GetPerson()
        {
            var url = $"{_baseUrl}/GetPerson";
            var response = await _client.GetAsync(url);
            return await response.ReadContentAs<List<PersonPurchaseVM>>();
        }

        public async Task<PersonPurchaseVM> GetPersonById(int id)
        {
            var url = $"{_baseUrl}/GetPersonById/{id}";
            var response = await _client.GetAsync(url);
            return await response.ReadContentAs<PersonPurchaseVM>();
        }

        #endregion Person

        #region Order

        public async Task<List<OrderVM>> GetOrder()
        {
            var url = $"{_baseUrl}/GetOrder";
            var response = await _client.GetAsync(url);
            return await response.ReadContentAs<List<OrderVM>>();
        }

        public async Task<OrderVM> GetOrderById(int id)
        {
            var url = $"{_baseUrl}/GetOrderById/{id}";
            var response = await _client.GetAsync(url);
            return await response.ReadContentAs<OrderVM>();
        }

        public async Task<HttpResponseMessage> AddOrder(OrderVM value)
        {
            var url = $"{_baseUrl}/AddOrder";
            return await _client.PostAsJson(url, value);
        }

        public async Task<HttpResponseMessage> UpdateOrder(OrderVM value)
        {
            var url = $"{_baseUrl}/UpdateOrder";
            return await _client.PutAsJson(url, value);
        }

        public async Task<HttpResponseMessage> DeleteOrder(int id)
        {
            var url = $"{_baseUrl}/DeleteOrder/{id}";
            return await _client.DeleteAsync(url);
        }

        #endregion Order
    }
}