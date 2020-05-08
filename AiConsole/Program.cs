using System;
using JeSuisCatho.Shared.AI.Logic;

namespace AiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var p = new Variable(false);
            var q = new Variable(false);
          //  var pSecond = new Variable(true);

            var notGateFormula = new Not(p);

          //  var formula = new Or(new Not(p), q);
          //  var secondFormula = new And(p,  pSecond);
          //  var finalFormula = new And(secondFormula, q);

        //    Console.WriteLine(formula.Evaluate());
        //    p.Value = true;
        //    Console.WriteLine(finalFormula.Evaluate());
            Console.WriteLine($"The answer is Not: {notGateFormula.Evaluate()}");

            Console.Read();
        }
    }
}
