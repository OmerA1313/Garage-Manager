using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class MotorCycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        internal enum eLicenseType
        {
            A, A1, B1, BB 
        }

        internal override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = base.GetDetails();
            details.Add("License type", m_LicenseType.ToString());
            details.Add("Engine capacity", m_EngineCapacity.ToString());
            return details;
        }
    }
}
