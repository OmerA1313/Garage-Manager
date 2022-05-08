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
        private static readonly int sr_MaxWheelAirPressure = 31;
        private static readonly int sr_NumberOfWheels = 2;
        private static readonly float sr_FuledEngingCapacity = 6.2F;
        private static readonly float sr_ElectricEngingCapacity = 2.5F;

        internal enum eLicenseType
        {
            A = 1, A1, B1, BB 
        }

        internal MotorCycle(bool i_IsFuelEngine)
        {
            m_Wheels = new List<Wheel>(sr_NumberOfWheels);
            base.CreateEngine(i_IsFuelEngine);
            base.CreateWheels(sr_MaxWheelAirPressure);
            if(i_IsFuelEngine)
            {
                FuelEngine engine = m_Engine as FuelEngine;
                engine.FuelType = EnergizingStation.eFuelType.Octan98;
                engine.MaxEnergyAmount = sr_FuledEngingCapacity;
            }
            else
            {
                m_Engine.MaxEnergyAmount = sr_ElectricEngingCapacity;
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

        internal override List<string> GetParameters()
        {
            List<string> parameters = base.GetParameters();
            parameters.Add("Engine capacity (cc) ");
            parameters.Add("License type:\n" + Utils.CreateEnumeratedOptions(getMotorcycleLicenseTypeAsList()));
            return parameters;
        }

        private List<string> getMotorcycleLicenseTypeAsList()
        {
            return Enum.GetNames(typeof(eLicenseType)).ToList();
        }

        internal override void SetParameters(List<string> i_Parameters)
        {
            base.SetParameters(i_Parameters);
            m_EngineCapacity = int.Parse(Utils.PopFirstItemOfList(i_Parameters));
            m_LicenseType = parseLicenseType(Utils.PopFirstItemOfList(i_Parameters));
        }
    }
}
