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

        public List<string> GetLicensePlatesInGarage(string i_VehicleStateInGarage) // TODO parse string to Enum
        // 2
        {
            return m_Secretary.GetLicensePlatesInGarage(i_VehicleStateInGarage);
        }

        public void SetVehicleState(string i_LicensePlate, string i_NewState) //TODO enum parsing
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

        public void EnergizeVehicle(string i_LicensePlate, float i_EnergyAmount, string i_FuelType = default) // TODO enum parsing
        // 5+6
        {
            VehicleInGarage vehicleToEnergize = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
            m_EnergyFiller.EnergizeVehicle(vehicleToEnergize, i_FuelType, i_EnergyAmount);
        }

        public Dictionary<string, string> GetVehicleDetails(string i_LicensePlate)
        {
            // 7
            VehicleInGarage vehicleToGetDetails = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
            Dictionary<string, string> vehicleDetails = vehicleToGetDetails.GetDetails();
            return vehicleDetails;
        }

        public List<string> GetAllVehicleStates() // i tried to retrieve an enumerated string/ list of strings for the user to choose from. got lost along the way
        {
            string vehicleStatesAsString = string.Join(",", Enum.GetValues(typeof(eVehicleStateInGarage)));
            string[] vehicleStatesArray = vehicleStatesAsString.Split(',').ToArray();
            List<string> numberedVehicleStates = vehicleStatesArray.Select((i_State, i_Index) => $"{i_Index + 1}. {i_State}").ToList();
            return numberedVehicleStates;
        }
    }
}
