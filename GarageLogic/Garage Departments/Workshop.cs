using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic.Garage_Departments
{
    class Workshop
    {
        public enum eVehicleStateInGarage
        {
            InRepair, Repaired, Paid, All
        }

        public void SetVehicleState(VehicleInGarage i_VehicleToRepair, eVehicleStateInGarage i_NewState)
        // 3
        {
            VehicleInGarage vehicleToUpdate = getVehicleByLicensePlate(i_VehicleToRepair);
            vehicleToUpdate.VehicleState = i_NewState;
        }

        public void InflateVehicleToMax(string i_LicensePlateToInflate)
        // 4
        {
            VehicleInGarage vehicleToInflate = getVehicleByLicensePlate(i_LicensePlateToInflate);
            vehicleToInflate.Vehicle.InflateWheelsToMax();
        }


    }
}
