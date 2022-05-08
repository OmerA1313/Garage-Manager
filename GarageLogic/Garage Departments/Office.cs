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

        internal bool IsVehicleInGarage(string i_LicensePlate)
        {
            return m_LicensePlateToVehicle.ContainsKey(i_LicensePlate);
        }

        internal void EnterNewVehicleToGarage(List<string> i_VehicleInGarageInfo, Vehicle i_NewCreatedVehicle)
        {
            string newVehicleLicensePlate = i_NewCreatedVehicle.LicensePlate;
            if(IsVehicleInGarage(newVehicleLicensePlate))
            {
                throw new ArgumentException($"Vehicle with license plate: {newVehicleLicensePlate} already exists in garage");
            }

            VehicleInGarage newVehicleInGarage = new VehicleInGarage(i_VehicleInGarageInfo);
            newVehicleInGarage.VehicleState = eVehicleStateInGarage.InRepair;
            newVehicleInGarage.Vehicle = i_NewCreatedVehicle;
            m_LicensePlateToVehicle.Add(i_NewCreatedVehicle.LicensePlate, newVehicleInGarage);
        }
    }
}
