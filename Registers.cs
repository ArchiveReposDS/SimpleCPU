using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCPU
{
    public static class Registers
    {
        public static string A { get; set; } = "00000000";
        public static string B { get; set; } = "00000000";
        public static string C { get; set; } = "00000000";
        public static string I { get; set; } = "00000000"; // INSTRUCTIONS
        public static string O { get; set; } = "00000000"; // OUTPUT AFTER ALU CALCULATION
        public static string F { get; set; } = "00000000"; // SUBSTRACTION FLAG
        public static string E { get; set; } = "00000000"; // END PROGRAM FLAG
    }
}
