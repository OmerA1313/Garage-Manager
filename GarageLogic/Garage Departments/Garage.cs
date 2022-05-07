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

        public List<string> GetLicensePlatesInGarage(string i_VehicleStateInGarage)
        // 2
        {
            eVehicleStateInGarage desiredState;
            Enum.TryParse<eVehicleStateInGarage>(i_VehicleStateInGarage,out desiredState);
            return m_Secretary.GetLicensePlatesInGarage(desiredState);
        }

        public void SetVehicleState(string i_LicensePlate, string i_NewState)
        // 3
        {
            eVehicleStateInGarage newDesiredState;
            Enum.TryParse<eVehicleStateInGarage>(i_NewState, out newDesiredState);
            VehicleInGarage vehicleToRepair = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
            m_Mechanic.SetVehicleState(vehicleToRepair, newDesiredState);
        }

        public void InflateVehicleToMax(string i_LicensePlateToInflate)
        // 4
        {
            VehicleInGarage vehicleToInflate = m_Secretary.GetVehicleByLicensePlate(i_LicensePlateToInflate);
            m_Mechanic.InflateWheelsToMax(vehicleToInflate);
        }

        public void EnergizeVehicle(string i_LicensePlate, float i_EnergyAmount, string i_FuelType = default)
        // 5+6
        {
            eFuelType desiredFuelType;
            Enum.TryParse<eFuelType>(i_FuelType, out desiredFuelType);
            VehicleInGarage vehicleToEnergize = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
            m_EnergyFiller.EnergizeVehicle(vehicleToEnergize, desiredFuelType, i_EnergyAmount);
        }

        public Dictionary<string, string> GetVehicleDetails(string i_LicensePlate)
        {
            // 7
            VehicleInGarage vehicleToGetDetails = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
            Dictionary<string, string> vehicleDetails = vehicleToGetDetails.GetDetails();
            return vehicleDetails;
        }

        public List<string> GetVehicleStatusValuesAsList()
        {
            return Enum.GetValues(typeof(eVehicleStateInGarage)).Cast<string>().ToList();
        }
    }
}
