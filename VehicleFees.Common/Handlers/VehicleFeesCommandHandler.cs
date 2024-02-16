using MediatR;
using VehicleFees.Common.Interface;
using VehicleFees.Model.VehicleFee;

namespace VehicleFees.Common.Handlers
{
    public class VehicleFeesCommandHandler : IRequestHandler<VehicleFeesCommand, VehicleFeesDto>
    {
        private readonly IVehicleFeesService vehicleFeesService;
        public VehicleFeesCommandHandler(IVehicleFeesService _vehicleFeesService)
        {
            this.vehicleFeesService = _vehicleFeesService;
        }

        public Task<VehicleFeesDto> Handle(VehicleFeesCommand request, CancellationToken cancellationToken)
        {
            var vehicle = new VehicleFeesModel { BasePrice = request.BasePrice, VehicleType = request.VehicleType };
            var result = this.vehicleFeesService.VehicleFeesCalculate(vehicle);
            return Task.FromResult(result);
        }
    }
}
