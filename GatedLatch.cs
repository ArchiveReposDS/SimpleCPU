using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCPU
{

    public class GatedLatch
    {
        public bool inputData;
        public bool writeEnable;
        public bool output;

        And and1 = new And();
        Not not1 = new Not();
        And and2 = new And();
        Or or1 = new Or();
        Not not2 = new Not();
        And and3 = new And();
       

        public bool InputData(bool inputDataPar)
        {
            inputData = inputDataPar;
            return Calculation();
        }

        public bool WriteEnable(bool writeEnablePar)
        {
            writeEnable = writeEnablePar;
            return Calculation();
        }

        private bool Calculation()
        {
            bool and1Set_ = and1.I1(inputData);
                 and1Set_ = and1.I2(writeEnable);

            bool not1_ = not1.I1(inputData);

            bool And2Reset_ = and2.I1(not1_);
                 And2Reset_ = and2.I2(writeEnable);

            bool or1_ = or1.I2(and1Set_);

            bool not2_ = not2.I1(And2Reset_);

            bool and3_ = and3.I1(or1_);
                 and3_ = and3.I2(not2_);

                 or1_ = or1.I1(and3_);

            return and3_;
        }
    }

    


}


