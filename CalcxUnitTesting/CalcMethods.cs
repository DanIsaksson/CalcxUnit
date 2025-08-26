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
          while (enterNum1)
          {
               try
               {
               var input = Console.ReadLine();
               if (!double.TryParse(Console.ReadLine(), out num1))
               {
                    Console.WriteLine("Invalid number. Please enter a number.");
               }
               }
               else
               {
                    enterNum1 = false;
               }
          }

          char calcOperator = ' ';
          bool isOperatorValid = false;
          // ENSURE PROPER OPERATOR IS ENTERED
          while (!isOperatorValid)
          {
               calcOperator = Console.ReadLine()[0];

               switch (calcOperator)
               {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                         isOperatorValid = true;
                         break;
                    default:
                         Console.WriteLine("\nInvalid operator. Please enter +, -, *, or /\nRe-enter here: ");
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
          switch (calcOperator)
          {
               case '+':
                    result = CalcMethods.Add(num1, num2);
                    break;
               case '-':
                    result = CalcMethods.Subtraction(num1, num2);
                    break;
               case '*':
                    result = CalcMethods.Multiplication(num1, num2);
                    break;
               case '/':
                    result = CalcMethods.SafeDivision(num1, num2);
                    break;
               default:
                    break;
          }

          Console.WriteLine("\nResult: " + result + "\n");

     }
}

