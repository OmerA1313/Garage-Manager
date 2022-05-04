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

        public override List<string> GetParameters()
        {
            List<string> parameters = base.GetParameters();
            parameters.Add("Is refrigerated");
            parameters.Add("Loading capacity");
            return parameters;
        }

        public override void SetParameters(List<string> i_Parameters)
        {
            base.SetParameters(i_Parameters);
            m_IsRefrigerated = Convert.ToBoolean(int.Parse(Utils.GetAndRemoveFirstItemOfList(i_Parameters))); // TODO parse from string to boolean
            m_LoadingCapacity = float.Parse(Utils.GetAndRemoveFirstItemOfList(i_Parameters));
        }
    }
}
