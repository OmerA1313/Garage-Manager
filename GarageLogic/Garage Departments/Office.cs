using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Garage_Departments.Workshop;

namespace GarageLogic.Garage_Departments
{
    class Office
    {

        private Dictionary<string, VehicleInGarage> m_LicensePlateToVehicle;

        internal Office()
        {
            m_LicensePlateToVehicle = new Dictionary<string, VehicleInGarage>();
        }

        internal VehicleInGarage GetVehicleByLicensePlate(string i_LicensePlate)
        {
            VehicleInGarage vehicleToFind;
            bool vehicleExists = m_LicensePlateToVehicle.TryGetValue(i_LicensePlate, out vehicleToFind);
            if (!vehicleExists)
            {
                throw new ArgumentException(
                    $"@The License plate you entered: {i_LicensePlate} doesn't match any vehicle in the garage");
            }

            return vehicleToFind;
        }

        internal List<string> GetLicensePlatesInGarage(eVehicleStateInGarage i_VehicleStateInGarage = eVehicleStateInGarage.All) // TTODO: Solve combine
        // 2
        {
            bool retrieveAll = i_VehicleStateInGarage == eVehicleStateInGarage.All;
            List<string> LicensePlates = new List<string>();

            foreach (VehicleInGarage vehicleInGarage in m_LicensePlateToVehicle.Values)
            {
                if (retrieveAll || vehicleInGarage.VehicleState == i_VehicleStateInGarage)
                {
                    LicensePlates.Add(vehicleInGarage.Vehicle.LicensePlate);
                }
            }

            return LicensePlates;
        }

        internal void EnterNewVehicleToGarage(List<string> i_vehicleInGarageInfo, Vehicle i_newCreatedVehicle)
        {
            //TODO change everything here - use constructor instead of Properties
            VehicleInGarage vehicleInfo = new VehicleInGarage();
            vehicleInfo.OwnerName = Utils.GetAndRemoveFirstItemOfList(i_vehicleInGarageInfo);
            vehicleInfo.OwnerPhoneNumber = Utils.GetAndRemoveFirstItemOfList(i_vehicleInGarageInfo);
            string vehicleStateRepresentation = Utils.GetAndRemoveFirstItemOfList(i_vehicleInGarageInfo);
            eVehicleStateInGarage parsedVehicleState;
            Enum.TryParse<eVehicleStateInGarage>(vehicleStateRepresentation, out parsedVehicleState);
            vehicleInfo.VehicleState = parsedVehicleState;
            vehicleInfo.Vehicle = i_newCreatedVehicle;
            m_LicensePlateToVehicle.Add(i_newCreatedVehicle.LicensePlate, vehicleInfo);
        }
    }
}
