using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal static class Utils
    {
        public static string CreateEnumeratedOptions(List<string> i_ListToTakeTheOptionsFrom)
        {
            List<string> enumeratedOptions = new List<string>();
            int indexOfOption = 1;
            foreach (string option in i_ListToTakeTheOptionsFrom)
            {
                enumeratedOptions.Add(string.Format("{0}. {1}", indexOfOption, option));
                indexOfOption++;
            }

            return String.Join("\n", enumeratedOptions);
        }
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

        public static string GetAndRemoveFirstItemOfList(List<string> i_Parameters)
        {
            string toRemove = i_Parameters.First();
            i_Parameters.RemoveAt(0);
            return toRemove;
        }
    }
}
