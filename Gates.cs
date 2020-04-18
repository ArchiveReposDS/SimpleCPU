using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCPU
{
    public class And
    {
        public bool i1;
        public bool i2;

        public bool GetOutput()
        {
            if (i1 && i2)
            {
                return true;
            }
            return false;
        }
    }

    public class Or
    {
        public bool i1;
        public bool i2;

        public bool GetOutput()
        {
            if (i1 || i2)
            {
                return true;
            }
            return false;
        }
    }

    public class Not
    {
        public bool i1;

        public bool GetOutput()
        {
            if (i1)
            {
                return false;
            }
            return true;
        }
    }
}
