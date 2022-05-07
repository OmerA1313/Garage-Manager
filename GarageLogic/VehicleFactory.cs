using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public static class VehicleFactory
    {
        enum eVehicleType
        {
            Car = 1,
            MotoyCycle,
            Truck
        }
        

        private static Vehicle m_VehicleToCreate;

        public static List<string> GetAllPossibleVehicleTypeNames() // in order to notify the user what vehicle can he choose -> THATS UNNECESRRY, WE CAN USE SOME METHOD LIKE I HAVE CREATED IN THE GARAGE.
        {
            IEnumerable<Type> possibleVehicleTypes =
                typeof(Vehicle).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Vehicle)));
            List<string> possibleTypesNames = possibleVehicleTypes.Select(i => i.Name).ToList();
            return possibleTypesNames;
        }

        public static List<string> GetCretionParameters(string i_VehicleType, bool i_IsFuelEngine)
        {
            List<string> paramters = null;
            eVehicleType vehicleType;
            bool parsingSucces = Enum.TryParse<eVehicleType>(i_VehicleType, out vehicleType);
            if (parsingSucces == true)
            {
                switch (vehicleType)
                {
                    case eVehicleType.Car:
                        {
                            m_VehicleToCreate = new Car(i_IsFuelEngine);
                            break;
                        }

                    case eVehicleType.MotoyCycle:
                        {
                            m_VehicleToCreate = new MotorCycle(i_IsFuelEngine);
                            break;
                        }

                    case eVehicleType.Truck:
                        {
                            m_VehicleToCreate = new Truck();
                            break;
                        }
                }

                paramters = m_VehicleToCreate.GetParameters();
            }

            return paramters;
        }

        internal static Vehicle CreateNewVehicleFromParameteres(List<string> i_Parmamters)
        {
            m_VehicleToCreate.SetParameters(i_Parmamters);
            return m_VehicleToCreate;
        }
   
    }
}
