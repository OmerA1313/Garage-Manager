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

        public override List<string> GetParameters()
        {
            List<string> parameters = base.GetParameters();
            parameters.Add("Engine capacity");
            parameters.Add("License type");
            return parameters;
        }

        public override void SetParameters(List<string> i_Parameters)
        {
            base.SetParameters(i_Parameters);
            m_EngineCapacity = int.Parse(Utils.GetAndRemoveFirstItemOfList(i_Parameters));
            // TODO get and validate enum
        }
    }
}
