using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using GarageLogic.Garage_Departments;

namespace GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_IsRefrigerated;
        private float m_LoadingCapacity;
        private static readonly int sr_NumberOfWheels = 16;
        private static readonly int sr_MaxFuelCapacity = 120;
        private static readonly int sr_MaxWheelAirPressure = 24;

        internal Truck()
        {
            m_Wheels = new List<Wheel>(sr_NumberOfWheels);
            base.CreateWheels(sr_MaxWheelAirPressure);
            m_Engine = new FuelEngine();
            FuelEngine engine = m_Engine as FuelEngine;
            engine.FuelType = EnergizingStation.eFuelType.Soler;
            engine.MaxEnergyAmount = sr_MaxFuelCapacity;
        }

        internal override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = base.GetDetails();
            details.Add("is refrigerated", isRefrigeratedToString(m_IsRefrigerated));
            details.Add("loading capacity", m_LoadingCapacity.ToString());
            return details;
        }

        private string isRefrigeratedToString(bool i_IsRefrigerated)
        {
            return i_IsRefrigerated ? "Yes" : "No";
        }

        internal override List<string> GetParameters()
        {
            List<string> parameters = base.GetParameters();
            parameters.Add("Is refrigerated:\n" + getYesNoOptions());
            parameters.Add("Loading capacity (Kg)");
            return parameters;
        }

        private string getYesNoOptions()
        {
            return "1. Yes\n" +
                    "2. No";
        }

        internal override void SetParameters(List<string> i_Parameters)
        {
            base.SetParameters(i_Parameters);
            m_IsRefrigerated = convertYesNoOptionsToBoolean(Utils.PopFirstItemOfList(i_Parameters));
            m_LoadingCapacity = float.Parse(Utils.PopFirstItemOfList(i_Parameters));
        }

        /// <summary>
        /// throws ArgumentException with moduled message about expected input
        /// </summary>
        /// <param name="UserInput"></param>
        /// <returns> UserInput is 1 -> True <br/> 
        ///           UserInput is 2 -> False  
        /// </returns>
        private bool convertYesNoOptionsToBoolean(string i_UserInput)
        {
            bool returnVal;
            if (i_UserInput == "1")
            {
                returnVal = true;
            }
            else if (i_UserInput == "2")
            {
                returnVal = false;
            }
            else
            {
                throw new ArgumentException("The answer for 'does the truck carry refrigerated content?' should be answered by 1 or 2 only.");
            }

            return returnVal;
        }
    }
}
