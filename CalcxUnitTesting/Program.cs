﻿using System;
using Methods;

namespace Calculator;

// ==== TO USE ====
//• C# and .NET
// • data types – string, int, bool
// • variables
// • operators
// • for loops
// • scope
// • methods
//  parsing


public class Program
{
    public static void Main(string[] args)
    {
          bool calcIsRunning = true;
          while(calcIsRunning)
          {
               Console.Clear(); // Clear console on each loop iteration

               bool evalIsValid = false;
               while(!evalIsValid)
               {
                    Console.WriteLine("Use in this sequence: Input...\nFirst number, \nthen +, -, * or / \nthen second number.");                  
                    Console.WriteLine("You can also quit any time by entering Q instead of a number or operator.\n");
                    CalcEval.Evaluate();
                    evalIsValid = true;
               }

               Console.WriteLine("Press Q to quit or any other key to clear the memory \nand do another calculation.");
               var decision = Console.ReadKey();
               if(decision.Key == ConsoleKey.Q)
               {
                    calcIsRunning = false;
               }
              
          }
    }
}