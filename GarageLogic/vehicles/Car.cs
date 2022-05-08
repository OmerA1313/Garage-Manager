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
        private static readonly int sr_MaxWheelAirPressure = 29;
        private static readonly int sr_NumberOfWheels = 4;
        private static readonly float sr_FuledEngingCapacity = 38;
        private static readonly float sr_ElectricEngingCapacity = 3.3F;

        internal enum eCarColor
        {
            Red = 1, White, Green, Blue
        }

        internal Car(bool i_IsFuelEngine)
        {
            m_Wheels = new List<Wheel>(sr_NumberOfWheels);
            base.CreateWheels(sr_MaxWheelAirPressure);
            base.CreateEngine(i_IsFuelEngine);

            if(i_IsFuelEngine)
            {
                FuelEngine engine = m_Engine as FuelEngine;
                engine.FuelType = EnergizingStation.eFuelType.Octan95;
                engine.MaxEnergyAmount = sr_FuledEngingCapacity;
            }
            else
            {
                ElectricEngine engine = m_Engine as ElectricEngine;
                engine.MaxEnergyAmount = sr_ElectricEngingCapacity;
            }
        }

        internal override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = base.GetDetails();
            details.Add("Color", m_Color.ToString());
            details.Add("Number of doors", m_NumberOfDoors.ToString());
            return details;
        }

        internal override List<string> GetParameters()
        {
            List<string> parameters = base.GetParameters();
            parameters.Add("Color:\n" + Utils.CreateEnumeratedOptions(getVehicleColorOptionsAsList()));
            parameters.Add("Number of doors (2,3,4 or 5)");
            return parameters;
        }

        internal override void SetParameters(List<string> i_Parameters)
        {
            base.SetParameters(i_Parameters);
            m_Color = parseCarColor(Utils.PopFirstItemOfList(i_Parameters));
            m_NumberOfDoors = parseNumberOfDoors(Utils.PopFirstItemOfList(i_Parameters));
        }

        private List<string> getVehicleColorOptionsAsList()
        {
            return Enum.GetNames(typeof(eCarColor)).ToList();
        }

        private eCarColor parseCarColor(string i_CarColor)
        {
            bool colorParse = Enum.IsDefined(typeof(eCarColor), int.Parse(i_CarColor));
            if(!colorParse)
            {
                throw new FormatException("Wrong color input");
            }

            eCarColor desiredColor;
            Enum.TryParse(i_CarColor, out desiredColor);
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
