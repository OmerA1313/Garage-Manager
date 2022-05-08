using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Garage_Departments.EnergizingStation;

namespace GarageLogic
{
    public static class VehicleFactory
    {

        private static Vehicle m_VehicleToCreate;

        enum eVehicleType
        {
            Car = 1,
            MotoyCycle,
            Truck
        }

        public static List<string> GetEnergyTypeAsList(string i_VehicleType)
        {
            List<string> AllEnergyTypes = Enum.GetNames(typeof(eEnergyType)).Cast<string>().ToList();
            eVehicleType vehicleType;
            Enum.TryParse(i_VehicleType, out vehicleType);
            if (vehicleType == eVehicleType.Truck)
            {
                AllEnergyTypes.Remove("Electricity");
            }

            return AllEnergyTypes;
        }

        public static List<string> GetAllSupportedVehicleTypes()
        {
            return Enum.GetNames(typeof(eVehicleType)).ToList();
        }

        public static List<string> GetCreationParameters(string i_VehicleType, string i_LicensePlate, bool i_IsFuelEngine)
        {
            List<string> paramters = null;
            eVehicleType vehicleType;
            bool parsingSucces = Enum.TryParse(i_VehicleType, out vehicleType);
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

                m_VehicleToCreate.LicensePlate = i_LicensePlate;
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
