using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Garage_Departments.EnergizingStation;

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

        internal float Capacity
        {
            get {return m_MaxEnergyAmount;}
            set {m_MaxEnergyAmount = value;}
        }

        public abstract Dictionary<string, string> GetDetails();

        public abstract List<string> GetParameters();

        public virtual void SetParameters(List<string> i_Parameters)
        {
            //TODO extract fuel overload validation to seperate method and use here
            m_CurrentEnergyAmount = float.Parse(Utils.GetAndRemoveFirstItemOfList(i_Parameters));
        }
    }
}
