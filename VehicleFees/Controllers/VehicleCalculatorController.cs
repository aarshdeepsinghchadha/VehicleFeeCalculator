using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleFees.Model.VehicleFee;

namespace VehicleFees.Controllers
{
    public class VehicleCalculatorController : Controller
    {
        private readonly IMediator mediator;
        public VehicleCalculatorController(IMediator _mediator)
        {
            this.mediator = _mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(decimal basePrice, string vehicleType)
        {
            var result = await this.mediator.Send(new VehicleFeesCommand
            {
                BasePrice = basePrice,
                VehicleType = vehicleType
            });
            return View(result);
        }
    }
}
