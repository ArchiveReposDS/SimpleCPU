using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCPU
{
    static public class InstructionsDecoder
    {
        static public Dictionary<string, string> OpCodeDic { get; set; }
        static public string OpCode { get; set; }
        static public int Value { get; set; }

        static InstructionsDecoder()
        {
            OpCodeDic = new Dictionary<string, string>()
            {
                { "0001", "ldA"},   // 1 Load to A                      value: "0000"
                { "0010", "ldB"},   // 2 Load to B                      value: "0000"
                { "0011", "ldC"},   // 3 Load to C                      value: "0000"
                { "0100", "add"},   // 4 ADD A + B
                { "1100", "dsp"},   // 5 DISPLAY A
                { "0101", "sub"},   // 6 SUB C - A (SHOW FLAG IN REG F)
                { "1001", "jif"},   // 7 JUMP IF (REG F) TO LINE        value: "0000"
                { "1111", "end"},   // 8 END
            };

        }

        public static string GetOpCode(string s)
        {
           string opString = s.Substring(0, 4);

            if (opString == "0001")
                return "ldA";
            if (opString == "0010")
                return "ldB";
            if (opString == "0011")
                return "ldC";
            if (opString == "0100")
                return "add";
            if (opString == "1100")
                return "dsp";
            if (opString == "0101")
                return "sub";
            if (opString == "1001")
                return "jif";
            if (opString == "1111")
                return "end";

            return "0000";
        }

        public static int GetValueCode(string s)
        {
            string valueString = s.Substring(4, 4);
            int valueInt = valueString.ToIntBin();
            return valueInt;
        }



    }
}
