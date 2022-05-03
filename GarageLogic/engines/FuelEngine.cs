﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    "Wrong fuel type, expected type is: {0}, but recieved: {1}",
                    m_FuelType,
                    i_FuelType);
                throw new ArgumentException(exceptionMessage);
            }

            base.Energize(i_EnergyAmount, i_FuelType);
        }

        public override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            details.Add("Fuel Type", m_FuelType.ToString());
            details.Add("Current fuel amount", m_CurrentEnergyAmount.ToString());
            details.Add("Maximum fuel capacity", m_MaxEnergyAmount.ToString());
            return details;
        }
    }
}
