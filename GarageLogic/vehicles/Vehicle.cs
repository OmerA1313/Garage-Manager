using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicensePlate;
        protected internal Engine m_Engine;
        protected internal List<Wheel> m_Wheels;

        public string LicensePlate { get; set; }

        internal Engine Engine { get; set; }

        //internal virtual void InflateWheelsByAmount(int i_AmountToInflate)
        //{
        //    foreach(Wheel wheel in m_Wheels)
        //    {
        //        wheel.Inflate(i_AmountToInflate);
        //    }
        //}

        internal virtual void InflateWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        internal void CreateEngine(bool i_IsFuelEngine)
        {
            if (i_IsFuelEngine)
            {
                m_Engine = new FuelEngine();
            }
            else
            {
                m_Engine = new ElectricEngine();
            }
        }

        internal virtual Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            details.Add("License plate", m_LicensePlate);
            details.Add("Model name", m_ModelName);
           // details.Add("Remainig energy", m_RemainingEnergy.ToString());
            Utils.ConcatDictionary(details, m_Wheels[0].GetDetails());
            Utils.ConcatDictionary(details, Engine.GetDetails());
            return details;
        }

        public virtual List<string> GetParameters()
        {
            List<string> parameters = new List<string>();
            parameters.Add("License Plate");
            parameters.Add("Model Name");
            Utils.ConcatLists(parameters, Engine.GetParameters());
            Utils.ConcatLists(parameters, m_Wheels[0].GetParameters());
            return parameters;
        }

        public virtual void SetParameters(List<string> i_Parameters)
        {
            m_LicensePlate = Utils.GetAndRemoveFirstItemOfList(i_Parameters);
            m_ModelName = Utils.GetAndRemoveFirstItemOfList(i_Parameters);
            Engine.SetParameters(i_Parameters);
            setWheelsParameters(i_Parameters);
        }

        private void setWheelsParameters(List<string> i_Parameters)
        {
            string currentWheelAirPressure = Utils.GetAndRemoveFirstItemOfList(i_Parameters);
            string manufacturerName = Utils.GetAndRemoveFirstItemOfList(i_Parameters);
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.SetParameters(currentWheelAirPressure, manufacturerName);
            }
        }
    }
}
