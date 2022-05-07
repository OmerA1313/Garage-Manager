using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic.Garage_Departments;

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

        internal MotorCycle(bool i_IsFuelEngine)
        {
            m_Wheels = new List<Wheel>(2);
            base.CreateEngine(i_IsFuelEngine);
            base.SetWheels(31);
            if(i_IsFuelEngine)
            {
                FuelEngine engine = m_Engine as FuelEngine;
                engine.FuelType = EnergizingStation.eFuelType.Octan98;
                engine.Capacity = 6.2F;
            }
            else
            {
                m_Engine.Capacity = 2.5F;
            }
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
            //TODO get all license types
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
