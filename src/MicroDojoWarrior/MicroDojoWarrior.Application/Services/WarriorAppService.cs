using AutoMapper;
using MicroDojoWarrior.Application.Interfaces;
using MicroDojoWarrior.Read.Data.Interfaces;
using MicroDojoWarrior.ViewModels;
using MicroDojoWarrior.Write.Data.Commands;
using MicroDojoWarrior.Write.Data.Interfaces;
using System.Collections.Generic;

namespace MicroDojoWarrior.Application.Services
{
    public class WarriorAppService : IWarriorAppService
    {
        private readonly IMapper _mapper;
        private readonly IWarriorWriteDataService _writeData;
        private readonly IWarriorReadDataService _readData;

        public WarriorAppService(IMapper mapper, IWarriorWriteDataService writeData, IWarriorReadDataService readData)
        {
            _mapper = mapper;
            _writeData = writeData;
            _readData = readData;
        }

        #region Belt

        public IList<BeltVM> GetBelt()
        {
            var data = _readData.GetBelt();
            var vm = _mapper.Map<IList<BeltVM>>(data);
            return vm;
        }

        public BeltVM GetBeltById(int id)
        {
            var data = _readData.GetBeltById(id);
            var vm = _mapper.Map<BeltVM>(data);
            return vm;
        }

        public void AddBelt(BeltVM value)
        {
            var data = _mapper.Map<BeltAddCommand>(value);
            _writeData.AddBelt(data);
        }

        public void UpdateBelt(BeltVM value)
        {
            var data = _mapper.Map<BeltUpdateCommand>(value);
            _writeData.UpdateBelt(data);
        }

        public void DeleteBelt(int id)
        {
            var data = _mapper.Map<BeltDeleteCommand>(id);
            _writeData.DeleteBelt(data);
        }

        #endregion Belt

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
            var data = _mapper.Map<PersonAddCommand>(value);
            _writeData.AddPerson(data);
        }

        public void UpdatePerson(PersonVM value)
        {
            var data = _mapper.Map<PersonUpdateCommand>(value);
            _writeData.UpdatePerson(data);
        }

        public void DeletePerson(int id)
        {
            var data = _mapper.Map<PersonDeleteCommand>(id);
            _writeData.DeletePerson(data);
        }

        #endregion Person
    }
}