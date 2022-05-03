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

        internal Car(string i_LicensePlate)
        {
            m_LicensePlate = i_LicensePlate;
            m_Wheels = new List<Wheel>(4);
        }

        internal override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = base.GetDetails();
            details.Add("Color", m_Color.ToString());
            details.Add("Number of doors", m_NumberOfDoors.ToString());
            return details;
        }
    }
}
