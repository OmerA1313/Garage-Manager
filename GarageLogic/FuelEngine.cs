using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class FuelEngine : Engine
    {
        private eFuelType m_FuelType;

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

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

            base.Energize(i_EnergyAmount,i_FuelType);
        }
    }
}
