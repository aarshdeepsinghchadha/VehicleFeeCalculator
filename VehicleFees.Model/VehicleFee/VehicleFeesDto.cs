using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFees.Model.VehicleFee
{
    public class VehicleFeesDto
    {
        public decimal BasePrice { get; set; }
        public string VehicleType { get; set; }
        public decimal BasicUserFee { get; set; }
        public decimal SellerSpecialFee { get; set; }
        public decimal AssociationFee { get; set; }
        public decimal StorageFee { get; set; }
        public decimal Total { get; set; }
    }
}
