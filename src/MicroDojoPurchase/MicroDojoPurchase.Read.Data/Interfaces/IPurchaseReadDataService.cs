using MicroDojoPurchase.Read.Domain;
using System;
using System.Collections.Generic;

namespace MicroDojoPurchase.Read.Data.Interfaces
{
    public interface IPurchaseReadDataService
    {
        IEnumerable<Stock> GetStock();

        Stock GetStockById(int id);

        IEnumerable<Person> GetPerson();

        Person GetPersonById(int id);

        Person GetPersonByPersonRefId(Guid personRefId);

        IEnumerable<Order> GetOrder();

        Order GetOrderById(int id);
    }
}