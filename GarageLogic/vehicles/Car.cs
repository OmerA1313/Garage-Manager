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
            Red = 1, White, Green, Blue
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
                engine.MaxEnergyAmount = 38;
            }
            else
            {
                ElectricEngine engine = m_Engine as ElectricEngine;
                engine.MaxEnergyAmount = 3.3F;
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
            parameters.Add("Color:\n" + createEnumeratedColorOptions(getVehicleColorOptionsAsList())); // maybe extract to the utils class
            parameters.Add("Number of doors (2,3,4 or 5)");
            return parameters;
        }

        private string createEnumeratedColorOptions(List<string> i_ListToTakeTheOptionsFrom)
        {
            List<string> enumeratedOptions = new List<string>();
            int indexOfOption = 1;
            foreach (string option in i_ListToTakeTheOptionsFrom)
            {
                enumeratedOptions.Add(string.Format("{0}. {1}", indexOfOption, option));
                indexOfOption++;
            }

            return String.Join("\n",enumeratedOptions);
        }

        public List<string> getVehicleColorOptionsAsList()
        {
            return Enum.GetNames(typeof(eCarColor)).ToList();
        }

        public override void SetParameters(List<string> i_Parameters)
        {
            base.SetParameters(i_Parameters);
            m_Color = parseCarColor(Utils.PopFirstItemOfList(i_Parameters));
            m_NumberOfDoors = parseNumberOfDoors(Utils.PopFirstItemOfList(i_Parameters));
        }

        private eCarColor parseCarColor(string i_CarColor)
        {
            eCarColor desiredColor;
            bool colorParse = Enum.TryParse(i_CarColor, out desiredColor);
            if(!colorParse)
            {
                throw new FormatException("Wrong color input");
            }

            return desiredColor;
        }

        private int parseNumberOfDoors(string i_NumberOfDoors)
        {
            int numberOfDoors;
            bool NumberOfDoorsParse = int.TryParse(i_NumberOfDoors, out numberOfDoors);
            if(!NumberOfDoorsParse)
            {
                throw new FormatException("Number of doors not a valid integer");
            }

            if(numberOfDoors != 2 && numberOfDoors != 3 && numberOfDoors != 4 && numberOfDoors != 5)
            {
                throw new ArgumentException("Wrong number of doors input, can only be 2,3,4 or 5");
            }

            return numberOfDoors;
        }
    }
}
