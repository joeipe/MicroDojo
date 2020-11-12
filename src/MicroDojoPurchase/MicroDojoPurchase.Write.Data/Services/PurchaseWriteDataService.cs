using MicroDojoPurchase.Write.Data.Interfaces;
using MicroDojoPurchase.Write.Domain;
using System;
using System.Linq;

namespace MicroDojoPurchase.Write.Data.Services
{
    public class PurchaseWriteDataService : IPurchaseWriteDataService
    {
        private readonly Uow _uow;

        public PurchaseWriteDataService(Uow uow)
        {
            _uow = uow;
        }

        #region Stock

        public void AddStock(Stock data)
        {
            _uow.StocksRepo.Create(data);
            _uow.Save();
        }

        public void UpdateStock(Stock data)
        {
            _uow.StocksRepo.Update(data);
            _uow.Save();
        }

        public void DeleteStock(int id)
        {
            _uow.StocksRepo.Delete(id);
            _uow.Save();
        }

        #endregion Stock

        #region Person

        public void AddPerson(Person data)
        {
            _uow.PeopleRepo.Create(data);
            _uow.Save();
        }

        public void UpdatePerson(Person data)
        {
            var id = _uow.PeopleRepo.SearchFor
                (
                    s => s.PersonRefId == data.PersonRefId
                ).First().Id;
            data.Id = id;
            _uow.PeopleRepo.Update(data);
            _uow.Save();
        }

        public void DeletePerson(Guid personRefId)
        {
            var id = _uow.PeopleRepo.SearchFor
                (
                    s => s.PersonRefId == personRefId
                ).First().Id;
            _uow.PeopleRepo.Delete(id);
            _uow.Save();
        }

        #endregion Person

        #region Order

        public void AddOrder(Order data)
        {
            _uow.OrdersRepo.Create(data);
            _uow.Save();
        }

        public void UpdateOrder(Order data)
        {
            _uow.OrdersRepo.Update(data);
            _uow.Save();
        }

        public void DeleteOrder(int id)
        {
            _uow.OrdersRepo.Delete(id);
            _uow.Save();
        }

        #endregion Order
    }
}