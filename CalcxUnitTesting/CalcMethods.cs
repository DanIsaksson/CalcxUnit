using System;

namespace Methods;


// =========== METHODS ===========
public static class CalcMethods
{
     public static double Add(double addNum1, double addNum2)
     {
          return addNum1 + addNum2;
     }

     public static double Subtraction(double subNum1, double subNum2)
     {
          return subNum1 - subNum2;
     }

     public static double Multiplication(double mulNum1, double mulNum2)
     {
          return mulNum1 * mulNum2;
     }

     // Used for testing
     public static double Division(double divNum1, double divNum2)
     {
          if (divNum2 == 0)
          {
               throw new DivideByZeroException("Cannot divide by zero.");
          }
          return divNum1 / divNum2;
     }

     // Used for interacting
     public static double SafeDivision(double divNum1, double divNum2)
     {
          while (divNum2 == 0)
          {
               Console.WriteLine("Error: Either divided by zero or not a number.\nTry again: ");
               double.TryParse(Console.ReadLine(), out divNum2);
          }
          return divNum1 / divNum2;
     }

     // New helper – single place for operator → method mapping
     public static double ApplyOperator(char op, double a, double b)
     {
          // This is a switch expression. No need for cases. Each lambda expression maps
          // a pattern, such as the op variable to a method (as seen below)
          // a switch expression doesn't break out of a loop. So that's why  
          return op switch
          {
               '+' => Add(a, b),
               '-' => Subtraction(a, b),
               '*' => Multiplication(a, b),
               '/' => Division(a, b),   // Division throws if b == 0 – good!
               // I only have the _ as the "catch all" for an ArgumentException.
               _   => throw new ArgumentException($"Operator {op} not supported.")
          // close expression with ;
          };
     }

}


// =========== EVALUATION METHOD ============
public class CalcEval
{
     public static void Evaluate()
     {
          double num1 = 0;
          double num2 = 0;

          double result = 0;

          bool enterNum1 = true;
          // ENTER NUMBER INPUT 1
          // Write xUnit test in UnitTest1.cs for this section
          while (enterNum1)
          {
               try
               {
                    var input = Console.ReadLine();
                    if (!double.TryParse(input, out num1))
                    {
                         throw new FormatException("Not a number. Enter a new number.");
                    }
                    enterNum1 = false;
               }
               catch (FormatException ex)
               {
                    Console.WriteLine(ex.Message);
                    continue;
               }
               enterNum1 = false;
          }

          //string calcOperator = ' ';
          char calcOperator = ' ';
          
          bool isOperatorValid = false;
          // ENSURE PROPER OPERATOR IS ENTERED
          while (!isOperatorValid)
          {
               string? operatorInput = Console.ReadLine();
               
               if (string.IsNullOrWhiteSpace(operatorInput))
               {
                    Console.WriteLine("No operator entered—please type +, -, *, or /");
                    continue; // skip the rest of the iteration and go backto the top of the loop again
               }
               calcOperator = operatorInput.Trim()[0];

               switch (calcOperator)
               {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                         isOperatorValid = true;
                         break;
                    default:
                         Console.WriteLine("\nInvalid operator. Please enter +, -, *, or /\n");
                         Console.Write("Re-enter operator here: ");
                         break;
               }
          }

          bool enterNum2 = true;
          // ENTER NUMBER INPUT 2
          while (enterNum2)
          {
               if (!double.TryParse(Console.ReadLine(), out num2))
               {
                    Console.WriteLine("Invalid number. Please enter a number.");
               }
               else
               {
                    enterNum2 = false;
               }
          }

          //PICKS METHOD BASED ON OPERATOR PARSED FROM ABOVE
          result = CalcMethods.ApplyOperator(calcOperator, num1, num2);

          Console.WriteLine("\nResult: " + result + "\n");

     }
}

