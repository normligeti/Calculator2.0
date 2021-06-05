using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    static class CalculateUsingStack
    {
        /// <summary>
        /// Calculates and returns the end result of a postfix algebraic expression.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The result in double format.</returns>
        public static double CalculatePostfixUsingStack(this List<string> inputPostfixExpression)
        {
            Stack<double> stack = new Stack<double>();

            foreach (string token in inputPostfixExpression)
            {
                if (double.TryParse(token, out double i))
                {
                    stack.Push(i);
                }
                else
                {
                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();
                    stack.Push(Calculate(operand1, token, operand2));
                }
            }
            return stack.Pop();
        }

        private static double Calculate(double operand1, string operation, double operand2)
        {
            switch (operation)
            {
                case "/":
                    return operand1 / operand2;
                case "*":
                    return operand1 * operand2;
                case "-":
                    return operand1 - operand2;
                case "+":
                    return operand1 + operand2;
                default:
                    return 0;
            }
        }

    }
}
