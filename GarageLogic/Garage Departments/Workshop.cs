using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic.Garage_Departments
{
    internal class Workshop
    {
        public enum eVehicleStateInGarage
        {
            InRepair = 1, Repaired, Paid, All
        }

        public void SetVehicleState(VehicleInGarage i_VehicleToRepair, eVehicleStateInGarage i_NewState)
        // 3
        {
            i_VehicleToRepair.VehicleState = i_NewState;
        }


        internal void InflateWheelsToMax(VehicleInGarage i_VehicleToInflate)
        //4
        {
            i_VehicleToInflate.Vehicle.InflateWheelsToMax();
        }
    }
}
