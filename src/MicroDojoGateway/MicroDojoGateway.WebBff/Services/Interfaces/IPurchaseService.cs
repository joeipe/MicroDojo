using MicroDojoGateway.WebBff.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroDojoGateway.WebBff.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<HttpResponseMessage> AddOrder(OrderVM value);

        Task<HttpResponseMessage> AddStock(StockVM value);

        Task<HttpResponseMessage> DeleteOrder(int id);

        Task<HttpResponseMessage> DeleteStock(int id);

        Task<List<OrderVM>> GetOrder();

        Task<OrderVM> GetOrderById(int id);

        Task<List<PersonPurchaseVM>> GetPerson();

        Task<PersonPurchaseVM> GetPersonById(int id);

        Task<List<StockVM>> GetStock();

        Task<StockVM> GetStockById(int id);

        Task<HttpResponseMessage> UpdateOrder(OrderVM value);

        Task<HttpResponseMessage> UpdateStock(StockVM value);
    }
}