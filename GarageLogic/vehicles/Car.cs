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
        private readonly int m_MaxWheelAirPressure = 29;
        private readonly int m_NumberOfWheels = 2;
        private readonly float m_FuledEngingCapacity = 6.2F;
        private readonly float m_ElectricEngingCapacity = 2.5F;

        internal enum eCarColor
        {
            Red = 1, White, Green, Blue
        }

        internal Car(bool i_IsFuelEngine)
        {
            m_Wheels = new List<Wheel>(4); // TODO change to readOnly, and send number of wheels as parameter
            base.CreateWheels(29);
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
            parameters.Add("Color:\n" + Utils.CreateEnumeratedOptions(getVehicleColorOptionsAsList()));
            parameters.Add("Number of doors");
            return parameters;
        }

        private List<string> getVehicleColorOptionsAsList()
        {
            return Enum.GetNames(typeof(eCarColor)).ToList();
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
