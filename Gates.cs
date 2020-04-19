using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCPU
{
    public class And
    {
        public bool i1;
        public bool i2;
        public bool output;

        public bool I1(bool i1par)
        {
            this.i1 = i1par;
            if (i1par && i2)
            {
                output = true;
                return output;
            }
            output = false;
            return output;
        }

        public bool I2(bool i2par)
        {
            this.i2 = i2par;
            if (i1 && i2par)
            {
                output = true;
                return output;
            }
            output = false;
            return output;
        }
    }

    public class Or
    {
        public bool i1;
        public bool i2;
        public bool output;

        public bool I1(bool i1par)
        {
            this.i1 = i1par;
            if (i1par || i2)
            {
                output = true;
                return output;
            }
            output = false;
            return output;
        }

        public bool I2(bool i2par)
        {
            this.i2 = i2par;
            if (i1 || i2par)
            {
                output = true;
                return output;
            }
            output = false;
            return output;
        }
    }

    public class Not
    {
        public bool i1;
        public bool output;

        public bool I1(bool i1par)
        {
            this.i1 =  i1par;
            if (i1par)
            {
                output = false;
                return output;
            }
            output = true;
            return output;
        }
    }
}
