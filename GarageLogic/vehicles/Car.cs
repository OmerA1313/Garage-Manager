using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic.Garage_Departments;

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

        internal Car(bool i_IsFuelEngine)
        {
            m_Wheels = new List<Wheel>(4); // TODO change to readOnly, and send number of wheels as parameter
            base.SetWheels(29);
            base.CreateEngine(i_IsFuelEngine);

            if(i_IsFuelEngine)
            {
                FuelEngine engine = m_Engine as FuelEngine;
                engine.FuelType = EnergizingStation.eFuelType.Octan95;
                engine.Capacity = 38;
            }
            else
            {
                ElectricEngine engine = m_Engine as ElectricEngine;
                engine.Capacity = 3.3F;
            }
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
            //TODO get all colors
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

            int numberOfDoors = int.Parse(Utils.GetAndRemoveFirstItemOfList(i_Parameters));
            validateNumberOfDoors(numberOfDoors);
            m_NumberOfDoors = numberOfDoors;
        }

        private void validateNumberOfDoors(int i_NumberOfDoors)
        {
            if(i_NumberOfDoors != 2 && i_NumberOfDoors != 3 && i_NumberOfDoors != 4 && i_NumberOfDoors != 5)
            {
                throw new ArgumentException("Wrong number of doors input, can only be 2,3,4 or 5");
            }
        }
    }
}
