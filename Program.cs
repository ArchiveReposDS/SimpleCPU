using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleCPU
{
    class Program
    {
        static void Main(string[] args)
        {
            Processor start = new Processor();
            start.LoadSoftwareToRAM();
        }
    }

   
}




















