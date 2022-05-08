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

        internal VehicleInGarage(List<string> i_VehicleInGarageInfo)
        {
            m_OwnerName = Utils.PopFirstItemOfList(i_VehicleInGarageInfo);
            m_OwnerPhoneNumber = Utils.PopFirstItemOfList(i_VehicleInGarageInfo);
        }

        internal Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }

        internal Garage_Departments.Workshop.eVehicleStateInGarage VehicleState
        {
            get {return m_VehicleState; } 
            set { m_VehicleState = value; }
        }

        internal Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = Vehicle.GetDetails();
            details.Add("Owner name", m_OwnerName);
            details.Add("Owner phone number", m_OwnerPhoneNumber);
            details.Add("State in garage", m_VehicleState.ToString());
            return details;
        }
    }
}
