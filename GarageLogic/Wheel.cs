using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Wheel
    {
        private readonly float r_MaxAirPressure; // TODO check for the correct way to name a readonly field
        private float m_CurrentAirPressure;
        private string m_ManufacturerName;

        public Wheel(string i_WheelManufacturerName, float i_WheelCurrentAirPressure, int i_MaxAirPressure)
        {
            m_ManufacturerName = i_WheelManufacturerName;
            m_CurrentAirPressure = i_WheelCurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        //internal void Inflate(int i_AmountToInflate)
        //{
        //    float newAirPressure = i_AmountToInflate + m_CurrentAirPressure;
        //    if(newAirPressure > r_MaxAirPressure)
        //    {
        //        throw new ValueOutOfRangeException(0, r_MaxAirPressure);
        //    }

        //    m_CurrentAirPressure = newAirPressure;
        //}

        public void InflateToMax()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }

        public Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            details.Add("Wheel manufacturer name",m_ManufacturerName);
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
    }
}
