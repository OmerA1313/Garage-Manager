using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic.Garage_Departments
{
    internal class Workshop
    {
        internal enum eVehicleStateInGarage
        {
            InRepair = 1, Repaired, Paid
        }

        internal void SetVehicleState(VehicleInGarage i_VehicleToRepair, eVehicleStateInGarage i_NewState)
        {
            i_VehicleToRepair.VehicleState = i_NewState;
        }

        internal void InflateWheelsToMax(VehicleInGarage i_VehicleToInflate)
        {
            i_VehicleToInflate.Vehicle.InflateWheelsToMax();
        }
    }
}
