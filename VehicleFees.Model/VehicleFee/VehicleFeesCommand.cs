﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFees.Model.VehicleFee
{
    public class VehicleFeesCommand : IRequest<VehicleFeesDto>
    {
        public decimal BasePrice { get; set; }
        public string? VehicleType { get; set; }
    }
}
