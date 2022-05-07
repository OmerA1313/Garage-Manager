using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class VehicleFactory
    {
        // HERE WE NEED TO DECIDE ABOUT DS TO HOLD THE TYPE OF VEHICLES WE HAVE SUPPORT IN OUR GARAGE
        public List<string> GetAllPossibleVehicleTypeNames() // in order to notify the user what vehicle can he choose -> THATS UNNECESRRY, WE CAN USE SOME METHOD LIKE I HAVE CREATED IN THE GARAGE.
        {
            IEnumerable<Type> possibleVehicleTypes =
                typeof(Vehicle).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Vehicle)));
            List<string> possibleTypesNames = possibleVehicleTypes.Select(i => i.Name).ToList();
            return possibleTypesNames;
        }

    }
}
