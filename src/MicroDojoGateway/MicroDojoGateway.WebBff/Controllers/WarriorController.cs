using MicroDojoGateway.WebBff.Services.Interfaces;
using MicroDojoGateway.WebBff.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MicroDojoGateway.WebBff.Controllers
{
    [Route("api/bffweb/[controller]/[action]")]
    [ApiController]
    public class WarriorController : ControllerBase
    {
        private readonly ILogger<WarriorController> _logger;
        private readonly IWarriorService _warriorService;

        public WarriorController(ILogger<WarriorController> logger, IWarriorService warriorService)
        {
            _logger = logger;
            _warriorService = warriorService;
        }

        #region Belt

        [HttpGet]
        public async Task<ActionResult> GetBelt()
        {
            var result = await _warriorService.GetBelt();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBeltById(int id)
        {
            var result = await _warriorService.GetBeltById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddBelt([FromBody] BeltVM value)
        {
            var response = await _warriorService.AddBelt(value);
            return Created("", value);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBelt([FromBody] BeltVM value)
        {
            var response = await _warriorService.UpdateBelt(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBelt(int id)
        {
            var response = await _warriorService.DeleteBelt(id);
            return Ok();
        }

        #endregion Belt

        #region Person

        [HttpGet]
        public async Task<ActionResult> GetPerson()
        {
            var result = await _warriorService.GetPerson();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPersonById(int id)
        {
            var result = await _warriorService.GetPersonById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddPerson([FromBody] PersonVM value)
        {
            var response = await _warriorService.AddPerson(value);
            return Created("", value);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePerson([FromBody] PersonVM value)
        {
            var response = await _warriorService.UpdatePerson(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            var response = await _warriorService.DeletePerson(id);
            return Ok();
        }

        #endregion Person
    }
}