using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    internal class UserCommunicator
    {
        public GarageMenu.eMenuOptions GetMenuOptionFromUser()
        {
            throw new NotImplementedException(); //TODO user enum.TryParse;
        }

        public void PrintMenu(string i_MenuString)
        {
            Console.WriteLine(i_MenuString);
        }

        public string GetLicensePlateFromUser()
        {
            Console.WriteLine("Please enter vehicle license plate:");
            return Console.ReadLine();
        }

        public string GetVehicleStateFromUser(List<string> i_AllAvailableCarStates)
        {
            printEnumeratedList(i_AllAvailableCarStates);
            Console.WriteLine("Please enter vehicle state");
            return Console.ReadLine();
        }

        private void printEnumeratedList(List<string> i_ListedValuesOfEnum)
        {
            int index = 1;
            foreach (string value in i_ListedValuesOfEnum)
            {
                Console.WriteLine("{0}. {1}", index, value);
                index++;
            }
        }

        internal string GetFuelTypeFromUser(List<string> i_AllAvailableFuelTypes)
        {
            printEnumeratedList(i_AllAvailableFuelTypes);
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
    }
}
