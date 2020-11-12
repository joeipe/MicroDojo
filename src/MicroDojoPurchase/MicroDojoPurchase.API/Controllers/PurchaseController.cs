using MicroDojoPurchase.Application.Interfaces;
using MicroDojoPurchase.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroDojoPurchase.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PurchaseController : ApiController
    {
        private readonly ILogger<PurchaseController> _logger;
        private readonly IPurchaseAppService _purchaseAppService;

        public PurchaseController(ILogger<PurchaseController> logger, IPurchaseAppService purchaseAppService)
        {
            _logger = logger;
            _purchaseAppService = purchaseAppService;
        }

        #region Stock

        [HttpGet]
        public ActionResult GetStock()
        {
            return Response(_purchaseAppService.GetStock());
        }

        [HttpGet("{id}")]
        public ActionResult GetStockById(int id)
        {
            var vm = _purchaseAppService.GetStockById(id);

            if (vm == null)
            {
                return ResponseNotFound();
            }

            return Response(vm);
        }

        [HttpPost]
        public ActionResult AddStock([FromBody] StockVM value)
        {
            _purchaseAppService.AddStock(value);

            return Response("", value);
        }

        [HttpPut]
        public ActionResult UpdateStock([FromBody] StockVM value)
        {
            _purchaseAppService.UpdateStock(value);

            return Response();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStock(int id)
        {
            _purchaseAppService.DeleteStock(id);

            return Response();
        }

        #endregion Stock

        #region Person

        [HttpGet]
        public ActionResult GetPerson()
        {
            return Response(_purchaseAppService.GetPerson());
        }

        [HttpGet("{id}")]
        public ActionResult GetPersonById(int id)
        {
            var vm = _purchaseAppService.GetPersonById(id);

            if (vm == null)
            {
                return ResponseNotFound();
            }

            return Response(vm);
        }
        /*
        [HttpPost]
        public ActionResult AddPerson([FromBody] PersonVM value)
        {
            _purchaseAppService.AddPerson(value);

            return Response("", value);
        }

        [HttpPut]
        public ActionResult UpdatePerson([FromBody] PersonVM value)
        {
            _purchaseAppService.UpdatePerson(value);

            return Response();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            _purchaseAppService.DeletePerson(id);

            return Response();
        }
        */

        #endregion Person

        #region Order

        [HttpGet]
        public ActionResult GetOrder()
        {
            return Response(_purchaseAppService.GetOrder());
        }

        [HttpGet("{id}")]
        public ActionResult GetOrderById(int id)
        {
            var vm = _purchaseAppService.GetOrderById(id);

            if (vm == null)
            {
                return ResponseNotFound();
            }

            return Response(vm);
        }

        [HttpPost]
        public ActionResult AddOrder([FromBody] OrderVM value)
        {
            _purchaseAppService.AddOrder(value);

            return Response("", value);
        }

        [HttpPut]
        public ActionResult UpdateOrder([FromBody] OrderVM value)
        {
            _purchaseAppService.UpdateOrder(value);

            return Response();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            _purchaseAppService.DeleteOrder(id);

            return Response();
        }

        #endregion Order
    }
}