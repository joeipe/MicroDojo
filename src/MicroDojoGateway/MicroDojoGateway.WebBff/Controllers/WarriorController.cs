using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MicroDojoGateway.WebBff.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroDojoGateway.WebBff.Controllers
{
    [Route("api/bffweb/[controller]/[action]")]
    [ApiController]
    public class WarriorController : ApiController
    {
        private readonly ILogger<WarriorController> _logger;
        public readonly string _baseUrl;

        public WarriorController(ILogger<WarriorController> logger, IHttpClientFactory httpClientFactory)
            :base(httpClientFactory.CreateClient("Warrior_APIClient"))
        {
            _logger = logger;
            _baseUrl = "api/Warrior";
        }

        #region Belt

        [HttpGet]
        public async Task<ActionResult> GetBelt()
        {
            var url = $"{_baseUrl}/GetBelt";
            return await PerformRequest<List<BeltVM>>(url);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBeltById(int id)
        {
            var url = $"{_baseUrl}/GetBeltById/{id}";
            return await PerformRequest<BeltVM>(url);
        }

        [HttpPost]
        public async Task<ActionResult> AddBelt([FromBody] BeltVM value)
        {
            var url = $"{_baseUrl}/AddBelt";
            return await PerformRequest<bool>(url, value);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBelt([FromBody] BeltVM value)
        {
            var url = $"{_baseUrl}/UpdateBelt";
            return await PerformRequest<bool>(url, value);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBelt(int id)
        {
            var url = $"{_baseUrl}/DeleteBelt/{id}";
            return await PerformRequest<bool>(url);
        }

        #endregion Belt

        #region Person

        [HttpGet]
        public async Task<ActionResult> GetPerson()
        {
            var url = $"{_baseUrl}/GetPerson";
            return await PerformRequest<List<PersonVM>>(url);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPersonById(int id)
        {
            var url = $"{_baseUrl}/GetPersonById/{id}";
            return await PerformRequest<PersonVM>(url);
        }

        [HttpPost]
        public async Task<ActionResult> AddPerson([FromBody] PersonVM value)
        {
            var url = $"{_baseUrl}/AddPerson";
            return await PerformRequest<bool>(url, value);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePerson([FromBody] PersonVM value)
        {
            var url = $"{_baseUrl}/UpdatePerson";
            return await PerformRequest<bool>(url, value);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            var url = $"{_baseUrl}/DeletePerson/{id}";
            return await PerformRequest<bool>(url);
        }

        #endregion Person
    }
}
