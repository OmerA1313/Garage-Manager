using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Car : Vehicle
    {
        private eCarColor m_Color;
        private int m_NumberOfDoors;

        internal enum eCarColor
        {
            Red, White, Green, Blue
        }

        internal Car(string i_LicensePlate,float i_WheelCurrentAirPressure, string i_WheelManufacturerName)
        {
            m_LicensePlate = i_LicensePlate;
            m_Wheels = new List<Wheel>(4);
            foreach(Wheel wheel in m_Wheels)
            {
                wheel = new Wheel(i_WheelManufacturerName, i_WheelCurrentAirPressure, 29);
            }
        }
    }
}
