using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic.Garage_Departments
{
    internal class EnergizingStation
    {

        internal enum eEnergyType
        {
            Gas = 1,
            Electricity
        }

        internal enum eFuelType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }

        internal void EnergizeVehicle(VehicleInGarage i_VehicleToEnergize, float i_EnergyAmount, eFuelType i_FuelType = default)
        {
            i_VehicleToEnergize.Vehicle.Engine.Energize(i_EnergyAmount, i_FuelType);
        }

        internal eFuelType ParseFuelType(string i_FuelType)
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
