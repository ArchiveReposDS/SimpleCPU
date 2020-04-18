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


            and1.i1 = inputDataPar;
            and1.i2 = writeEnable;
            bool and1Output = and1.GetOutput();
            bool set = and1Output;

            not1.i1 = inputDataPar;
            bool not1Output = not1.GetOutput();

            and2.i1 = not1Output;
            and2.i2 = writeEnable;
            bool and2Output = and2.GetOutput();
            bool reset = and2Output;
            
            or1.i2 = set;
            bool orOutput = or1.GetOutput();

            not2.i1 = reset;
            bool not2Output = not2.GetOutput();

            and3.i1 = orOutput;
            and3.i2 = not2Output;
            bool and3Output = and3.GetOutput();

            or1.i1 = and3Output;

            return and3Output;
        }

        public bool WriteEnable(bool writeEnablePar)
        {
            writeEnable = writeEnablePar;


            and1.i1 = inputData;
            and1.i2 = writeEnablePar;
            bool and1Output = and1.GetOutput();
            bool set = and1Output;

            not1.i1 = inputData;
            bool not1Output = not1.GetOutput();

            and2.i1 = not1Output;
            and2.i2 = writeEnablePar;
            bool and2Output = and2.GetOutput();
            bool reset = and2Output;

            or1.i2 = set;
            bool orOutput = or1.GetOutput();

            not2.i1 = reset;
            bool not2Output = not2.GetOutput();

            and3.i1 = orOutput;
            and3.i2 = not2Output;
            bool and3Output = and3.GetOutput();

            or1.i1 = and3Output;

            return and3Output;
        }
    }

    


}


