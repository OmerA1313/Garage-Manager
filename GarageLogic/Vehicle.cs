using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicensePlate;
        protected Engine m_Engine;
        protected float m_RemainingEnergy;
        protected List<Wheel> m_Wheels;

        public string LicensePlate { get; set; }

        public Engine Engine { get; set; }

        internal virtual void InflateWheelsByAmount(int i_AmountToInflate)
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.Inflate(i_AmountToInflate);
            }
        }

        internal virtual void InflateWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        internal Dictionary<string, Object> GetDetails()
        {
            Dictionary<string, Object> details;
        }
    }
}
