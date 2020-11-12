using MicroDojoPurchase.Write.Domain;
using System;

namespace MicroDojoPurchase.Write.Data.Interfaces
{
    public interface IPurchaseWriteDataService
    {
        void AddStock(Stock data);

        void UpdateStock(Stock data);

        void DeleteStock(int id);

        void AddPerson(Person data);

        void UpdatePerson(Person data);

        void DeletePerson(Guid personRefId);

        void AddOrder(Order data);

        void UpdateOrder(Order data);

        void DeleteOrder(int id);
    }
}