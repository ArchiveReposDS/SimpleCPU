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
