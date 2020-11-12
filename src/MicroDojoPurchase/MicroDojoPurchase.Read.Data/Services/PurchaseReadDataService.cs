using Dapper;
using Dapper.Contrib.Extensions;
using MicroDojoPurchase.Read.Data.Interfaces;
using MicroDojoPurchase.Read.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroDojoPurchase.Read.Data.Services
{
    public class PurchaseReadDataService : IPurchaseReadDataService
    {
        private readonly ReadDbContext _dataContext;

        public PurchaseReadDataService(ReadDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region Stock

        public IEnumerable<Stock> GetStock()
        {
            var data = _dataContext.db.GetAll<Stock>().ToList();
            return data;
        }

        public Stock GetStockById(int id)
        {
            var data = _dataContext.db.Get<Stock>(id);
            return data;
        }

        #endregion Stock

        #region Person

        public IEnumerable<Person> GetPerson()
        {
            var data = _dataContext.db.Query<Person>("select * from People").ToList();
            return data;
        }

        public Person GetPersonById(int id)
        {
            var data = _dataContext.db.QuerySingle<Person>("select * from People where Id = @Id", new { id });
            return data;
        }

        public Person GetPersonByPersonRefId(Guid personRefId)
        {
            var data = _dataContext.db.QuerySingle<Person>("select * from People where PersonRefId = @PersonRefId", new { personRefId });
            return data;
        }

        #endregion Person

        #region Order

        public IEnumerable<Order> GetOrder()
        {
            var data = _dataContext.db.GetAll<Order>().ToList();
            return data;
        }

        public Order GetOrderById(int id)
        {
            var data = _dataContext.db.Get<Order>(id);
            return data;
        }

        #endregion Order
    }
}