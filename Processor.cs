using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCPU
{
    public class Processor
    {
        int programCounter = 0;
        string Instruction = "00000000";
        int Value = 0;

        public void LoadSoftwareToRAM()
        {
            /////////////////////////////////////////////////////////////
            ///////////////// TEST SPACE - TO REMOVE/////////////////////
            /////////////////////////////////////////////////////////////

            bool b1 = true;
            bool b2 = true;
            bool b3 = false;
            bool b4 = false;
            bool b5 = false;
            bool b6 = false;
            bool b7 = true;
            bool b8 = true;

            GatedLatch l1 = new GatedLatch();
            GatedLatch l2 = new GatedLatch();
            GatedLatch l3= new GatedLatch();
            GatedLatch l4 = new GatedLatch();
            GatedLatch l5 = new GatedLatch();
            GatedLatch l6 = new GatedLatch();
            GatedLatch l7 = new GatedLatch();
            GatedLatch l8 = new GatedLatch();

            l1.WriteEnable(true);
            l2.WriteEnable(true);
            l3.WriteEnable(true);
            l4.WriteEnable(true);
            l5.WriteEnable(true);
            l6.WriteEnable(true);
            l7.WriteEnable(true);
            l8.WriteEnable(true);


            bool ooo1 = l1.InputData(b1);
            bool ooo2 = l2.InputData(b2);
            bool ooo3 = l3.InputData(b3);
            bool ooo4 = l4.InputData(b4);
            bool ooo5 = l5.InputData(b5);
            bool ooo6 = l6.InputData(b6);
            bool ooo7 = l7.InputData(b7);
            bool ooo8 = l8.InputData(b8);

            bool oooo1 = l1.WriteEnable(false);
            bool oooo2 = l2.WriteEnable(false);
            bool oooo3 = l3.WriteEnable(false);
            bool oooo4 = l4.WriteEnable(false);
            bool oooo5 = l5.WriteEnable(false);
            bool oooo6 = l6.WriteEnable(false);
            bool oooo7 = l7.WriteEnable(false);
            bool oooo8 = l8.WriteEnable(false);






         







            string s = "end";

            /////////////////////////////////////////////////////////////
            ///////////////// TEST SPACE - TO REMOVE/////////////////////
            /////////////////////////////////////////////////////////////


            // ŁADOWANIE RAMU BĘDZIE SIĘ ODBYWAĆ STEROWANIEM IMPULSAMI 
            // WARTOSC WPADNIE DO REG I a potem z REG I POD WSKAZANY ADRES RAM
            // 0001-0011  LdI-4  (do I wpadnie wartosc 4)
            // 0002-0100  LdR-8  (I wpadnie do ramu adres 8)

            for (int i = 0; i < 16; i++)
            {
                RAM.addresses[i] = Software.codeLines[i];
            }

            while (Registers.E == "00000000")
            {
                Run();
            }
            Console.ReadKey();


        }


        public void Run()
        {
            FetchInstruction();
            Decoding();
            RunInstruction();

        }

        public void FetchInstruction()
        {
            Registers.I = RAM.addresses[programCounter];
            programCounter++;
        }
        public void Decoding()
        {
            Instruction = InstructionsDecoder.GetOpCode(Registers.I);
            Value = InstructionsDecoder.GetValueCode(Registers.I);
        }
        public void RunInstruction()
        {
            switch (Instruction)
            {
                case "ldA":
                    Registers.A = Value.ToStringBin();
                    break;
                case "ldB":
                    Registers.B = Value.ToStringBin();
                    break;
                case "ldC":
                    Registers.C = Value.ToStringBin();
                    break;
                case "add":
                    Registers.A = (Registers.A.ToIntBin() + Registers.B.ToIntBin()).ToStringBin();
                    break;
                case "dsp":
                    Console.WriteLine(Registers.A.ToIntBin());
                    break;
                case "sub":
                    int a = Registers.C.ToIntBin() - Registers.A.ToIntBin();
                    if (Registers.C.ToIntBin() - Registers.A.ToIntBin() > 0)
                        Registers.F = "00000001";
                    else
                        Registers.F = "00000000";
                    break;
                case "jif":
                    if (Registers.F == "00000001")
                    {
                        programCounter = Value;
                    }
                    break;
                case "end":
                    Registers.E = "00000001";
                    Console.WriteLine("End");
                    break;

                default:
                    break;
            }

        }


    }
}
