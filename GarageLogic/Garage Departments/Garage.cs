using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic.Garage_Departments;
using static GarageLogic.Garage_Departments.EnergizingStation;
using static GarageLogic.Garage_Departments.Workshop;

namespace GarageLogic
{
    public class Garage
    {
        private Garage_Departments.Office m_Secretary;
        private Garage_Departments.Workshop m_Mechanic;
        private Garage_Departments.EnergizingStation m_EnergyFiller;

        public Garage()
        {
            m_EnergyFiller = new EnergizingStation();
            m_Secretary = new Office();
            m_Mechanic = new Workshop();
        }

        public List<string> GetLicensePlatesInGarage(string i_VehicleStateInGarage)
        // 2
        {
            eVehicleStateInGarage desiredState;
            Enum.TryParse<eVehicleStateInGarage>(i_VehicleStateInGarage, out desiredState);
            //TODO check parsing and exception
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

        public void EnergizeVehicle(string i_LicensePlate, string i_EnergyAmount, string i_FuelType = default)
        // 5+6
        {
            float energyAmount = float.Parse(i_EnergyAmount);
            eFuelType desiredFuelType;
            bool enumConversionSuccses = Enum.TryParse<eFuelType>(i_FuelType, out desiredFuelType);
            if (enumConversionSuccses) // TODO: AM NOT SURE HOW TO MODULE THIS
            {
                VehicleInGarage vehicleToEnergize = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
                m_EnergyFiller.EnergizeVehicle(vehicleToEnergize, desiredFuelType, energyAmount);
            }
            else
            {
                throw new ArgumentException("Wrong fuel type input, correct fuel type is");
            }
        }

        public Dictionary<string, string> GetVehicleDetails(string i_LicensePlate)
        {
            // 7
            VehicleInGarage vehicleToGetDetails = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
            Dictionary<string, string> vehicleDetails = vehicleToGetDetails.GetDetails();
            return vehicleDetails;
        }

        public void CreateAndEnterVehicleToGarage(List<string> i_userInputForParams, List<string> i_vehicleInGarageInfo)
        {
            Vehicle newVehicle = VehicleFactory.CreateNewVehicleFromParameters(i_userInputForParams);
            m_Secretary.EnterNewVehicleToGarage(i_vehicleInGarageInfo, newVehicle);
        }

        public List<string> GetVehicleStatesValuesAsList()
        {
            return Enum.GetNames(typeof(eVehicleStateInGarage)).ToList();
        }

        public List<string> GetFuelTypeAsList()
        {
            return Enum.GetValues(typeof(eFuelType)).Cast<string>().ToList();
        }

        public List<string> GetEnergyTypeAsList()
        {
            return Enum.GetNames(typeof(eEnergyType)).Cast<string>().ToList();
        }

        public List<string> GetSupportedVehicleTypesAsList()
        {
            return VehicleFactory.GetAllSupportedVehicleTypes();
        }

    }
}
