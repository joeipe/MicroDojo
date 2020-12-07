using MicroDojoGateway.WebBff.Extensions;
using MicroDojoGateway.WebBff.Services.Interfaces;
using MicroDojoGateway.WebBff.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroDojoGateway.WebBff.Services
{
    public class WarriorService : IWarriorService
    {
        private readonly HttpClient _client;
        public readonly string _baseUrl;

        public WarriorService(HttpClient client)
        {
            _client = client;
            _baseUrl = "api/Warrior";
        }

        #region Belt

        public async Task<List<BeltVM>> GetBelt()
        {
            var url = $"{_baseUrl}/GetBelt";
            var response = await _client.GetAsync(url);
            return await response.ReadContentAs<List<BeltVM>>();
        }

        public async Task<BeltVM> GetBeltById(int id)
        {
            var url = $"{_baseUrl}/GetBeltById/{id}";
            var response = await _client.GetAsync(url);
            return await response.ReadContentAs<BeltVM>();
        }

        public async Task<HttpResponseMessage> AddBelt(BeltVM value)
        {
            var url = $"{_baseUrl}/AddBelt";
            return await _client.PostAsJson(url, value);
        }

        public async Task<HttpResponseMessage> UpdateBelt(BeltVM value)
        {
            var url = $"{_baseUrl}/UpdateBelt";
            return await _client.PutAsJson(url, value);
        }

        public async Task<HttpResponseMessage> DeleteBelt(int id)
        {
            var url = $"{_baseUrl}/DeleteBelt/{id}";
            return await _client.DeleteAsync(url);
        }

        #endregion Belt

        #region Person

        public async Task<List<PersonVM>> GetPerson()
        {
            var url = $"{_baseUrl}/GetPerson";
            var response = await _client.GetAsync(url);
            return await response.ReadContentAs<List<PersonVM>>();
        }

        public async Task<PersonVM> GetPersonById(int id)
        {
            var url = $"{_baseUrl}/GetPersonById/{id}";
            var response = await _client.GetAsync(url);
            return await response.ReadContentAs<PersonVM>();
        }

        public async Task<HttpResponseMessage> AddPerson(PersonVM value)
        {
            var url = $"{_baseUrl}/AddPerson";
            return await _client.PostAsJson(url, value);
        }

        public async Task<HttpResponseMessage> UpdatePerson(PersonVM value)
        {
            var url = $"{_baseUrl}/UpdatePerson";
            return await _client.PutAsJson(url, value);
        }

        public async Task<HttpResponseMessage> DeletePerson(int id)
        {
            var url = $"{_baseUrl}/DeletePerson/{id}";
            return await _client.DeleteAsync(url);
        }

        #endregion Person
    }
}