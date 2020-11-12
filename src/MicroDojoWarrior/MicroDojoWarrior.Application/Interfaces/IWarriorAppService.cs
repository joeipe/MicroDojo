using MicroDojoWarrior.ViewModels;
using System.Collections.Generic;

namespace MicroDojoWarrior.Application.Interfaces
{
    public interface IWarriorAppService
    {
        IList<BeltVM> GetBelt();

        BeltVM GetBeltById(int id);

        void AddBelt(BeltVM value);

        void UpdateBelt(BeltVM value);

        void DeleteBelt(int id);

        IList<PersonVM> GetPerson();

        PersonVM GetPersonById(int id);

        void AddPerson(PersonVM value);

        void UpdatePerson(PersonVM value);

        void DeletePerson(int id);
    }
}