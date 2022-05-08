using System;
using System.Collections.Generic;
using System.Text;
using GarageLogic;

namespace UI
{
    internal class GarageMenu
    {
        private UserCommunicator m_communicator;
        private Garage m_Garage;
        private string m_MenuString;

        internal GarageMenu()
        {
            m_communicator = new UserCommunicator();
            m_Garage = new Garage();
            generateMenuOptions();
        }

        internal enum eMenuOptions
        {
            EnterNewVehicle = 1,
            GetLicensePlates,
            ChangeVehicleState,
            InflateToMax,
            Refuel,
            Recharge,
            GetDetails,
            Exit
        }

        private void generateMenuOptions()
        {
            StringBuilder sb = new StringBuilder();
            string promptMessage = "Please choose an option";
            string firsttMenuOption = "1. Enter new vehicle to Garage";
            string secondMenuOption = "2. Get license plates of vehicles in garage";
            string thirdMenuOption = "3. Change vehicle state";
            string fourthMenuOption = "4. Inflate vehicle wheels to max";
            string fifthMenuOption = "5. Refuel a fuel-motored vehicle";
            string sixthMenuOption = "6. Recharge an electric-motored vehicle";
            string sevenMenuOption = "7. Get full vehicle details";
            string eightMenuOption = "8. Exit";
            string[] menuOptions =
                {
                    promptMessage, firsttMenuOption, secondMenuOption, thirdMenuOption, fourthMenuOption, fifthMenuOption,
                    sixthMenuOption, sevenMenuOption, eightMenuOption,
                };

            sb.AppendJoin("\n", menuOptions);
            m_MenuString = sb.ToString();
        }

        private void printMenu()
        {
            m_communicator.PrintMenu(m_MenuString);
        }

        internal void Excecute()
        {
            printMenu();
            eMenuOptions menuOptionChoice;
            do
            {
                menuOptionChoice = m_communicator.GetMenuOptionFromUser();
                switch (menuOptionChoice)
                {
                    case eMenuOptions.EnterNewVehicle:
                        string typeOfVehicle = m_communicator.GetTypeOfVehicleToEnterTheGarage(m_Garage.GetSupportedVehicleTypesAsList());
                        bool isFuelEngine = m_communicator.GetEnergyTypeOfEngine(m_Garage.GetEnergyTypeAsList());
                        List<string> parametersToGetFromUser = VehicleFactory.GetCretionParameters(typeOfVehicle, isFuelEngine);
                        List<string> userInputForParams = m_communicator.GetParametersFromUser(parametersToGetFromUser);
                        List<string> vehicleInGarageInfo = m_communicator.GetInfoForVehicleInGarage(m_Garage.GetVehicleStatesValuesAsList());
                        m_Garage.CreateAndEnterVehicleToGarage(userInputForParams, vehicleInGarageInfo);
                        break;

                    case eMenuOptions.GetLicensePlates:
                        {
                            string filterLicensePlates = m_communicator.GetVehicleStateFromUser(m_Garage.GetVehicleStatesValuesAsList());
                            m_Garage.GetLicensePlatesInGarage(filterLicensePlates);
                            break;
                        }

                    case eMenuOptions.ChangeVehicleState:
                        {
                            string licensePlate = m_communicator.GetLicensePlateFromUser();
                            string vehicleState = m_communicator.GetVehicleStateFromUser(m_Garage.GetVehicleStatesValuesAsList());
                            m_Garage.SetVehicleState(licensePlate, vehicleState);
                            break;
                        }

                    case eMenuOptions.InflateToMax:
                        {
                            string licensePlate = m_communicator.GetLicensePlateFromUser();
                            m_Garage.InflateVehicleToMax(licensePlate);
                            break;
                        }

                    case eMenuOptions.Refuel:
                        {
                            string licensePlate = m_communicator.GetLicensePlateFromUser();
                            string fuelType = m_communicator.GetFuelTypeFromUser(m_Garage.GetFuelTypeAsList());
                            string fuelAmount = m_communicator.GetFuelAmountFromUser();
                            m_Garage.EnergizeVehicle(licensePlate, fuelAmount, fuelType);
                            break;
                        }

                    case eMenuOptions.Recharge:
                        {
                            string licensePlate = m_communicator.GetLicensePlateFromUser();
                            string minutesToCharge = m_communicator.GetTimeToRecharcgAmountFromUser();
                            m_Garage.EnergizeVehicle(licensePlate, minutesToCharge);
                            break;
                        }

                    case eMenuOptions.GetDetails:
                        {
                            string licensePlate = m_communicator.GetLicensePlateFromUser();
                            Dictionary<string, string> vehicleDetails = m_Garage.GetVehicleDetails(licensePlate);
                            m_communicator.PrintVehicleDetails(vehicleDetails);
                            break;
                        }

                    case eMenuOptions.Exit:
                        {
                            m_communicator.PrintGoodbye();
                            break;
                        }
                } 
            } while (menuOptionChoice != eMenuOptions.Exit);
        }
    }
}
