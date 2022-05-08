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

        public static List<string> GetAllSupportedVehicleTypes()
        {
            return Enum.GetNames(typeof(eVehicleType)).Cast<string>().ToList();
        }

        public static List<string> GetCretionParameters(string i_VehicleType, bool i_IsFuelEngine)
        {
            List<string> paramters = null;
            eVehicleType vehicleType;
            bool parsingSucces = Enum.TryParse<eVehicleType>(i_VehicleType, out vehicleType);
            if (parsingSucces)
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

                    default:
                        {
                            throw new ArgumentException("Wrong vehicle type");
                        }
                }

                paramters = m_VehicleToCreate.GetParameters();
            }

            return paramters;
        }

        internal static Vehicle CreateNewVehicleFromParameters(List<string> i_Parmamters)
        {
            m_VehicleToCreate.SetParameters(i_Parmamters);
            return m_VehicleToCreate;
        }
    }
}
