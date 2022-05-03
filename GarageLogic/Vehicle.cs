using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlate;
        private Engine m_Engine;
        private float m_RemainingEnergy;
        private List<Wheel> m_Wheels;
    }
}
