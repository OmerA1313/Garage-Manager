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

        public string GetVehicleStateFromUser()
        {
            Console.WriteLine("Please enter vehicle state");
        }
    }
}
