using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCPU
{
    public static class RAM
    {
        public static List<string> addresses = new List<string>();

        static RAM()
        {
            for (int i = 0; i < 16; i++)
            {
                addresses.Add("00000000");
            }
        }

    }
}
