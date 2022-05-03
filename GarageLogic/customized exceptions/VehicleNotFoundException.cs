using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class VehicleNotFoundException : Exception
    {
        private string m_LicensePlate;

        internal VehicleNotFoundException(string i_LicensePlate)
        {
            m_LicensePlate = i_LicensePlate;
        }
    }
}
