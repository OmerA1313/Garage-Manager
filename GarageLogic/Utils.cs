using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal static class Utils
    {
        public static Dictionary<string, string> ConcatDictionary(Dictionary<string, string> i_DestDict, Dictionary<string, string> i_SrcDict)
        {
            foreach(var item in i_SrcDict)
            {
                i_DestDict.Add(item.Key,item.Value);
            }

            return i_DestDict;
        }
    }
}
