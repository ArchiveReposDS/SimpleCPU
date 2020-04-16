using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCPU
{
    static public class Software
    {
        static public List<string> codeLines { get; set; }

        static Software()
        {
            // XXXX - OP CODE   XXXX - VALUE
            codeLines = new List<string>()
            {                                                                    // PARAMETERS      
                "00010000", // 0 Load to A                         value: "0"     => ----0000    SHOW START NUMBER
                "00100010", // 1 Load to B                         value: "2"     => ----0000    SHOW INCREMENTATION
                "00111001", // 2 Load to C                         value: "10"    => ----0000    SHOW MAXIMUM NUMBER
                "01000000", // 3 ADD A + B
                "11000000", // 4 DISPLAY A
                "01010000", // 5 SUB C - A (SHOW FLAG IN REG F)
                "10010011", // 6 JUMP IF (REG F) TO LINE 3         value: "3"
                "11110000", // 7 END
                "00000000", // 8 
                "00000000", // 9
                "00000000", // 10
                "00000000", // 11
                "00000000", // 12
                "00000000", // 13
                "00000000", // 14
                "00000000"  // 15
            };

        }

    }
}
