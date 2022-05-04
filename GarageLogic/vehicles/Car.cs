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

        public override List<string> GetParameters()
        {
            List<string> parameters = base.GetParameters();
            parameters.Add("Color");
            parameters.Add("Number of doors");
            return parameters;
        }

        public override void SetParameters(List<string> i_Parameters)
        {
            base.SetParameters(i_Parameters);
            bool colorParse = Enum.TryParse(Utils.GetAndRemoveFirstItemOfList(i_Parameters), false, out m_Color);
            if(!colorParse)
            {
                throw new FormatException("Wrong color input");
            }

            m_NumberOfDoors = int.Parse(Utils.GetAndRemoveFirstItemOfList(i_Parameters));

        }
    }
}
