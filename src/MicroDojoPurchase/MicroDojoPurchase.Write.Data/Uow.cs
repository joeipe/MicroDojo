using MicroDojoPurchase.Write.Domain;
using System;

namespace MicroDojoPurchase.Write.Data
{
    public class Uow : IDisposable
    {
        private MicroDojoPurchaseWriteContext _context;

        public Uow(MicroDojoPurchaseWriteContext context)
        {
            _context = context;
        }

        public GenericRepository<Stock> StocksRepo { get { return new GenericRepository<Stock>(_context); } }
        public GenericRepository<Person> PeopleRepo { get { return new GenericRepository<Person>(_context); } }
        public GenericRepository<Order> OrdersRepo { get { return new GenericRepository<Order>(_context); } }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}