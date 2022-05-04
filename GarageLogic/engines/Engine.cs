using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal abstract class Engine
    {
        protected float m_CurrentEnergyAmount;
        protected float m_MaxEnergyAmount;

        internal virtual void Energize(float i_EnergyAmount, eFuelType i_FuelType = default) // TODO combina - maybe use params?
        {
            float newEnergyAmount = i_EnergyAmount + m_CurrentEnergyAmount;
            if(newEnergyAmount > m_MaxEnergyAmount)
            {
                throw new ValueOutOfRangeException(0, m_MaxEnergyAmount, "Energy amount out of range");
            }

            m_CurrentEnergyAmount = newEnergyAmount;
        }

        public abstract Dictionary<string, string> GetDetails();

        public abstract List<string> GetParameters();
    }
}
