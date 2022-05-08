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
        private readonly int m_NumberOfWheels = 16;
        private bool m_IsRefrigerated;
        private float m_LoadingCapacity;

        internal Truck()
        {
            m_Wheels = new List<Wheel>(m_NumberOfWheels);
            base.SetWheels(24);
            m_Engine = new FuelEngine();
            FuelEngine engine = m_Engine as FuelEngine;
            engine.FuelType = EnergizingStation.eFuelType.Soler;
        }

        internal override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = base.GetDetails();
            details.Add("is refrigerated", isRefrigeratedToString(m_IsRefrigerated));
            details.Add("loading capacity", m_LoadingCapacity.ToString());
            return details;
        }

        public override List<string> GetParameters()
        {
            List<string> parameters = base.GetParameters();
            parameters.Add("Is refrigerated");
            parameters.Add("Loading capacity (Kg)");
            return parameters;
        }

        public override void SetParameters(List<string> i_Parameters)
        {
            base.SetParameters(i_Parameters);
            m_IsRefrigerated = parseIsRefrigerated(Utils.PopFirstItemOfList(i_Parameters));
            m_LoadingCapacity = float.Parse(Utils.PopFirstItemOfList(i_Parameters));
        }

        private bool parseIsRefrigerated(string i_IsRefrigeratedStr)
        {
            int booleanAsInt;
            bool booleanParsed = int.TryParse(i_IsRefrigeratedStr, out booleanAsInt);
            bool integerConvertable = booleanAsInt == 0 || booleanAsInt == 1;
            if(!booleanParsed || !integerConvertable)
            {
                throw new FormatException("Wrong input for is truck refrigerated");
            }

            return Convert.ToBoolean(booleanAsInt);
        }

        private string isRefrigeratedToString(bool i_IsRefrigerated)
        {
            return i_IsRefrigerated ? "Yes" : "No";
        }
    }
}
