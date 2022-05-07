using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class VehicleInGarage
    {
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private Garage_Departments.Workshop.eVehicleStateInGarage m_VehicleState = Garage_Departments.Workshop.eVehicleStateInGarage.InRepair;

        public Vehicle Vehicle { get; set; }

        public Garage_Departments.Workshop.eVehicleStateInGarage VehicleState { get; set; }
        public string OwnerName { get; internal set; }
        public string OwnerPhoneNumber { get; internal set; }

        public Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = Vehicle.GetDetails();
            details.Add("Owner name", m_OwnerName);
            details.Add("Owner phone number", m_OwnerPhoneNumber);
            details.Add("State in garage", m_VehicleState.ToString());
            return details;
        }
    }
}
