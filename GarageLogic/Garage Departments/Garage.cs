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

        public List<string> GetLicensePlatesInGarage(string i_VehicleStateInGarage, bool i_WithFilteration)
        {
            List<string> licensePlates;
            if(i_WithFilteration)
            {
                eVehicleStateInGarage desiredState = parseVehicleState(i_VehicleStateInGarage);
                licensePlates = m_Secretary.GetLicensePlatesInGarage(desiredState);
            }
            else
            {
                licensePlates = m_Secretary.GetAllLicensePlatesInGarage();
            }

            return licensePlates;
        }

        private eVehicleStateInGarage parseVehicleState(string i_VehicleState)
        {
            eVehicleStateInGarage desiredState;
            bool stateParse = Enum.IsDefined(typeof(eVehicleStateInGarage), int.Parse(i_VehicleState));
            if (!stateParse)
            {
                throw new FormatException("Wrong vehicle state");
            }

            Enum.TryParse(i_VehicleState, out desiredState);
            return desiredState;
        }

        public void SetVehicleState(string i_LicensePlate, string i_NewState)
        {
            eVehicleStateInGarage newState = parseVehicleState(i_NewState);
            setVehicleState(i_LicensePlate,newState);
        }

        private void setVehicleState(string i_LicensePlate, eVehicleStateInGarage i_NewState)
        {
            VehicleInGarage vehicleToRepair = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
            m_Mechanic.SetVehicleState(vehicleToRepair, i_NewState);
        }

        public void InflateVehicleToMax(string i_LicensePlateToInflate)
        {
            VehicleInGarage vehicleToInflate = m_Secretary.GetVehicleByLicensePlate(i_LicensePlateToInflate);
            m_Mechanic.InflateWheelsToMax(vehicleToInflate);
        }

        public void RefuelVehicle(string i_LicensePlate, string i_FuelAmount, string i_FuelType)
        {
            float energyAmount = float.Parse(i_FuelAmount);
            VehicleInGarage vehicleToEnergize = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
            if(!(vehicleToEnergize.Vehicle.Engine is FuelEngine))
            {
                throw new ArgumentException($"Vehicle {i_LicensePlate} is not fuel-motored");
            }

            eFuelType desiredFuelType = m_EnergyFiller.ParseFuelType(i_FuelType);
            m_EnergyFiller.EnergizeVehicle(vehicleToEnergize, energyAmount,desiredFuelType);
        }

        public void RechargeVehicle(string i_LicensePlate, string i_BatteryTime)
        {
            float batteryTime = float.Parse(i_BatteryTime);
            VehicleInGarage vehicleToEnergize = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
            if (!(vehicleToEnergize.Vehicle.Engine is ElectricEngine))
            {
                throw new ArgumentException($"Vehicle {i_LicensePlate} is not electric-motored");
            }

            m_EnergyFiller.EnergizeVehicle(vehicleToEnergize, batteryTime);
        }

        public Dictionary<string, string> GetVehicleDetails(string i_LicensePlate)
        {
            VehicleInGarage vehicleToGetDetails = m_Secretary.GetVehicleByLicensePlate(i_LicensePlate);
            Dictionary<string, string> vehicleDetails = vehicleToGetDetails.GetDetails();
            return vehicleDetails;
        }

        public void CreateAndEnterVehicleToGarage(List<string> i_ParametersForVehicleCreation, List<string> i_VehicleInGarageInfo)
        {
            Vehicle newVehicle = VehicleFactory.CreateNewVehicleFromParameters(i_ParametersForVehicleCreation);
            m_Secretary.EnterNewVehicleToGarage(i_VehicleInGarageInfo, newVehicle);
        }

        public List<string> GetVehicleStatesValuesAsList()
        {
            return Enum.GetNames(typeof(eVehicleStateInGarage)).ToList();
        }

        public List<string> GetFuelTypeAsList()
        {
            return Enum.GetNames(typeof(eFuelType)).ToList();
        }

        public List<string> GetSupportedVehicleTypesAsList()
        {
            return VehicleFactory.GetAllSupportedVehicleTypes();
        }

        public bool IsVehicleExists(string i_LicensePlate)
        {
            return m_Secretary.IsVehicleInGarage(i_LicensePlate);
        }

        public void ResetStateOfExistingVehicle(string i_LicensePlate)
        {
            setVehicleState(i_LicensePlate, eVehicleStateInGarage.InRepair);
        }
    }
}
