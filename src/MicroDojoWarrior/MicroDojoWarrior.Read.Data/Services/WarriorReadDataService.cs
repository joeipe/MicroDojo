using Dapper;
using Dapper.Contrib.Extensions;
using MicroDojoWarrior.Read.Data.Interfaces;
using MicroDojoWarrior.Read.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MicroDojoWarrior.Read.Data.Services
{
    public class WarriorReadDataService : IWarriorReadDataService
    {
        private readonly ReadDbContext _dataContext;

        public WarriorReadDataService(ReadDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region Belt

        public IEnumerable<Belt> GetBelt()
        {
            var data = _dataContext.db.GetAll<Belt>().ToList();
            return data;
        }

        public Belt GetBeltById(int id)
        {
            var data = _dataContext.db.Get<Belt>(id);
            return data;
        }

        #endregion Belt

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

        #endregion Person
    }
}