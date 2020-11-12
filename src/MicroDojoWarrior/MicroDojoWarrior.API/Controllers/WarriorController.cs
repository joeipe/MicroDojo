using MicroDojoWarrior.Application.Interfaces;
using MicroDojoWarrior.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroDojoWarrior.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarriorController : ApiController
    {
        private readonly ILogger<WarriorController> _logger;
        private readonly IWarriorAppService _warriorAppService;

        public WarriorController(ILogger<WarriorController> logger, IWarriorAppService warriorAppService)
        {
            _logger = logger;
            _warriorAppService = warriorAppService;
        }

        #region Belt

        [HttpGet]
        public ActionResult GetBelt()
        {
            return Response(_warriorAppService.GetBelt());
        }

        [HttpGet("{id}")]
        public ActionResult GetBeltById(int id)
        {
            var vm = _warriorAppService.GetBeltById(id);

            if (vm == null)
            {
                return ResponseNotFound();
            }

            return Response(vm);
        }

        [HttpPost]
        public ActionResult AddBelt([FromBody] BeltVM value)
        {
            _warriorAppService.AddBelt(value);

            return Response("", value);
        }

        [HttpPut]
        public ActionResult UpdateBelt([FromBody] BeltVM value)
        {
            _warriorAppService.UpdateBelt(value);

            return Response();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBelt(int id)
        {
            _warriorAppService.DeleteBelt(id);

            return Response();
        }

        #endregion Belt

        #region Person

        [HttpGet]
        public ActionResult GetPerson()
        {
            return Response(_warriorAppService.GetPerson());
        }

        [HttpGet("{id}")]
        public ActionResult GetPersonById(int id)
        {
            var vm = _warriorAppService.GetPersonById(id);

            if (vm == null)
            {
                return ResponseNotFound();
            }

            return Response(vm);
        }

        [HttpPost]
        public ActionResult AddPerson([FromBody] PersonVM value)
        {
            _warriorAppService.AddPerson(value);

            return Response("", value);
        }

        [HttpPut]
        public ActionResult UpdatePerson([FromBody] PersonVM value)
        {
            _warriorAppService.UpdatePerson(value);

            return Response();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            _warriorAppService.DeletePerson(id);

            return Response();
        }

        #endregion Person
    }
}