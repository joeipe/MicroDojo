using MicroDojoWarrior.Read.Data.Interfaces;
using MicroDojoWarrior.Read.Data.Queries;
using MicroDojoWarrior.Read.Domain;
using SharedKernel.Services;
using System.Collections.Generic;

namespace MicroDojoWarrior.Read.Data.Services
{
    public class WarriorReadDataService : IWarriorReadDataService
    {
        private readonly ReadDbContext _dataContext;
        private readonly Messages _messages;

        public WarriorReadDataService(Messages messages)
        {
            _messages = messages;
        }

        #region Belt

        public IEnumerable<Belt> GetBelt(GetBeltQuery query)
        {
            var data = _messages.Dispatch(query);
            return data;
        }

        public Belt GetBeltById(GetBeltByIdQuery query)
        {
            var data = _messages.Dispatch(query);
            return data;
        }

        #endregion Belt

        #region Person

        public IEnumerable<Person> GetPerson(GetPersonQuery query)
        {
            var data = _messages.Dispatch(query);
            return data;
        }

        public Person GetPersonById(GetPersonByIdQuery query)
        {
            var data = _messages.Dispatch(query);
            return data;
        }

        #endregion Person
    }
}