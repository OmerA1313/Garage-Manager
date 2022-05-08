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

        public static void ConcatLists(List<string> i_DestList, List<string> i_SrcList)
        {
            foreach(string str in i_SrcList)
            {
                i_DestList.Add(str);
            }
        }

        public static string PopFirstItemOfList(List<string> i_Parameters)
        {
            string toRemove = i_Parameters.First();
            i_Parameters.RemoveAt(0);
            return toRemove;
        }
    }
}
