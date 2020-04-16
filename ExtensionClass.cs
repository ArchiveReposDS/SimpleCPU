using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCPU
{
    public static class ExtensionClass
    {
        static Dictionary<string, int> formatDic = new Dictionary<string, int>()
        {
            { "0000", 0},
            { "0001", 1},
            { "0010", 2},
            { "0011", 3},
            { "0100", 4},
            { "0101", 5},
            { "0110", 6},
            { "0111", 7},
            { "1000", 8},
            { "1001", 9},
            { "1010", 10},
            { "1011", 11},
            { "1100", 12},
            { "1101", 13},
            { "1110", 14},
            { "1111", 15},
        };

        public static int ToIntBin(this string stringA)
        {
            return formatDic[stringA];
        }

        public static string ToStringBin(this int number)
        {
            return formatDic.FirstOrDefault(x => x.Value == number).Key;
        }

    }


}
