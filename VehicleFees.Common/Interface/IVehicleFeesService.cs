using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFees.Model.VehicleFee;

namespace VehicleFees.Common.Interface
{
    public interface IVehicleFeesService
    {
        VehicleFeesDto VehicleFeesCalculate(VehicleFeesModel vehicleCalculator);
    }
}
