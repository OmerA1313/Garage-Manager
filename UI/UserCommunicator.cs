using System;
using System.Collections.Generic;
using System.Text;
using static UI.GarageMenu;

namespace UI
{
    internal class UserCommunicator
    {
        public eMenuOptions GetMenuOptionFromUser()
        {
            string userChoice = Console.ReadLine();
            Console.Clear();
            eMenuOptions userParsedChoice;
            Enum.TryParse(userChoice, out userParsedChoice);
            return userParsedChoice;
        }

        public void PrintMenu(string i_MenuString)
        {
            Console.WriteLine(i_MenuString);
        }

        public string GetLicensePlateFromUser()
        {
            bool invalidInput = true;
            string userInput = null;

            while (invalidInput)
            {
                Console.WriteLine("Please enter vehicle license plate:");
                userInput = Console.ReadLine();
                invalidInput = userInput.Length == 0;
            }

            return userInput;
        }

        public bool GetFilterationChoiceFromUser(List<string> i_AllAvailableCarStates, out string o_VehicleState)
        {
            bool filterationNeeded = true;
            Console.WriteLine("Please enter vehicle state:");
            PrintEnumeratedList(i_AllAvailableCarStates);
            Console.WriteLine("4. All");
            string userInput = Console.ReadLine();
            if (userInput == "4")
            {
                filterationNeeded = false;
                o_VehicleState = null;
            }
            else
            {
                o_VehicleState = userInput;
            }

            return filterationNeeded;
        }

        internal string GetVehicleState(List<string> i_AllAvailableCarStates)
        {
            Console.WriteLine("Please enter vehicle state:");
            PrintEnumeratedList(i_AllAvailableCarStates);
            return Console.ReadLine();
        }

        internal void PrintEnumeratedList(List<string> i_ListToPrint)
        {
            if (i_ListToPrint.Count != 0)
            {
                int index = 1;
                foreach (string value in i_ListToPrint)
                {
                    Console.WriteLine("{0}. {1}", index, value);
                    index++;
                }
            }
        }

        internal string GetFuelTypeFromUser(List<string> i_AllAvailableFuelTypes)
        {
            PrintEnumeratedList(i_AllAvailableFuelTypes);
            Console.WriteLine("Please enter fuel type");
            return Console.ReadLine();
        }

        internal void PrintVehicleDetails(Dictionary<string, string> vehicleDetails)
        {
            Console.WriteLine("The details of chosen vehicle are:");
            foreach (KeyValuePair<string,string> detailAndValue in vehicleDetails)
            {
                Console.WriteLine("{0} : {1}", detailAndValue.Key, detailAndValue.Value);
            }
        }

        internal void PrintGoodbye()
        {
            Console.WriteLine("Hope To See You Again!\nByeBye!");
        }

        internal string GetFuelAmountFromUser()
        {
            Console.WriteLine("How many liters would you like to refule? Enter A number.");
            return Console.ReadLine();
        }

        internal string GetTimeToRecharcgAmountFromUser()
        {
            Console.WriteLine("How many minutes would you like to recharge? Enter A number.");
            return Console.ReadLine();
        }

        internal bool GetEnergyTypeOfEngine(List<string> i_TypeOfSupportedEngine)
        {
            bool isVehicleUsingGas = true;
            if (i_TypeOfSupportedEngine.Count != 1)
            {
                bool invalidInput = true;
                while (invalidInput)
                {
                    invalidInput = false;
                    Console.WriteLine("What type of energy your engine use?");
                    PrintEnumeratedList(i_TypeOfSupportedEngine);
                    Console.WriteLine("Please enter the number of chosen type");
                    string userAnswer = Console.ReadLine();

                    if (userAnswer == "1")                          
                    {
                        isVehicleUsingGas = true;
                    }
                    else if (userAnswer == "2")
                    {

                        isVehicleUsingGas = false;
                    }
                    else
                    {
                        Console.WriteLine("The number you enter must be between 1 to {1}", i_TypeOfSupportedEngine.Count);
                        invalidInput = true;
                    }
                }
            }
          
            return isVehicleUsingGas;
        }

        internal string GetTypeOfVehicle(List<string> i_AllSupportedVehicleTypes)
        {
            beforeParametersEnteringProccesMessage();
            Console.WriteLine("Plese enter type of vehicle:");
            PrintEnumeratedList(i_AllSupportedVehicleTypes);
            return Console.ReadLine();
        }

        private void beforeParametersEnteringProccesMessage()
        {
            Console.WriteLine("\nWe are about to begin the registration process" +
                "\nPlease make sure to follow the instructions! \n" +
                "Enter the values as written in the example in (...) \n" +
                "When given a numbered list to choose from - please enter the corresponding number");
                WaitForAnyKeyWithMessageAndClearScreen("", "start the registration proccess");



        }

        public void WaitForAnyKeyWithMessageAndClearScreen(string i_message, string i_WhatHappendAter)
        {
            Console.WriteLine(i_message);
            Console.WriteLine("Enter any key to " + i_WhatHappendAter + "...");
            Console.ReadLine();
            Console.Clear();
        }

        public List<string> GetParametersFromUser(List<string> i_NameOfNeededParameters)
        {
            List<string> userInputs = new List<string>();
            foreach (string parameterName in i_NameOfNeededParameters)
            {
                Console.WriteLine("Please Enter " + parameterName);
                string userInput = Console.ReadLine();
                userInputs.Add(userInput);
            }


            return userInputs;
        }

        internal List<string> GetInfoForVehicleInGarage(List<string> i_GetVehicleStatesValuesAsList)
        {
            List<string> vehicleInGarageInfo = new List<string>();
            Console.WriteLine("Please enter owner name:");
            vehicleInGarageInfo.Add(Console.ReadLine());
            Console.WriteLine("Please enter owner's phone number:");
            vehicleInGarageInfo.Add(Console.ReadLine());

            return vehicleInGarageInfo;
        }

        public void PrintMessage(string i_ExMessage)
        {
            Console.WriteLine(i_ExMessage);
        }
    }
}
