using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class VehicleFactory
    {
        public List<string> GetAllPossibleVehicleTypeNames() // in order to notify the user what vehicle can he choose
        {
            IEnumerable<Type> possibleVehicleTypes =
                typeof(Vehicle).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Vehicle)));
            List<string> possibleTypesNames = possibleVehicleTypes.Select(i => i.Name).ToList();
            return possibleTypesNames;
        }

    }
}
