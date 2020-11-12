using MicroDojoWarrior.Write.Domain;

namespace MicroDojoWarrior.Write.Data
{
    public class Uow
    {
        private WriteDbContext _context;

        public Uow(WriteDbContext context)
        {
            _context = context;
        }

        public GenericRepository<Belt> BeltsRepo { get { return new GenericRepository<Belt>(_context); } }
        public GenericRepository<Person> PeopleRepo { get { return new GenericRepository<Person>(_context); } }

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