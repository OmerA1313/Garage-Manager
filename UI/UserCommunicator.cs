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
    }
}
