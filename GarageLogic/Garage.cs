using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Garage
    {
        //private readonly string m_GetAllLicensePlates = "All";
        private List<VehicleInGarage> m_VehiclesInGarage;

        public enum eVehicleStateInGarage
        {
            InRepair, Repaired, Paid, All
        }

        internal void addVehicle(VehicleInGarage i_VehicleToAdd)
        {
            m_VehiclesInGarage.Add(i_VehicleToAdd);
        }

        private VehicleInGarage getVehicleByLicensePlate(string i_LicensePlate)
        {
            VehicleInGarage vehicleToFind = m_VehiclesInGarage.Find(vehicle => vehicle.Vehicle.LicensePlate == i_LicensePlate);
            if(vehicleToFind == null)
            {
                throw new VehicleNotFoundException(i_LicensePlate);
            }

            return vehicleToFind;
        }

        public List<string> getLicensePlatesInGarage(eVehicleStateInGarage i_VehicleStateInGarage = eVehicleStateInGarage.All) 
            // 2
        {
            bool retrieveAll = i_VehicleStateInGarage == eVehicleStateInGarage.All;
            List<string> LicensePlates = new List<string>();

            foreach(VehicleInGarage vehicleInGarage in m_VehiclesInGarage)
            {
                if(retrieveAll || vehicleInGarage.VehicleState == i_VehicleStateInGarage)
                {
                    LicensePlates.Add(vehicleInGarage.Vehicle.LicensePlate);
                }
            }

            return LicensePlates;
        }

        public void SetVehicleState(string i_LicensePlate, eVehicleStateInGarage i_NewState) 
            // 3
        {
            VehicleInGarage vehicleToUpdate = getVehicleByLicensePlate(i_LicensePlate);
            vehicleToUpdate.VehicleState = i_NewState;
        }

        public void InflateVehicleToMax(string i_LicensePlateToInflate)
            //4
        {
            VehicleInGarage vehicleToInflate = getVehicleByLicensePlate(i_LicensePlateToInflate);
            vehicleToInflate.Vehicle.InflateWheelsToMax();
        }

        public void EnergizeVehicle(string i_LicensePlate, FuelEngine.eFuelType i_FuelType, float i_EnergyAmount) 
            // 5+6
        {
            VehicleInGarage vehicleToEnergize = getVehicleByLicensePlate(i_LicensePlate);
            vehicleToEnergize.Vehicle.Engine.Energize(i_EnergyAmount,i_FuelType);
        }
    }
}
