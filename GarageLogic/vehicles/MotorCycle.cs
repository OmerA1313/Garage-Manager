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
            A = 1, A1, B1, BB 
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
                engine.MaxEnergyAmount = 6.2F;
            }
            else
            {
                m_Engine.MaxEnergyAmount = 2.5F;
            }
        }

        private eLicenseType parseLicenseType(string i_LicenseType)
        {
            eLicenseType desiredLicenseType;
            bool licenseTypeParsed = Enum.TryParse(i_LicenseType, out desiredLicenseType);
            if(!licenseTypeParsed)
            {
                throw new FormatException("Wrong license type input");
            }

            return desiredLicenseType;
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
            parameters.Add("Engine capacity (cc)");
            parameters.Add("License type");
            //TODO get all license types
            return parameters;
        }

        public override void SetParameters(List<string> i_Parameters)
        {
            base.SetParameters(i_Parameters);
            m_EngineCapacity = int.Parse(Utils.PopFirstItemOfList(i_Parameters));
            m_LicenseType = parseLicenseType(Utils.PopFirstItemOfList(i_Parameters));
        }
    }
}
