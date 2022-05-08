using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Wheel
    {
        private float m_MaxAirPressure;
        private float m_CurrentAirPressure;
        private string m_ManufacturerName;

        public Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

        internal float MaxAirPressure
        {
            get { return m_MaxAirPressure;}
            set {m_MaxAirPressure = value;}
        }

        public void InflateToMax()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }

        public Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            details.Add("Wheel manufacturer name", m_ManufacturerName);
            details.Add("current air pressure", m_CurrentAirPressure.ToString());
            return details;
        }

        public List<string> GetParameters()
        {
            List<string> parameters = new List<string>();
            parameters.Add("Current wheel air pressure");
            parameters.Add("Manufacturer name");
            return parameters;
        }

        public void SetParameters(string i_CurrentWheelAirPressure, string i_ManufacturerName)
        {
            m_CurrentAirPressure = float.Parse(i_CurrentWheelAirPressure);
            m_ManufacturerName = i_ManufacturerName;
        }
    }
}
