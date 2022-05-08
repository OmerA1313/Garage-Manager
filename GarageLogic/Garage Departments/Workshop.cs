﻿using System;
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

        internal void SetVehicleState(VehicleInGarage i_VehicleToRepair, eVehicleStateInGarage i_newState)
        // 3
        {
            i_VehicleToRepair.VehicleState = i_newState;
        }

        internal void InflateWheelsToMax(VehicleInGarage i_VehicleToInflate)
        //4
        {
            i_VehicleToInflate.Vehicle.InflateWheelsToMax();
        }

        private eVehicleStateInGarage parseVehicleState(string i_VehicleState)
        {
            eVehicleStateInGarage desiredVehicleState;
            bool vehicleStateParsed = Enum.TryParse(
                i_VehicleState,
                out desiredVehicleState);

            if (!vehicleStateParsed)
            {
                throw new ArgumentException("Wrong vehicle state input");
            }

            return desiredVehicleState;
        }
    }
}
