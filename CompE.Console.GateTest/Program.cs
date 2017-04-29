using CompE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompE.ConsoleApp.GateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var gate = new AndGate();
            Console.WriteLine(gate.Output.Value);

            gate.Inputs[0].Value = false;
            gate.Inputs[1].Value = false;
            Console.WriteLine(gate.Output.Value);

            gate.Inputs[0].Value = true;
            gate.Inputs[1].Value = false;
            Console.WriteLine(gate.Output.Value);

            gate.Inputs[0].Value = false;
            gate.Inputs[1].Value = true;
            Console.WriteLine(gate.Output.Value);

            gate.Inputs[0].Value = true;
            gate.Inputs[1].Value = true;
            Console.WriteLine(gate.Output.Value);

            //PrintTruthTable(new AndGate(), "AND");
            //PrintTruthTable(new OrGate(), "OR");
            //PrintTruthTable(new NotGate(), "NOT");

            Console.ReadLine();
        }

        //private static void PrintTruthTable(LogicGate gate, string name)
        //{
        //    Console.WriteLine(name);
        //    Console.WriteLine("======");
        //    PrintTruthTableRow(gate, false, false);
        //    PrintTruthTableRow(gate, false, true);
        //    PrintTruthTableRow(gate, true, false);
        //    PrintTruthTableRow(gate, true, true);
        //    Console.WriteLine();
        //}

        //private static void PrintTruthTableRow(LogicGate gate, bool a, bool b)
        //{
        //    gate.InputA = a;
        //    gate.InputB = b;
        //    Console.WriteLine($"{a.Int()} {b.Int()} | {gate.Output.Int()}");
        //}

        //private static void PrintTruthTableRow(bool a, bool b, bool output)
        //{
        //    Console.WriteLine($"{a.Int()} {b.Int()} | {output.Int()}");
        //}
    }
}
