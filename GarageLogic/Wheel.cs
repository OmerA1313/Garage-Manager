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
            parameters.Add($"Current wheel air pressure, maximum value is {m_MaxAirPressure}");
            parameters.Add("Manufacturer name");
            return parameters;
        }

        public void SetParameters(string i_CurrentWheelAirPressure, string i_ManufacturerName)
        {
            setAirPressure(ParseAirPressure(i_CurrentWheelAirPressure));
            m_ManufacturerName = i_ManufacturerName;
        }

        private float ParseAirPressure(string i_AirPressure)
        {
            float airPressure;
            bool airPressureParsed = float.TryParse(i_AirPressure, out airPressure);
            if(!airPressureParsed)
            {
                throw new FormatException("Wrong air pressure input");
            }

            return airPressure;
        }

        private void setAirPressure(float i_NewAirPressure)
        {
            if(i_NewAirPressure > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(
                    0,
                    m_MaxAirPressure,
                    $"Air pressure out of range, maximum value is : {m_MaxAirPressure}");
            }

            m_CurrentAirPressure = i_NewAirPressure;
        }
    }
}
