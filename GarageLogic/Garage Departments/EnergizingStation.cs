using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic.Garage_Departments
{
    class EnergizingStation
    {

        public enum eEnergyType
        {
            Gas = 1,
            Electricity
        }

        public enum eFuelType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }

        public void EnergizeVehicle(VehicleInGarage i_VehicleToEnergize, float i_EnergyAmount, eFuelType i_FuelType = default)
        // 5+6
        {
            i_VehicleToEnergize.Vehicle.Engine.Energize(i_EnergyAmount, i_FuelType);
        }

        public eFuelType ParseFuelType(string i_FuelType)
        {
            eFuelType desiredFuelType;
            bool enumConversionSuccses = Enum.TryParse(i_FuelType, out desiredFuelType);
            if(!enumConversionSuccses)
            {
                throw new FormatException("Wrong fuel type input");
            }

            return desiredFuelType;
        }
    }
}
