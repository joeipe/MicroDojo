using MicroDojoGateway.WebBff.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroDojoGateway.WebBff.Services.Interfaces
{
    public interface IWarriorService
    {
        Task<HttpResponseMessage> AddBelt(BeltVM value);

        Task<HttpResponseMessage> AddPerson(PersonVM value);

        Task<HttpResponseMessage> DeleteBelt(int id);

        Task<HttpResponseMessage> DeletePerson(int id);

        Task<List<BeltVM>> GetBelt();

        Task<BeltVM> GetBeltById(int id);

        Task<List<PersonVM>> GetPerson();

        Task<PersonVM> GetPersonById(int id);

        Task<HttpResponseMessage> UpdateBelt(BeltVM value);

        Task<HttpResponseMessage> UpdatePerson(PersonVM value);
    }
}