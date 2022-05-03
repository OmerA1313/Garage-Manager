using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_IsRefrigerated;
        private float m_LoadingCapacity;

        internal override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = base.GetDetails();
            details.Add("is refrigerated",m_IsRefrigerated.ToString());
            details.Add("loading capacity", m_LoadingCapacity.ToString());
            return details;
        }
    }
}
