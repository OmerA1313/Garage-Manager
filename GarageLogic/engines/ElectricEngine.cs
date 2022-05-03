﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class ElectricEngine : Engine
    {
        public override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            details.Add("Time left in battery",m_CurrentEnergyAmount.ToString());
            details.Add("Maximum battery capacity", m_MaxEnergyAmount.ToString());
            return details;
        }
    }
}
