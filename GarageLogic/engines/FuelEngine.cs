using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Garage_Departments.EnergizingStation;

namespace GarageLogic
{
    internal class FuelEngine : Engine
    {
        private eFuelType m_FuelType;

        internal override void Energize(float i_EnergyAmount, eFuelType i_FuelType)
        {
            if(m_FuelType != i_FuelType)
            {
                string exceptionMessage = string.Format(
                    "Wrong fuel type, expected type is: {0}, but received: {1}",
                    m_FuelType,
                    i_FuelType.ToString());
                throw new ArgumentException(exceptionMessage);
            }

            base.Energize(i_EnergyAmount, i_FuelType);
        }

        internal eFuelType FuelType
        {
            get {return m_FuelType;}
            set {m_FuelType = value;}
        }

        internal override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            details.Add("Fuel Type", m_FuelType.ToString());
            details.Add("Current fuel amount", m_CurrentEnergyAmount.ToString());
            details.Add("Maximum fuel capacity", m_MaxEnergyAmount.ToString());
            return details;
        }

        internal override List<string> GetParameters()
        {
            List<string> parameters = new List<string>();
            parameters.Add($"Current Fuel amount, maximum value is {m_MaxEnergyAmount}");
            return parameters;
        }
    }
}
