using System;
using System.Collections.Generic;
using System.Text;
using GarageLogic;

namespace UI
{
    internal class GarageMenu
    {
        private UserCommunicator m_Communicator;
        private Garage m_Garage;
        private string m_MenuString;

        internal GarageMenu()
        {
            m_Communicator = new UserCommunicator();
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
            Console.Clear();
            m_Communicator.PrintMenu(m_MenuString);
        }

        internal void Excecute()
        {
            eMenuOptions menuOptionChoice;
            do
            { 
                printMenu();
                menuOptionChoice = m_Communicator.GetMenuOptionFromUser();
                try
                {
                   switch (menuOptionChoice)
                    {
                        case eMenuOptions.EnterNewVehicle:
                            {
                                string licnesePlate = m_Communicator.GetLicensePlateFromUser();
                                if (m_Garage.IsVehicleExists(licnesePlate))
                                {
                                    m_Garage.ResetStateOfExistingVehicle(licnesePlate);
                                    m_Communicator.PrintMessage($"vehicle {licnesePlate} already exists in garage");
                                }
                                else
                                {
                                    string typeOfVehicle =
                                        m_Communicator.GetTypeOfVehicle(m_Garage.GetSupportedVehicleTypesAsList());
                                    bool isFuelEngine = m_Communicator.GetEnergyTypeOfEngine(
                                        VehicleFactory.GetEnergyTypeAsList(typeOfVehicle));
                                    List<string> parametersToGetFromUser = VehicleFactory.GetCreationParameters(
                                        typeOfVehicle,
                                        licnesePlate,
                                        isFuelEngine);
                                    List<string> userInputForParams =
                                        m_Communicator.GetParametersFromUser(parametersToGetFromUser);
                                    List<string> vehicleInGarageInfo =
                                        m_Communicator.GetInfoForVehicleInGarage(
                                            m_Garage.GetVehicleStatesValuesAsList());
                                    m_Garage.CreateAndEnterVehicleToGarage(userInputForParams, vehicleInGarageInfo);
                                }

                                break;
                            }

                        case eMenuOptions.GetLicensePlates:
                            {
                                string vehicleState;
                                bool toFilter = m_Communicator.GetFilterationChoiceFromUser(m_Garage.GetVehicleStatesValuesAsList(), out vehicleState);
                                m_Communicator.ClearScreen();
                                m_Communicator.PrintEnumeratedList(m_Garage.GetLicensePlatesInGarage(vehicleState, toFilter), "Vehicles that match your query:", "There are no vehicles to display");
                                break;
                            }

                        case eMenuOptions.ChangeVehicleState:
                            {
                                string licensePlate = m_Communicator.GetLicensePlateFromUser();
                                string vehicleState =
                                    m_Communicator.GetVehicleState(m_Garage.GetVehicleStatesValuesAsList());
                                m_Garage.SetVehicleState(licensePlate, vehicleState);
                                break;
                            }

                        case eMenuOptions.InflateToMax:
                            {
                                string licensePlate = m_Communicator.GetLicensePlateFromUser();
                                m_Garage.InflateVehicleToMax(licensePlate);
                                break;
                            }

                        case eMenuOptions.Refuel:
                            {
                                string licensePlate = m_Communicator.GetLicensePlateFromUser();
                                string fuelType = m_Communicator.GetFuelTypeFromUser(m_Garage.GetFuelTypeAsList());
                                string fuelAmount = m_Communicator.GetFuelAmountFromUser();
                                m_Garage.RefuelVehicle(licensePlate, fuelAmount, fuelType);
                                break;
                            }

                        case eMenuOptions.Recharge:
                            {
                                string licensePlate = m_Communicator.GetLicensePlateFromUser();
                                string minutesToCharge = m_Communicator.GetTimeToRecharcgAmountFromUser();
                                m_Garage.RechargeVehicle(licensePlate, minutesToCharge);
                                break;
                            }

                        case eMenuOptions.GetDetails:
                            {
                                string licensePlate = m_Communicator.GetLicensePlateFromUser();
                                Dictionary<string, string> vehicleDetails = m_Garage.GetVehicleDetails(licensePlate);
                                m_Communicator.PrintVehicleDetails(vehicleDetails);
                                break;
                            }

                        case eMenuOptions.Exit:
                            {
                                m_Communicator.PrintGoodbye();
                                continue;
                            }

                        default:
                            {
                                m_Communicator.WaitForAnyKeyWithMessageAndClearScreen("Wrong input! please enter one of the numbers representing a menu option", "get back to main menu");
                                continue;
                            }
                    }

                   m_Communicator.WaitForAnyKeyWithMessageAndClearScreen("Request completed successfully", "get back to main menu");
                }
                catch (Exception ex)
                {
                    m_Communicator.WaitForAnyKeyWithMessageAndClearScreen("An error occurred: " + ex.Message, "get back to main menu");
                }

            } while (menuOptionChoice != eMenuOptions.Exit);
        }
    }
}
