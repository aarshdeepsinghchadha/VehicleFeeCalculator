using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFees.Common.Interface;
using VehicleFees.Model.VehicleFee;

namespace VehicleFees.Repository
{
    public class VehicleFeesService : IVehicleFeesService
    {
        public VehicleFeesDto VehicleFeesCalculate(VehicleFeesModel vehicleFees)
        {
            decimal basicUserFee = CalculateBasicUserFee(vehicleFees);
            decimal sellerSpecialFee = CalculateSellerSpecialFee(vehicleFees);
            decimal associationFee = CalculateAssociationFee(vehicleFees.BasePrice);
            decimal storageFee = 100;
            decimal total = vehicleFees.BasePrice + basicUserFee + sellerSpecialFee + associationFee + storageFee;
            return new VehicleFeesDto
            {
                BasePrice = vehicleFees.BasePrice,
                VehicleType = vehicleFees.VehicleType,
                BasicUserFee = basicUserFee,
                SellerSpecialFee = sellerSpecialFee,
                AssociationFee = associationFee,
                StorageFee = storageFee,
                Total = total
            };
        }

        private decimal CalculateBasicUserFee(VehicleFeesModel vehicleFees)
        {
            decimal basicUserFee = vehicleFees.BasePrice * 0.1m;

            decimal minFee = vehicleFees.VehicleType.ToLower() == "common" ? 10m : 25m;
            decimal maxFee = vehicleFees.VehicleType.ToLower() == "common" ? 50m : 200m;

            return Math.Clamp(basicUserFee, minFee, maxFee);
        }

        private decimal CalculateSellerSpecialFee(VehicleFeesModel vehicleFees)
        {
            return vehicleFees.BasePrice * (vehicleFees.VehicleType.ToLower() == "common" ? 0.02m : 0.04m);
        }

        private decimal CalculateAssociationFee(decimal basePrice)
        {
            return basePrice <= 500 ? 5 :
                   basePrice <= 1000 ? 10 :
                   basePrice <= 3000 ? 15 : 20;
        }
    }
}
