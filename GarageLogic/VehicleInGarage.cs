using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class VehicleInGarage
    {
        private Vehicle m_vehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private Garage.eVehicleStateInGarage m_VehicleState = Garage.eVehicleStateInGarage.InRepair;

        public Vehicle Vehicle { get; set; }

        public Garage.eVehicleStateInGarage VehicleState { get; set; }
    }
}
