using AutoMapper;
using MicroDojoPurchase.Application.Interfaces;
using MicroDojoPurchase.Read.Data.Interfaces;
using MicroDojoPurchase.ViewModels;
using MicroDojoPurchase.Write.Data.Interfaces;
using MicroDojoPurchase.Write.Domain;
using System;
using System.Collections.Generic;

namespace MicroDojoPurchase.Application.Services
{
    public class PurchaseAppService : IPurchaseAppService
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseWriteDataService _writeData;
        private readonly IPurchaseReadDataService _readData;

        public PurchaseAppService(IMapper mapper, IPurchaseWriteDataService writeData, IPurchaseReadDataService readData)
        {
            _mapper = mapper;
            _writeData = writeData;
            _readData = readData;
        }

        #region Stock

        public IList<StockVM> GetStock()
        {
            var data = _readData.GetStock();
            var vm = _mapper.Map<IList<StockVM>>(data);
            return vm;
        }

        public StockVM GetStockById(int id)
        {
            var data = _readData.GetStockById(id);
            var vm = _mapper.Map<StockVM>(data);
            return vm;
        }

        public void AddStock(StockVM value)
        {
            var data = _mapper.Map<Stock>(value);
            _writeData.AddStock(data);
        }

        public void UpdateStock(StockVM value)
        {
            var data = _mapper.Map<Stock>(value);
            _writeData.UpdateStock(data);
        }

        public void DeleteStock(int id)
        {
            _writeData.DeleteStock(id);
        }

        #endregion Stock

        #region Person

        public IList<PersonVM> GetPerson()
        {
            var data = _readData.GetPerson();
            var vm = _mapper.Map<IList<PersonVM>>(data);
            return vm;
        }

        public PersonVM GetPersonById(int id)
        {
            var data = _readData.GetPersonById(id);
            var vm = _mapper.Map<PersonVM>(data);
            return vm;
        }

        public void AddPerson(PersonVM value)
        {
            var data = _mapper.Map<Person>(value);
            _writeData.AddPerson(data);
        }

        public void UpdatePerson(PersonVM value)
        {
            var data = _mapper.Map<Person>(value);
            _writeData.UpdatePerson(data);
        }

        public void DeletePerson(Guid personRefId)
        {
            _writeData.DeletePerson(personRefId);
        }

        #endregion Person

        #region Order

        public IList<OrderVM> GetOrder()
        {
            var data = _readData.GetOrder();
            var vm = _mapper.Map<IList<OrderVM>>(data);
            return vm;
        }

        public OrderVM GetOrderById(int id)
        {
            var data = _readData.GetOrderById(id);
            var vm = _mapper.Map<OrderVM>(data);
            return vm;
        }

        public void AddOrder(OrderVM value)
        {
            var data = _mapper.Map<Order>(value);
            _writeData.AddOrder(data);
        }

        public void UpdateOrder(OrderVM value)
        {
            var data = _mapper.Map<Order>(value);
            _writeData.UpdateOrder(data);
        }

        public void DeleteOrder(int id)
        {
            _writeData.DeleteOrder(id);
        }

        #endregion Order
    }
}