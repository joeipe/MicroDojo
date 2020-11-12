using MicroDojoPurchase.ViewModels;
using System;
using System.Collections.Generic;

namespace MicroDojoPurchase.Application.Interfaces
{
    public interface IPurchaseAppService
    {
        IList<StockVM> GetStock();

        StockVM GetStockById(int id);

        void AddStock(StockVM value);

        void UpdateStock(StockVM value);

        void DeleteStock(int id);

        IList<PersonVM> GetPerson();

        PersonVM GetPersonById(int id);

        void AddPerson(PersonVM value);

        void UpdatePerson(PersonVM value);

        void DeletePerson(Guid personRefId);

        IList<OrderVM> GetOrder();

        OrderVM GetOrderById(int id);

        void AddOrder(OrderVM value);

        void UpdateOrder(OrderVM value);

        void DeleteOrder(int id);
    }
}