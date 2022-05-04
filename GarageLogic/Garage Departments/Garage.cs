using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Garage_Departments.EnergizingStation;
using static GarageLogic.Garage_Departments.Workshop;

namespace GarageLogic
{
    public class Garage
    {
        private Garage_Departments.Office m_Secretary;
        private Garage_Departments.Workshop m_Mechanic;
        private Garage_Departments.EnergizingStation m_EnergyFiller;

        public List<string> GetLicensePlatesInGarage(eVehicleStateInGarage i_VehicleStateInGarage = eVehicleStateInGarage.All)
        // 2
        {
            return m_Secretary.GetLicensePlatesInGarage(i_VehicleStateInGarage);
        }

        public void SetVehicleState(string i_LicensePlate, eVehicleStateInGarage i_NewState)
        // 3
        {
            VehicleInGarage vehicleToRepair = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
            m_Mechanic.SetVehicleState(vehicleToRepair, i_NewState);
        }

        public void InflateVehicleToMax(string i_LicensePlateToInflate)
        // 4
        {
            VehicleInGarage vehicleToInflate = m_Secretary.GetVehicleByLicensePlate(i_LicensePlateToInflate);
            m_Mechanic.InflateWheelsToMax(vehicleToInflate);
        }

        public void EnergizeVehicle(string i_LicensePlate, eFuelType i_FuelType, float i_EnergyAmount)
        // 5+6
        {
            VehicleInGarage vehicleToEnergize = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
            m_EnergyFiller.EnergizeVehicle(vehicleToEnergize, i_FuelType, i_EnergyAmount);
        }

    }
}
