using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class VehiclesFactory
    {
        public List<string> GetSettingsParameters<T>(){
            List<string> neededParameter = T.GetSettingsParameters();
            return neededParameter;
        }

        public Vehicle CreateVehicle<T>(List<string> i_InputParameters)
        {
            bool isValidParam = T.ValidateParameters(List<string> i_InputParameters);

            if (isValidParam)
            {
                return new Vehicle(i_InputParameters);
            }
        }
    }
}
